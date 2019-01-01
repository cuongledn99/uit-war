namespace uit_war
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btRank = new System.Windows.Forms.Button();
            this.txtboxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxDatabaseIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtboxID = new System.Windows.Forms.TextBox();
            this.txtboxPassword = new System.Windows.Forms.TextBox();
            this.btDangki = new System.Windows.Forms.Button();
            this.btDangNhap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.btShare = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btFindMatch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btRank
            // 
            this.btRank.Location = new System.Drawing.Point(30, 34);
            this.btRank.Name = "btRank";
            this.btRank.Size = new System.Drawing.Size(104, 23);
            this.btRank.TabIndex = 7;
            this.btRank.Text = "Bảng xếp hạng";
            this.btRank.UseVisualStyleBackColor = true;
            this.btRank.Click += new System.EventHandler(this.btRank_Click);
            // 
            // txtboxUsername
            // 
            this.txtboxUsername.Location = new System.Drawing.Point(579, 259);
            this.txtboxUsername.Name = "txtboxUsername";
            this.txtboxUsername.Size = new System.Drawing.Size(100, 20);
            this.txtboxUsername.TabIndex = 8;
            this.txtboxUsername.TextChanged += new System.EventHandler(this.txtboxUsername_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên bạn";
            // 
            // txtboxDatabaseIP
            // 
            this.txtboxDatabaseIP.Location = new System.Drawing.Point(579, 207);
            this.txtboxDatabaseIP.Name = "txtboxDatabaseIP";
            this.txtboxDatabaseIP.Size = new System.Drawing.Size(100, 20);
            this.txtboxDatabaseIP.TabIndex = 10;
            this.txtboxDatabaseIP.TextChanged += new System.EventHandler(this.txtboxDatabaseIP_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "IP server";
            // 
            // txtboxID
            // 
            this.txtboxID.Location = new System.Drawing.Point(113, 207);
            this.txtboxID.Name = "txtboxID";
            this.txtboxID.Size = new System.Drawing.Size(100, 20);
            this.txtboxID.TabIndex = 12;
            // 
            // txtboxPassword
            // 
            this.txtboxPassword.Location = new System.Drawing.Point(113, 262);
            this.txtboxPassword.Name = "txtboxPassword";
            this.txtboxPassword.Size = new System.Drawing.Size(100, 20);
            this.txtboxPassword.TabIndex = 13;
            // 
            // btDangki
            // 
            this.btDangki.Location = new System.Drawing.Point(42, 324);
            this.btDangki.Name = "btDangki";
            this.btDangki.Size = new System.Drawing.Size(75, 23);
            this.btDangki.TabIndex = 14;
            this.btDangki.Text = "Đăng kí";
            this.btDangki.UseVisualStyleBackColor = true;
            this.btDangki.Click += new System.EventHandler(this.btDangki_Click);
            // 
            // btDangNhap
            // 
            this.btDangNhap.Location = new System.Drawing.Point(123, 324);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btDangNhap.TabIndex = 15;
            this.btDangNhap.Text = "Đăng nhập";
            this.btDangNhap.UseVisualStyleBackColor = true;
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "User name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Password";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(297, 112);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 18;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // btShare
            // 
            this.btShare.Location = new System.Drawing.Point(668, 12);
            this.btShare.Name = "btShare";
            this.btShare.Size = new System.Drawing.Size(104, 23);
            this.btShare.TabIndex = 19;
            this.btShare.Text = "Chia sẻ";
            this.btShare.UseVisualStyleBackColor = true;
            this.btShare.Click += new System.EventHandler(this.btShare_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(204, 324);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 23);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btFindMatch
            // 
            this.btFindMatch.Location = new System.Drawing.Point(697, 324);
            this.btFindMatch.Name = "btFindMatch";
            this.btFindMatch.Size = new System.Drawing.Size(75, 23);
            this.btFindMatch.TabIndex = 21;
            this.btFindMatch.Text = "Tìm trận";
            this.btFindMatch.UseVisualStyleBackColor = true;
            this.btFindMatch.Click += new System.EventHandler(this.btFindMatch_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btFindMatch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btShare);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btDangNhap);
            this.Controls.Add(this.btDangki);
            this.Controls.Add(this.txtboxPassword);
            this.Controls.Add(this.txtboxID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxDatabaseIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtboxUsername);
            this.Controls.Add(this.btRank);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LoginForm";
            this.Text = "Form2";
            this.Activated += new System.EventHandler(this.LoginForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btRank;
        private System.Windows.Forms.TextBox txtboxUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboxDatabaseIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtboxID;
        private System.Windows.Forms.TextBox txtboxPassword;
        private System.Windows.Forms.Button btDangki;
        private System.Windows.Forms.Button btDangNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button btShare;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btFindMatch;
    }
}