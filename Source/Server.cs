using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Scanner.Service;

namespace Scanner.Server
{
    class Server
    {
        public Scanner _Scanner;
        public bool _Running;
        private readonly int _Timeout = 1000;
        private Socket _ServerSocket;
        public Server(Scanner scanner)
        {
            _Scanner = scanner;
        }

        public bool Start(IPAddress ipAddress, int port, int maxNOfCon)
        {
            if (_Running) return false;
            try
            {
                _ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _ServerSocket.Bind(new IPEndPoint(ipAddress, port));
                _ServerSocket.Listen(maxNOfCon);
                _ServerSocket.ReceiveTimeout = _Timeout;
                _ServerSocket.SendTimeout = _Timeout;
                _Running = true;
            }
            catch { return false; }

            Thread requestListenerT = new Thread(() =>
            {
                while (_Running)
                {
                    Socket clientSocket;
                    try
                    {
                        clientSocket = _ServerSocket.Accept();
                        Thread requestHandler = new Thread(() =>
                        {
                            clientSocket.ReceiveTimeout = _Timeout;
                            clientSocket.SendTimeout = _Timeout;
                            try { HandleTheRequest(clientSocket); }
                            catch
                            {
                                try { clientSocket.Close(); }
                                catch { }
                            }
                        });
                        requestHandler.Start();
                    }
                    catch { }
                }
            });
            requestListenerT.Start();
            return true;
        }
        public void Stop()
        {
            if (_Running)
            {
                _Running = false;
                try { _ServerSocket.Close(); }
                catch { }
                _ServerSocket = null;
            }
        }
        private void HandleTheRequest(Socket clientSocket)
        {
            var result = new List<byte[]>();
            var buffer = new byte[10240];
            int receivedBCount = clientSocket.Receive(buffer);
            var request = Encoding.UTF8.GetString(buffer, 0, receivedBCount);
            string strReceived = request;
            string httpMethod = strReceived.Substring(0, strReceived.IndexOf(" "));
            if (httpMethod.Equals("POST"))
            {
                result = _Scanner._StartListener();
                SendString(clientSocket, result);
            }
            else if (httpMethod.Equals("GET"))
            {
                //more with get method
            }
        }
        private void SendString(Socket clientSocket, List<byte[]> files)
        {
            if (files.Count == 0)
                SendResponse(clientSocket, "خطای اسکنر", "404 Not Found", "text/html");
            else
            {
                Response res = new Response(true, "200 OK")
                {
                    Result = files
                };
                var json = JsonConvert.SerializeObject(res);
                SendResponse(clientSocket, json, "200 OK", "text/html");
                _ = new List<byte[]>();
                _ = new Response();
            }
        }
        private void SendOkResponse(Socket clientSocket, byte[] bContent, string contentType)
        {
            SendResponse(clientSocket, bContent, "200 OK", contentType);
        }
        private void SendResponse(Socket clientSocket, string strContent, string responseCode, string contentType)
        {
            byte[] bContent = Encoding.UTF8.GetBytes(strContent);
            SendResponse(clientSocket, bContent, responseCode, contentType);
        }
        private void SendResponse(Socket clientSocket, byte[] bContent, string responseCode, string contentType)
        {
            try
            {
                byte[] bHeader = Encoding.UTF8.GetBytes(
                                    "HTTP/1.1 " + responseCode + "\r\n"
                                  + "Access-Control-Allow-Origin:* \r\n"
                                  + "Server: Scanner Service\r\n"
                                  + "Content-Length: " + bContent.Length + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
                clientSocket.Send(bHeader);
                clientSocket.Send(bContent);
                clientSocket.Close();
            }
            catch { }
        }
    }
}
