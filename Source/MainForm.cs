using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using TwainDotNet;
using TwainDotNet.TwainNative;
using TwainDotNet.WinFroms;

namespace Scanner.Service
{
    public partial class MainForm : Form
    {
        private List<byte[]> _resultScan;
        private readonly ScannerSocketService _server;
        private readonly Twain _twain;

        public MainForm()
        {
            InitializeComponent();
            _twain = new Twain(new WinFormsWindowMessageHook(this));
            _twain.TransferImage += delegate(object sender, TransferImageEventArgs args)
            {
                if (args.Image != null)
                {
                    if (!InvokeRequired)
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            var bitmap = new Bitmap(args.Image);
                            if (ChkCrop.Checked)
                                bitmap = CropBitmap(args.Image, 0, 0, 800, 700);
                            var newBitmap = new Bitmap(bitmap);
                            var photoDpi = (float)NQuality.Value;
                            newBitmap.SetResolution(photoDpi, photoDpi);
                            _resultScan.Add(ConvertImageToByte(newBitmap, ImageFormat.Jpeg));
                        }));
                    }
                }
            };
            _twain.ScanningComplete += delegate { Enabled = true; };
            _resultScan = new List<byte[]>();
            _server = new ScannerSocketService(this);
        }


        public List<byte[]> StartListener()
        {
            _resultScan = new List<byte[]>();
            StartScan();
            GetBase();
            return _resultScan;
        }

        private void StartScan()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    Enabled = false;
                    var settings = new ScanSettings
                    {
                        UseDocumentFeeder = false,
                        ShowTwainUI = ChkShowScannerSetting.Checked,
                        ShowProgressIndicatorUI = true,
                        UseDuplex = true,
                        Resolution = ResolutionSettings.ColourPhotocopier
                    };
                    settings.Resolution.Dpi = (int)NDPI.Value;
                    settings.Area = !false
                        ? null
                        : new AreaSettings(Units.Centimeters, 0.1f, 5.7f, 0.1f + 2.6f, 5.7f + 2.6f);
                    settings.ShouldTransferAllPages = true;
                    settings.Rotation = new RotationSettings
                    {
                        AutomaticRotate = false,
                        AutomaticBorderDetection = false,
                    };
                    try
                    {
                        _twain.StartScanning(settings);
                    }
                    catch
                    {
                        Enabled = true;
                    }
                }));
            }
        }

        private void BtnSelectScanner_Click(object sender, EventArgs e) => _twain.SelectSource();

        private void BtnStop_Click(object sender, EventArgs e)
        {
            BtnStart.Enabled = true;
            BtnStop.Enabled = false;

            _server.Stop();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            if (_server.Start(ipAddress, 6565, 10))
            {
                BtnStart.Enabled = false;
                BtnStop.Enabled = true;
            }
            else
                MessageBox.Show("لطفا قبل از راه اندازی سرویس از باز بودن پورت 8085 اطمینان حاصل نمایید.", "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GetBase()
        {
            while (!Enabled)
            {
            }
        }

        private Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            var rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            var cropped = bitmap.Clone(rect, bitmap.PixelFormat);
            return cropped;
        }

        private byte[] ConvertImageToByte(Image image, ImageFormat format)
        {
            using (var memoryStream = new MemoryStream())
            {
                var encoder = ImageCodecInfo.GetImageEncoders()
                    .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(
                    Encoder.Quality, (int)NQuality.Value);
                image.Save(memoryStream, encoder, encoderParams);
                var imageBytes = memoryStream.ToArray();

                return imageBytes;
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            NotifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                NotifyIcon.Visible = true;
                Hide();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server.Stop();
            NotifyIcon.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server.Stop();
            NotifyIcon.Visible = false;
        }

        private void ChkCrop_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCrop.Checked)
            {
                NWidth.Enabled = true;
                NHight.Enabled = true;
            }
            else
            {
                NWidth.Enabled = false;
                NHight.Enabled = false;
            }
        }
    }
}