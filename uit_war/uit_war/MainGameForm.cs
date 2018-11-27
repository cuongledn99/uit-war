using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uit_war
{
    public partial class MainGameForm : Form
    {
        #region Properties
        CurrentTrop currentTrop;
        List<Trop> listTrops = new List<Trop>();
        List<Trop> listRivalTrops = new List<Trop>();
        int a = 0;
        int s = 0;
        #endregion

        public MainGameForm()
        {
            InitializeComponent();
            //no care
            Control.CheckForIllegalCrossThreadCalls = false;
            
            Listen();
            timer1.Start();
        }

        private void archer_left_Click(object sender, EventArgs e)
        {

        }


        #region mẹthod


        
        public void MoveTrops()
        {
            
            for(int i=0;i<listTrops.Count;i++)
            {
                listTrops[i].Move();
            }
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ////move picture to right
            //this.archer_left.Location = new Point(this.archer_left.Location.X + 5, this.archer_left.Location.Y);
            ////send picture position to rival
            //Program.socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", this.archer_left.Location));
            //Listen();
            /////////////////////////


            //show picture at clicked position
            a=a-s;
            Trop trop=null;
            switch(currentTrop)
            {
                case CurrentTrop.Tank:
                    trop = new Tank();
                    break;
                case CurrentTrop.Archer:
                    trop = new Archer();
                    break;
                case CurrentTrop.Minion:
                    trop = new Minion();
                    break;
            }
            trop.Picture.Location = new Point(e.X, e.Y);
            //send current trop type and its position to rival
            Program.socket.Send(new SocketData((int)SocketCommand.SEND_POINT, currentTrop, new Point(e.X, e.Y)));
            //add trop to form
            listTrops.Add(trop);
            this.Controls.Add(trop.Picture);
            ///////////////////////////////////
            
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult dlr =MessageBox.Show("DO YOU WANT TO EXIT !!!", "Warning", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        void ChessBoard_PlayerMarked(object sender, Point point)
        {
            
            //get it
            //socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", point));

            //Listen();
        }

      
        
        //get
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }
        //get


        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)Program.socket.Receive();

                    ProcessData(data);
                }
                catch (Exception e)
                {
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    break;
                case (int)SocketCommand.SEND_POINT:
                    //use,no care
                    this.Invoke((MethodInvoker)(() =>
                    {
                        
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    break;
                case (int)SocketCommand.END_GAME:
                    break;
                case (int)SocketCommand.QUIT:
                    break;
                default:
                    break;
            }

            Listen();
        }

        #endregion

        private void top_lane_Click(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameForm));

            PictureBox picture = new PictureBox();
            
            picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            picture.Image = ((System.Drawing.Image)(resources.GetObject("picture.Image")));
            picture.Location = new System.Drawing.Point(MousePosition.X, MousePosition.Y);
            picture.Name = "picture";
            picture.Size = new System.Drawing.Size(51, 50);
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picture);
        }

       private void MainGameForm_ControlAdded(object sender, ControlEventArgs e)
        {

            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    e.Control.Location = new Point(e.Control.Location.X + 4, e.Control.Location.Y);
                    //Thread.Sleep(2000);
                }
            });
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //max of money
            if (a < 10)
                a++;
            //progress of money
            if (a > 1) pictureBox1.Visible = true; else pictureBox1.Visible = false;
            if (a > 2) pictureBox2.Visible = true; else pictureBox2.Visible = false;
            if (a > 3) pictureBox3.Visible = true; else pictureBox3.Visible = false;
            if (a > 4) pictureBox4.Visible = true; else pictureBox4.Visible = false;
            if (a > 5) pictureBox5.Visible = true; else pictureBox5.Visible = false;
            if (a > 6) pictureBox6.Visible = true; else pictureBox6.Visible = false;
            if (a > 7) pictureBox7.Visible = true; else pictureBox7.Visible = false;
            if (a > 8) pictureBox8.Visible = true; else pictureBox8.Visible = false;
            if (a > 9) pictureBox9.Visible = true; else pictureBox9.Visible = false;
            if (a > 10) pictureBox10.Visible = true; else pictureBox10.Visible = false;
            try
            {
                MoveTrops();
            }
            catch { }
        }

        private void button_minion_clicked(object sender, EventArgs e)
        {
            s=1
            currentTrop = CurrentTrop.Minion;
        }

        private void button_archer_clicked(object sender, EventArgs e)
        {
            s=2
            currentTrop = CurrentTrop.Archer;
        }

        private void button_giant_clicked(object sender, EventArgs e)
        {
            s=3
            currentTrop = CurrentTrop.Tank;
        }
    }
}
