using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using TwainDotNet;
using TwainDotNet.TwainNative;
using TwainDotNet.WinFroms;

namespace Scanner.Server
{
    public class Scanner : Form
    {
        Server server;
        public Twain _twain;
        private Button selectSource;
        ScanSettings _settings;
        private CheckBox useUICheckBox;
        private Label label2;
        private Button btstop;
        private Button btstart;
        public List<byte[]> _ResultScan = new List<byte[]>();
        private IContainer components;
        private NumericUpDown NQuality;
        private CheckBox imgcrop;
        private Label label3;
        private GroupBox groupBox1;
        private Label label1;
        private Label label5;
        private Label label4;
        private NumericUpDown NHight;
        private NumericUpDown NWidth;
        private Label label6;
        private NumericUpDown NDPI;
        private NotifyIcon trayIcon;
        private static readonly AreaSettings AreaSettings = new AreaSettings(Units.Centimeters, 0.1f, 5.7f, 0.1F + 2.6f, 5.7f + 2.6f);
        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Scanner));
            selectSource = new Button();
            useUICheckBox = new CheckBox();
            label2 = new Label();
            btstop = new Button();
            btstart = new Button();
            NQuality = new NumericUpDown();
            imgcrop = new CheckBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            label6 = new Label();
            NDPI = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            NHight = new NumericUpDown();
            NWidth = new NumericUpDown();
            label1 = new Label();
            trayIcon = new NotifyIcon(components);
            ((ISupportInitialize)(NQuality)).BeginInit();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)(NDPI)).BeginInit();
            ((ISupportInitialize)(NHight)).BeginInit();
            ((ISupportInitialize)(NWidth)).BeginInit();
            SuspendLayout();
            // 
            // selectSource
            // 
            selectSource.BackColor = SystemColors.GradientInactiveCaption;
            selectSource.Font = new Font("Tahoma", 9F);
            selectSource.ImageAlign = ContentAlignment.MiddleRight;
            selectSource.Location = new Point(40, 220);
            selectSource.Name = "selectSource";
            selectSource.Size = new Size(207, 28);
            selectSource.TabIndex = 2;
            selectSource.Text = "انتخاب اسکنر پیش فرض";
            selectSource.TextAlign = ContentAlignment.TopCenter;
            selectSource.UseVisualStyleBackColor = false;
            selectSource.Click += SelectSource_Click_1;
            // 
            // useUICheckBox
            // 
            useUICheckBox.AutoSize = true;
            useUICheckBox.BackColor = Color.Transparent;
            useUICheckBox.Font = new Font("Tahoma", 9F);
            useUICheckBox.ForeColor = Color.Black;
            useUICheckBox.Location = new Point(119, 120);
            useUICheckBox.Name = "useUICheckBox";
            useUICheckBox.Size = new Size(137, 18);
            useUICheckBox.TabIndex = 5;
            useUICheckBox.Text = "نمایش تنظیمات اسکنر";
            useUICheckBox.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.BackColor = Color.Honeydew;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Tahoma", 9F);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(284, 25);
            label2.TabIndex = 7;
            label2.Text = "سرویس استفاده از اسکنر در وب";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btstop
            // 
            btstop.BackColor = Color.FromArgb(255, 128, 128);
            btstop.Enabled = false;
            btstop.Font = new Font("Tahoma", 10F);
            btstop.ForeColor = Color.White;
            btstop.Location = new Point(149, 182);
            btstop.Name = "btstop";
            btstop.Size = new Size(98, 32);
            btstop.TabIndex = 2;
            btstop.Text = "توقف";
            btstop.UseVisualStyleBackColor = false;
            btstop.Click += BtnStop_Click;
            // 
            // btstart
            // 
            btstart.BackColor = Color.MediumSeaGreen;
            btstart.Font = new Font("Tahoma", 10F);
            btstart.ForeColor = Color.White;
            btstart.Location = new Point(40, 182);
            btstart.Name = "btstart";
            btstart.Size = new Size(98, 32);
            btstart.TabIndex = 2;
            btstart.Text = "شروع";
            btstart.UseVisualStyleBackColor = false;
            btstart.Click += BtnStart_Click;
            // 
            // NQuality
            // 
            NQuality.Location = new Point(7, 80);
            NQuality.Maximum = new decimal(new[] {
            300,
            0,
            0,
            0});
            NQuality.Name = "NQuality";
            NQuality.Size = new Size(46, 22);
            NQuality.TabIndex = 9;
            NQuality.Value = new decimal(new[] {
            20,
            0,
            0,
            0});
            // 
            // imgcrop
            // 
            imgcrop.AutoSize = true;
            imgcrop.BackColor = Color.Transparent;
            imgcrop.Font = new Font("Tahoma", 9F);
            imgcrop.Location = new Point(169, 22);
            imgcrop.Name = "imgcrop";
            imgcrop.Size = new Size(82, 18);
            imgcrop.TabIndex = 10;
            imgcrop.Text = "برش عکس";
            imgcrop.UseVisualStyleBackColor = false;
            imgcrop.CheckedChanged += ImageCrop_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F);
            label3.Location = new Point(59, 84);
            label3.Name = "label3";
            label3.Size = new Size(67, 14);
            label3.TabIndex = 11;
            label3.Text = "کیفیت تصویر";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(NDPI);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(NHight);
            groupBox1.Controls.Add(NWidth);
            groupBox1.Controls.Add(imgcrop);
            groupBox1.Controls.Add(NQuality);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(useUICheckBox);
            groupBox1.Font = new Font("Tahoma", 9F);
            groupBox1.Location = new Point(10, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(264, 144);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "تنظیمات";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 9F);
            label6.Location = new Point(59, 56);
            label6.Name = "label6";
            label6.Size = new Size(72, 14);
            label6.TabIndex = 17;
            label6.Text = "کیفیت اسکن";
            // 
            // NDPI
            // 
            NDPI.Location = new Point(7, 52);
            NDPI.Maximum = new decimal(new[] {
            300,
            0,
            0,
            0});
            NDPI.Name = "NDPI";
            NDPI.Size = new Size(46, 22);
            NDPI.TabIndex = 16;
            NDPI.Value = new decimal(new[] {
            170,
            0,
            0,
            0});
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(213, 81);
            label5.Name = "label5";
            label5.Size = new Size(41, 14);
            label5.TabIndex = 15;
            label5.Text = "عرض :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(213, 51);
            label4.Name = "label4";
            label4.Size = new Size(36, 14);
            label4.TabIndex = 14;
            label4.Text = "طول :";
            // 
            // NHight
            // 
            NHight.Enabled = false;
            NHight.Location = new Point(139, 49);
            NHight.Maximum = new decimal(new[] {
            10000,
            0,
            0,
            0});
            NHight.Name = "NHight";
            NHight.Size = new Size(69, 22);
            NHight.TabIndex = 13;
            NHight.Value = new decimal(new[] {
            800,
            0,
            0,
            0});
            // 
            // NWidth
            // 
            NWidth.Enabled = false;
            NWidth.Location = new Point(139, 77);
            NWidth.Maximum = new decimal(new[] {
            10000,
            0,
            0,
            0});
            NWidth.Name = "NWidth";
            NWidth.Size = new Size(69, 22);
            NWidth.TabIndex = 12;
            NWidth.Value = new decimal(new[] {
            700,
            0,
            0,
            0});
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(121, 251);
            label1.Name = "label1";
            label1.Size = new Size(34, 13);
            label1.TabIndex = 0;
            label1.Text = ".........";
            // 
            // trayIcon
            // 
            trayIcon.Icon = ((Icon)(resources.GetObject("trayIcon.Icon")));
            trayIcon.Text = "سرویس اسکنر";
            trayIcon.Visible = true;
            trayIcon.MouseDoubleClick += TrayIcon_MouseDoubleClick;
            // 
            // Scanner
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(284, 254);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(btstart);
            Controls.Add(btstop);
            Controls.Add(selectSource);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = ((Icon)(resources.GetObject("$this.Icon")));
            MaximizeBox = false;
            Name = "Scanner";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            FormClosing += Scanner_FormClosing;
            FormClosed += Scanner_FormClosed;
            SizeChanged += Form1_SizeChanged;
            ((ISupportInitialize)(NQuality)).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize)(NDPI)).EndInit();
            ((ISupportInitialize)(NHight)).EndInit();
            ((ISupportInitialize)(NWidth)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        public Scanner()
        {
            InitializeComponent();
            _twain = new Twain(new WinFormsWindowMessageHook(this));
            _twain.TransferImage += delegate (Object sender, TransferImageEventArgs args)
            {
                if (args.Image != null)
                {
                    if (!InvokeRequired)
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            Bitmap bitmap = new Bitmap(args.Image);
                            if (imgcrop.Checked)
                                bitmap = CropBitmap(args.Image, 0, 0, 800, 700);
                            Bitmap newBitmap = new Bitmap(bitmap);
                            float fdpi = (float)NQuality.Value;
                            newBitmap.SetResolution(fdpi, fdpi);
                            _ResultScan.Add(Convert_ImageTo_Byte(newBitmap, ImageFormat.Jpeg));
                        }));
                    }

                }
            };
            _twain.ScanningComplete += delegate { Enabled = true; };
            server = new Server(this);
        }
        public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
            return cropped;
        }
        public byte[] Convert_ImageTo_Byte(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var encoder = ImageCodecInfo.GetImageEncoders()
                               .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                var encParams = new EncoderParameters(1);
                encParams.Param[0] = new EncoderParameter(
                    Encoder.Quality, (int)NQuality.Value);
                //First Convert Image to byte[]
                image.Save(ms, encoder, encParams);
                byte[] imageBytes = ms.ToArray();

                //Then Convert byte[] to Base64 String
                //string base64String = Convert.ToBase64String(imageBytes);
                return imageBytes;
            }
        }
        private void SelectSource_Click(object sender, EventArgs e)
        {
            _twain.SelectSource();
        }
        public void GetBase()
        {
            while (!Enabled)
            {
            }
        }
        public void _StartScan()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    Enabled = false;
                    _settings = new ScanSettings();
                    _settings.UseDocumentFeeder = false;
                    _settings.ShowTwainUI = useUICheckBox.Checked;
                    _settings.ShowProgressIndicatorUI = true;
                    _settings.UseDuplex = true;
                    _settings.Resolution =
                        ResolutionSettings.ColourPhotocopier;
                    _settings.Resolution.Dpi = (int)NDPI.Value;
                    _settings.Area = !false ? null : AreaSettings;
                    _settings.ShouldTransferAllPages = true;
                    _settings.Rotation = new RotationSettings
                    {
                        AutomaticRotate = false,
                        AutomaticBorderDetection = false,
                    };
                    try
                    {
                        _twain.StartScanning(_settings);
                    }
                    catch 
                    {
                        Enabled = true;
                    }
                }));
            }
        }

        private void SelectSource_Click_1(object sender, EventArgs e)
        {
            _twain.SelectSource();
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            if (server.Start(ipAddress, 6565, 100))
            {
                btstart.Enabled = false;
                btstop.Enabled = true;
            }
            else
                MessageBox.Show(this, "لطفا قبل از راه اندازی سرویس از باز بودن پورت 8085 اطمینان حاصل نمایید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void BtnStop_Click(object sender, EventArgs e)
        {
            btstart.Enabled = true;
            btstop.Enabled = false;
            server.Stop();
        }
        public List<byte[]> _StartListener()
        {
            _ResultScan = new List<byte[]>();
            _StartScan();
            GetBase();
            return _ResultScan;
        }
        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            trayIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                trayIcon.Visible = true;
                Hide();
            }
        }
        private void Scanner_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Stop();
        }
        private void ImageCrop_CheckedChanged(object sender, EventArgs e)
        {
            if (imgcrop.Checked)
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

        private void Scanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
            trayIcon.Visible = false;
        }
    }
}

