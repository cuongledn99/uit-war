using System.IO;

namespace uit_war
{
    public partial class MainGameForm
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
            this.exit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_increase_money = new System.Windows.Forms.Timer(this.components);
            this.btHealingSpell = new System.Windows.Forms.Button();
            this.btKnight = new System.Windows.Forms.Button();
            this.btMegaman = new System.Windows.Forms.Button();
            this.btHulk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(759, 538);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 4;
            this.exit.Text = "exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer_increase_money
            // 
            this.timer_increase_money.Interval = 2000;
            this.timer_increase_money.Tick += new System.EventHandler(this.timer_inc_money_tick);
            // 
            // btHealingSpell
            // 
            this.btHealingSpell.BackgroundImage = global::uit_war.Properties.Resources.healing_spell_faded;
            this.btHealingSpell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btHealingSpell.Location = new System.Drawing.Point(548, 0);
            this.btHealingSpell.Name = "btHealingSpell";
            this.btHealingSpell.Size = new System.Drawing.Size(75, 53);
            this.btHealingSpell.TabIndex = 10;
            this.btHealingSpell.UseVisualStyleBackColor = true;
            this.btHealingSpell.Click += new System.EventHandler(this.btHealingSpell_Click);
            this.btHealingSpell.MouseLeave += new System.EventHandler(this.btHealingSpell_MouseLeave);
            this.btHealingSpell.MouseHover += new System.EventHandler(this.btHealingSpell_MouseHover);
            // 
            // btKnight
            // 
            this.btKnight.BackgroundImage = global::uit_war.Properties.Resources.knight_faded;
            this.btKnight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btKnight.Location = new System.Drawing.Point(620, 0);
            this.btKnight.Name = "btKnight";
            this.btKnight.Size = new System.Drawing.Size(75, 53);
            this.btKnight.TabIndex = 9;
            this.btKnight.UseVisualStyleBackColor = true;
            this.btKnight.Click += new System.EventHandler(this.button_minion_clicked);
            this.btKnight.MouseLeave += new System.EventHandler(this.btKnight_MouseLeave);
            this.btKnight.MouseHover += new System.EventHandler(this.btKnight_MouseHover);
            // 
            // btMegaman
            // 
            this.btMegaman.BackgroundImage = global::uit_war.Properties.Resources.megaman_faded;
            this.btMegaman.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btMegaman.Location = new System.Drawing.Point(692, 0);
            this.btMegaman.Name = "btMegaman";
            this.btMegaman.Size = new System.Drawing.Size(75, 53);
            this.btMegaman.TabIndex = 8;
            this.btMegaman.UseVisualStyleBackColor = true;
            this.btMegaman.Click += new System.EventHandler(this.button_archer_clicked);
            this.btMegaman.MouseLeave += new System.EventHandler(this.btMegaman_MouseLeave);
            this.btMegaman.MouseHover += new System.EventHandler(this.btMegaman_MouseHover);
            // 
            // btHulk
            // 
            this.btHulk.BackgroundImage = global::uit_war.Properties.Resources.hulk_faded;
            this.btHulk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btHulk.Location = new System.Drawing.Point(763, 0);
            this.btHulk.Name = "btHulk";
            this.btHulk.Size = new System.Drawing.Size(71, 53);
            this.btHulk.TabIndex = 7;
            this.btHulk.UseVisualStyleBackColor = true;
            this.btHulk.Click += new System.EventHandler(this.button_giant_clicked);
            this.btHulk.MouseLeave += new System.EventHandler(this.btHulk_MouseLeave);
            this.btHulk.MouseHover += new System.EventHandler(this.btHulk_MouseHover);
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.btHealingSpell);
            this.Controls.Add(this.btKnight);
            this.Controls.Add(this.btMegaman);
            this.Controls.Add(this.btHulk);
            this.Controls.Add(this.exit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainGameForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGameForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainGameForm_Shown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button btHulk;
        private System.Windows.Forms.Button btMegaman;
        private System.Windows.Forms.Button btKnight;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer_increase_money;
        private System.Windows.Forms.Button btHealingSpell;
    }
}

