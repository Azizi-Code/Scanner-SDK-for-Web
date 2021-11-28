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

namespace Scanner.Server
{
    public class Scanner : Form
    {
        Server server = null;
        public Twain _twain;
        private Button selectSource;
        ScanSettings _settings;
        private CheckBox useUICheckBox;
        private Label label2;
        private Button btstop;
        private Button btstart;
        public List<byte[]> _ResultScan = new List<byte[]>();
        private System.ComponentModel.IContainer components;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scanner));
            this.selectSource = new System.Windows.Forms.Button();
            this.useUICheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btstop = new System.Windows.Forms.Button();
            this.btstart = new System.Windows.Forms.Button();
            this.NQuality = new System.Windows.Forms.NumericUpDown();
            this.imgcrop = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NDPI = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NHight = new System.Windows.Forms.NumericUpDown();
            this.NWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NQuality)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NDPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // selectSource
            // 
            this.selectSource.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.selectSource.Font = new System.Drawing.Font("Tahoma", 9F);
            this.selectSource.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectSource.Location = new System.Drawing.Point(40, 220);
            this.selectSource.Name = "selectSource";
            this.selectSource.Size = new System.Drawing.Size(207, 28);
            this.selectSource.TabIndex = 2;
            this.selectSource.Text = "انتخاب اسکنر پیش فرض";
            this.selectSource.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.selectSource.UseVisualStyleBackColor = false;
            this.selectSource.Click += new System.EventHandler(this.SelectSource_Click_1);
            // 
            // useUICheckBox
            // 
            this.useUICheckBox.AutoSize = true;
            this.useUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.useUICheckBox.Font = new System.Drawing.Font("Tahoma", 9F);
            this.useUICheckBox.ForeColor = System.Drawing.Color.Black;
            this.useUICheckBox.Location = new System.Drawing.Point(119, 120);
            this.useUICheckBox.Name = "useUICheckBox";
            this.useUICheckBox.Size = new System.Drawing.Size(137, 18);
            this.useUICheckBox.TabIndex = 5;
            this.useUICheckBox.Text = "نمایش تنظیمات اسکنر";
            this.useUICheckBox.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Honeydew;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "سرویس استفاده از اسکنر در وب";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btstop
            // 
            this.btstop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btstop.Enabled = false;
            this.btstop.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btstop.ForeColor = System.Drawing.Color.White;
            this.btstop.Location = new System.Drawing.Point(149, 182);
            this.btstop.Name = "btstop";
            this.btstop.Size = new System.Drawing.Size(98, 32);
            this.btstop.TabIndex = 2;
            this.btstop.Text = "توقف";
            this.btstop.UseVisualStyleBackColor = false;
            this.btstop.Click += new System.EventHandler(this.Btstop_Click);
            // 
            // btstart
            // 
            this.btstart.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btstart.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btstart.ForeColor = System.Drawing.Color.White;
            this.btstart.Location = new System.Drawing.Point(40, 182);
            this.btstart.Name = "btstart";
            this.btstart.Size = new System.Drawing.Size(98, 32);
            this.btstart.TabIndex = 2;
            this.btstart.Text = "شروع";
            this.btstart.UseVisualStyleBackColor = false;
            this.btstart.Click += new System.EventHandler(this.Btstart_Click);
            // 
            // NQuality
            // 
            this.NQuality.Location = new System.Drawing.Point(7, 80);
            this.NQuality.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NQuality.Name = "NQuality";
            this.NQuality.Size = new System.Drawing.Size(46, 22);
            this.NQuality.TabIndex = 9;
            this.NQuality.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // imgcrop
            // 
            this.imgcrop.AutoSize = true;
            this.imgcrop.BackColor = System.Drawing.Color.Transparent;
            this.imgcrop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.imgcrop.Location = new System.Drawing.Point(169, 22);
            this.imgcrop.Name = "imgcrop";
            this.imgcrop.Size = new System.Drawing.Size(82, 18);
            this.imgcrop.TabIndex = 10;
            this.imgcrop.Text = "برش عکس";
            this.imgcrop.UseVisualStyleBackColor = false;
            this.imgcrop.CheckedChanged += new System.EventHandler(this.Imgcrop_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(59, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "کیفیت تصویر";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NDPI);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.NHight);
            this.groupBox1.Controls.Add(this.NWidth);
            this.groupBox1.Controls.Add(this.imgcrop);
            this.groupBox1.Controls.Add(this.NQuality);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.useUICheckBox);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox1.Location = new System.Drawing.Point(10, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 144);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تنظیمات";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.Location = new System.Drawing.Point(59, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "کیفیت اسکن";
            // 
            // NDPI
            // 
            this.NDPI.Location = new System.Drawing.Point(7, 52);
            this.NDPI.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NDPI.Name = "NDPI";
            this.NDPI.Size = new System.Drawing.Size(46, 22);
            this.NDPI.TabIndex = 16;
            this.NDPI.Value = new decimal(new int[] {
            170,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "عرض :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "طول :";
            // 
            // NHight
            // 
            this.NHight.Enabled = false;
            this.NHight.Location = new System.Drawing.Point(139, 49);
            this.NHight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NHight.Name = "NHight";
            this.NHight.Size = new System.Drawing.Size(69, 22);
            this.NHight.TabIndex = 13;
            this.NHight.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // NWidth
            // 
            this.NWidth.Enabled = false;
            this.NWidth.Location = new System.Drawing.Point(139, 77);
            this.NWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NWidth.Name = "NWidth";
            this.NWidth.Size = new System.Drawing.Size(69, 22);
            this.NWidth.TabIndex = 12;
            this.NWidth.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = ".........";
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "سرویس اسکنر";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // Scanner
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(284, 254);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btstart);
            this.Controls.Add(this.btstop);
            this.Controls.Add(this.selectSource);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Scanner";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Scaner_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Scaner_FormClosed);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.NQuality)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NDPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
                        this.Invoke(new MethodInvoker(delegate
                        {
                            Bitmap bitmap = new Bitmap(args.Image);
                            if (imgcrop.Checked)
                                bitmap = CropBitmap(args.Image, 0, 0, 800, 700);
                            Bitmap newBitmap = new Bitmap(bitmap);
                            float fdpi = (float)NQuality.Value;
                            newBitmap.SetResolution(fdpi, fdpi);
                            _ResultScan.Add(Convert_ImageTo_Byte(newBitmap, System.Drawing.Imaging.ImageFormat.Jpeg));
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
        public List<byte[]> GetBase()
        {
            while (!Enabled)
            {
                continue;
            }
            return _ResultScan;
        }
        public void _StartScan()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    Enabled = false;
                    _settings = new ScanSettings();
                    _settings.UseDocumentFeeder = false;
                    _settings.ShowTwainUI = useUICheckBox.Checked;
                    _settings.ShowProgressIndicatorUI = true;
                    _settings.UseDuplex = true;
                    _settings.Resolution =
                        false
                        ? ResolutionSettings.Fax : ResolutionSettings.ColourPhotocopier;
                    _settings.Resolution.Dpi = (int)NDPI.Value;
                    _settings.Area = !false ? null : AreaSettings;
                    _settings.ShouldTransferAllPages = true;
                    _settings.Rotation = new RotationSettings()
                    {
                        AutomaticRotate = false,
                        AutomaticBorderDetection = false,
                    };
                    try
                    {
                        _twain.StartScanning(_settings);
                    }
                    catch (TwainException ex)
                    {
                        //  MessageBox.Show(ex.Message);
                        Enabled = true;
                    }
                }));
            }
        }

        private void SelectSource_Click_1(object sender, EventArgs e)
        {
            _twain.SelectSource();
        }
        private void Btstart_Click(object sender, EventArgs e)
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
        private void Btstop_Click(object sender, EventArgs e)
        {
            btstart.Enabled = true;
            btstop.Enabled = false;
            server.Stop();
        }
        public List<byte[]> _StartListner()
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
            this.WindowState = FormWindowState.Normal;
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                trayIcon.Visible = true;
                this.Hide();
            }
        }
        private void Scaner_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Stop();
        }
        private void Imgcrop_CheckedChanged(object sender, EventArgs e)
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

        private void Scaner_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
            trayIcon.Visible = false;
        }
    }
}

