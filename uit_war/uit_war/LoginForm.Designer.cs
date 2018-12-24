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
            this.txtboxRivalIP = new System.Windows.Forms.TextBox();
            this.btCreateRoom = new System.Windows.Forms.Button();
            this.txtboxMyIP = new System.Windows.Forms.TextBox();
            this.lbMyIP = new System.Windows.Forms.Label();
            this.lbRivalIP = new System.Windows.Forms.Label();
            this.btEnterRoom = new System.Windows.Forms.Button();
            this.btCopy = new System.Windows.Forms.Button();
            this.btRank = new System.Windows.Forms.Button();
            this.txtboxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxDatabaseIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtboxRivalIP
            // 
            this.txtboxRivalIP.Location = new System.Drawing.Point(537, 351);
            this.txtboxRivalIP.Name = "txtboxRivalIP";
            this.txtboxRivalIP.Size = new System.Drawing.Size(100, 20);
            this.txtboxRivalIP.TabIndex = 0;
            // 
            // btCreateRoom
            // 
            this.btCreateRoom.Location = new System.Drawing.Point(643, 306);
            this.btCreateRoom.Name = "btCreateRoom";
            this.btCreateRoom.Size = new System.Drawing.Size(75, 23);
            this.btCreateRoom.TabIndex = 1;
            this.btCreateRoom.Text = "Tạo trận";
            this.btCreateRoom.UseVisualStyleBackColor = true;
            this.btCreateRoom.Click += new System.EventHandler(this.connect_Click);
            // 
            // txtboxMyIP
            // 
            this.txtboxMyIP.Location = new System.Drawing.Point(537, 309);
            this.txtboxMyIP.Name = "txtboxMyIP";
            this.txtboxMyIP.Size = new System.Drawing.Size(100, 20);
            this.txtboxMyIP.TabIndex = 2;
            // 
            // lbMyIP
            // 
            this.lbMyIP.AutoSize = true;
            this.lbMyIP.Location = new System.Drawing.Point(497, 312);
            this.lbMyIP.Name = "lbMyIP";
            this.lbMyIP.Size = new System.Drawing.Size(34, 13);
            this.lbMyIP.TabIndex = 3;
            this.lbMyIP.Text = "My IP";
            this.lbMyIP.Click += new System.EventHandler(this.lbMyIP_Click);
            // 
            // lbRivalIP
            // 
            this.lbRivalIP.AutoSize = true;
            this.lbRivalIP.Location = new System.Drawing.Point(478, 354);
            this.lbRivalIP.Name = "lbRivalIP";
            this.lbRivalIP.Size = new System.Drawing.Size(53, 13);
            this.lbRivalIP.TabIndex = 4;
            this.lbRivalIP.Text = "IP đối thủ";
            // 
            // btEnterRoom
            // 
            this.btEnterRoom.Location = new System.Drawing.Point(643, 351);
            this.btEnterRoom.Name = "btEnterRoom";
            this.btEnterRoom.Size = new System.Drawing.Size(75, 23);
            this.btEnterRoom.TabIndex = 5;
            this.btEnterRoom.Text = "Vào trận";
            this.btEnterRoom.UseVisualStyleBackColor = true;
            this.btEnterRoom.Click += new System.EventHandler(this.btEnterRoom_Click);
            // 
            // btCopy
            // 
            this.btCopy.Location = new System.Drawing.Point(724, 306);
            this.btCopy.Name = "btCopy";
            this.btCopy.Size = new System.Drawing.Size(75, 23);
            this.btCopy.TabIndex = 6;
            this.btCopy.Text = "Copy IP";
            this.btCopy.UseVisualStyleBackColor = true;
            this.btCopy.Click += new System.EventHandler(this.btCopy_Click);
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
            this.txtboxUsername.Location = new System.Drawing.Point(537, 234);
            this.txtboxUsername.Name = "txtboxUsername";
            this.txtboxUsername.Size = new System.Drawing.Size(100, 20);
            this.txtboxUsername.TabIndex = 8;
            this.txtboxUsername.TextChanged += new System.EventHandler(this.txtboxUsername_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên bạn";
            // 
            // txtboxDatabaseIP
            // 
            this.txtboxDatabaseIP.Location = new System.Drawing.Point(537, 184);
            this.txtboxDatabaseIP.Name = "txtboxDatabaseIP";
            this.txtboxDatabaseIP.Size = new System.Drawing.Size(100, 20);
            this.txtboxDatabaseIP.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "IP server";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxDatabaseIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtboxUsername);
            this.Controls.Add(this.btRank);
            this.Controls.Add(this.btCopy);
            this.Controls.Add(this.btEnterRoom);
            this.Controls.Add(this.lbRivalIP);
            this.Controls.Add(this.lbMyIP);
            this.Controls.Add(this.txtboxMyIP);
            this.Controls.Add(this.btCreateRoom);
            this.Controls.Add(this.txtboxRivalIP);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LoginForm";
            this.Text = "Form2";
            this.Activated += new System.EventHandler(this.LoginForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxRivalIP;
        private System.Windows.Forms.Button btCreateRoom;
        private System.Windows.Forms.TextBox txtboxMyIP;
        private System.Windows.Forms.Label lbMyIP;
        private System.Windows.Forms.Label lbRivalIP;
        private System.Windows.Forms.Button btEnterRoom;
        private System.Windows.Forms.Button btCopy;
        private System.Windows.Forms.Button btRank;
        private System.Windows.Forms.TextBox txtboxUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboxDatabaseIP;
        private System.Windows.Forms.Label label2;
    }
}