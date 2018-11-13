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
        #endregion
aaaa
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
            Application.Exit();
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

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                MoveTrops();
            }
            catch { }
        }

        private void button_minion_clicked(object sender, EventArgs e)
        {
            currentTrop = CurrentTrop.Minion;
        }

        private void button_archer_clicked(object sender, EventArgs e)
        {
            currentTrop = CurrentTrop.Archer;
        }

        private void button_giant_clicked(object sender, EventArgs e)
        {
            currentTrop = CurrentTrop.Tank;
        }
    }
}
