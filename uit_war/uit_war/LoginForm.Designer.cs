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
            this.btCreateRoom.Text = "Tạo phòng";
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
            this.btEnterRoom.Text = "Vào phòng";
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
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btCopy);
            this.Controls.Add(this.btEnterRoom);
            this.Controls.Add(this.lbRivalIP);
            this.Controls.Add(this.lbMyIP);
            this.Controls.Add(this.txtboxMyIP);
            this.Controls.Add(this.btCreateRoom);
            this.Controls.Add(this.txtboxRivalIP);
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
    }
}