using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Scanner.Service
{
    class ScannerSocketService
    {
        private readonly MainForm _scannerForm;
        private bool _running;
        private readonly int _timeout = 1000;
        private Socket _serviceSocket;

        public ScannerSocketService(MainForm scanner)
        {
            _scannerForm = scanner;
        }

        internal bool Start(IPAddress ipAddress, int port, int maxNumberOfConnection)
        {
            if (_running) return false;
            try
            {
                _serviceSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serviceSocket.Bind(new IPEndPoint(ipAddress, port));
                _serviceSocket.Listen(maxNumberOfConnection);
                _serviceSocket.ReceiveTimeout = _timeout;
                _serviceSocket.SendTimeout = _timeout;
                _running = true;
            }
            catch
            {
                return false;
            }

            var requestListenerThread = new Thread(() =>
            {
                while (_running)
                {
                    Socket clientSocket;
                    try
                    {
                        clientSocket = _serviceSocket.Accept();
                        var requestHandler = new Thread(() =>
                        {
                            clientSocket.ReceiveTimeout = _timeout;
                            clientSocket.SendTimeout = _timeout;
                            try
                            {
                                HandleTheRequest(clientSocket);
                            }
                            catch
                            {
                                try
                                {
                                    clientSocket.Close();
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message);
                                }
                            }
                        });
                        requestHandler.Start();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            });
            requestListenerThread.Start();
            return true;
        }

        internal void Stop()
        {
            if (_running)
            {
                _running = false;
                try
                {
                    _serviceSocket.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                _serviceSocket = null;
            }
        }

        private void HandleTheRequest(Socket clientSocket)
        {
            var buffer = new byte[10240];
            var receivedBufferCount = clientSocket.Receive(buffer);
            var request = Encoding.UTF8.GetString(buffer, 0, receivedBufferCount);
            var httpMethod = request.Substring(0, request.IndexOf(" "));
            if (httpMethod.Equals("POST"))
            {
                var result = _scannerForm.StartListener();
                SendString(clientSocket, result);
            }
        }

        private void SendString(Socket clientSocket, List<byte[]> files)
        {
            if (files.Count == 0)
                SendResponse(clientSocket, "خطای اسکنر", "404 Not Found", "text/html");
            else
            {
                var result = new Response(true, "200 OK")
                {
                    Result = files
                };
                var json = JsonConvert.SerializeObject(result);
                SendResponse(clientSocket, json, "200 OK", "text/html");
            }
        }

        private void SendResponse(Socket clientSocket, string strContent, string responseCode, string contentType)
        {
            var content = Encoding.UTF8.GetBytes(strContent);
            SendResponse(clientSocket, content, responseCode, contentType);
        }

        private void SendResponse(Socket clientSocket, byte[] content, string responseCode, string contentType)
        {
            try
            {
                var header = Encoding.UTF8.GetBytes(
                    $"HTTP/1.1 {responseCode} \r\n"
                    + "Access-Control-Allow-Origin:* \r\n"
                    + "Server: Scanner Service\r\n"
                    + $"Content-Length: {content.Length} \r\n"
                    + "Connection: close\r\n"
                    + $"Content-Type:{contentType} \r\n\r\n");
                clientSocket.Send(header);
                clientSocket.Send(content);
                clientSocket.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}