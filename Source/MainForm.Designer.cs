namespace Scanner.Service
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.NDPI = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NHight = new System.Windows.Forms.NumericUpDown();
            this.NWidth = new System.Windows.Forms.NumericUpDown();
            this.ChkCrop = new System.Windows.Forms.CheckBox();
            this.NQuality = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.ChkShowScannerSetting = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSelectScanner = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NDPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NQuality)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "سرویس اسکنر";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.Location = new System.Drawing.Point(59, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "کیفیت اسکن :";
            // 
            // NDPI
            // 
            this.NDPI.Location = new System.Drawing.Point(7, 48);
            this.NDPI.Name = "NDPI";
            this.NDPI.Size = new System.Drawing.Size(46, 22);
            this.NDPI.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "عرض :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "طول :";
            // 
            // NHight
            // 
            this.NHight.Enabled = false;
            this.NHight.Location = new System.Drawing.Point(155, 48);
            this.NHight.Name = "NHight";
            this.NHight.Size = new System.Drawing.Size(69, 22);
            this.NHight.TabIndex = 13;
            // 
            // NWidth
            // 
            this.NWidth.Enabled = false;
            this.NWidth.Location = new System.Drawing.Point(155, 75);
            this.NWidth.Name = "NWidth";
            this.NWidth.Size = new System.Drawing.Size(69, 22);
            this.NWidth.TabIndex = 12;
            // 
            // ChkCrop
            // 
            this.ChkCrop.AutoSize = true;
            this.ChkCrop.BackColor = System.Drawing.Color.Transparent;
            this.ChkCrop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ChkCrop.Location = new System.Drawing.Point(190, 22);
            this.ChkCrop.Name = "ChkCrop";
            this.ChkCrop.Size = new System.Drawing.Size(82, 18);
            this.ChkCrop.TabIndex = 10;
            this.ChkCrop.Text = "برش عکس";
            this.ChkCrop.UseVisualStyleBackColor = false;
            this.ChkCrop.CheckedChanged += new System.EventHandler(this.ChkCrop_CheckedChanged);
            // 
            // NQuality
            // 
            this.NQuality.Location = new System.Drawing.Point(7, 75);
            this.NQuality.Name = "NQuality";
            this.NQuality.Size = new System.Drawing.Size(46, 22);
            this.NQuality.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(59, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "کیفیت تصویر :";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Honeydew;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "سرویس استفاده از اسکنر در وب";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnStart.Font = new System.Drawing.Font("Tahoma", 10F);
            this.BtnStart.ForeColor = System.Drawing.Color.White;
            this.BtnStart.Location = new System.Drawing.Point(44, 177);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(98, 32);
            this.BtnStart.TabIndex = 14;
            this.BtnStart.Text = "شروع";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.BackColor = System.Drawing.Color.Tomato;
            this.BtnStop.Enabled = false;
            this.BtnStop.Font = new System.Drawing.Font("Tahoma", 10F);
            this.BtnStop.ForeColor = System.Drawing.Color.White;
            this.BtnStop.Location = new System.Drawing.Point(153, 177);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(98, 32);
            this.BtnStop.TabIndex = 15;
            this.BtnStop.Text = "توقف";
            this.BtnStop.UseVisualStyleBackColor = false;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // ChkShowScannerSetting
            // 
            this.ChkShowScannerSetting.AutoSize = true;
            this.ChkShowScannerSetting.BackColor = System.Drawing.Color.Transparent;
            this.ChkShowScannerSetting.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ChkShowScannerSetting.ForeColor = System.Drawing.Color.Black;
            this.ChkShowScannerSetting.Location = new System.Drawing.Point(135, 120);
            this.ChkShowScannerSetting.Name = "ChkShowScannerSetting";
            this.ChkShowScannerSetting.Size = new System.Drawing.Size(137, 18);
            this.ChkShowScannerSetting.TabIndex = 5;
            this.ChkShowScannerSetting.Text = "نمایش تنظیمات اسکنر";
            this.ChkShowScannerSetting.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NDPI);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.NHight);
            this.groupBox1.Controls.Add(this.NWidth);
            this.groupBox1.Controls.Add(this.ChkCrop);
            this.groupBox1.Controls.Add(this.NQuality);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ChkShowScannerSetting);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox1.Location = new System.Drawing.Point(10, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 144);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تنظیمات";
            // 
            // BtnSelectScanner
            // 
            this.BtnSelectScanner.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BtnSelectScanner.Font = new System.Drawing.Font("Tahoma", 9F);
            this.BtnSelectScanner.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSelectScanner.Location = new System.Drawing.Point(44, 215);
            this.BtnSelectScanner.Name = "BtnSelectScanner";
            this.BtnSelectScanner.Size = new System.Drawing.Size(207, 28);
            this.BtnSelectScanner.TabIndex = 16;
            this.BtnSelectScanner.Text = "انتخاب اسکنر پیش فرض";
            this.BtnSelectScanner.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSelectScanner.UseVisualStyleBackColor = false;
            this.BtnSelectScanner.Click += new System.EventHandler(this.BtnSelectScanner_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = ".........";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(302, 254);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnSelectScanner);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.NDPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NHight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NQuality)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NDPI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NHight;
        private System.Windows.Forms.NumericUpDown NWidth;
        private System.Windows.Forms.CheckBox ChkCrop;
        private System.Windows.Forms.NumericUpDown NQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.CheckBox ChkShowScannerSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSelectScanner;
        private System.Windows.Forms.Label label1;
    }
}