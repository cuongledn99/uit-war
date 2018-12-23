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

    public partial class LoginForm : Form
    {
        public static bool isServer = false;
        
        public LoginForm()
        {
            InitializeComponent();
            //no care
            Control.CheckForIllegalCrossThreadCalls = false;

            
        }
        // tạo phòng
        private void connect_Click(object sender, EventArgs e)
        {
            #region mycode
            //Const.client.CreateClient();
            ////server
            //if (!Const.client.isConnectedToServer())
            //{
            //    isServer = true;
            //    Const.server.CreateServer(Const.IP, Const.PORT);

            //    Const.server.WaitingConnection();
            //    Form1 f1 = new Form1();
            //    f1.Text = "server";
            //    f1.Show();
            //    this.Hide();
            //    //Thread task1 = new Thread(() =>
            //    //{
            //    //    while (true)
            //    //    {
            //    //        server.Show();
            //    //    }
            //    //});
            //    //task1.Start();

            //    //while (true)
            //    //{
            //    //    server.Send();
            //    //}
            //}
            ////client
            //else
            //{
            //    isServer = false;
            //    Const.client.ConnectServer(Const.IP, Const.PORT);
            //    Form1 f1 = new Form1();
            //    f1.Text = "client";
            //    f1.Show();
            //    this.Hide();
            //    //Thread task2 = new Thread(() =>
            //    //{
            //    //    while (true)
            //    //    {
            //    //        client.Show();
            //    //    }
            //    //});
            //    //task2.Start();
            //    //while (true)
            //    //{
            //    //    client.Send(20, 20);
            //    //}
            //}

            ////////////////
            #endregion

            //if server is not exist
            //create server
            //waiting for connect from client
            //if (!Program.socket.ConnectServer())
            // {
            try
            {
               // SocketManager.CloseConnection();
                Program.socket.isServer = true;
                Program.socket.CreateServer();
                ///
                Program.main = new MainGameForm();
                Program.main.Text = "server";
                Program.login.Hide();
                Program.main.Show();

                Const.currentTeam = true;//left team 
            }
            catch
            {
                Program.socket = null;
                Program.socket = new SocketManager();
                Program.socket.isServer = true;
                Program.socket.CreateServer();
                ///
                Program.main = new MainGameForm();
                Program.main.Text = "server";
                Program.login.Hide();
                Program.main.Show();

                Const.currentTeam = true;//left team
            }
            //}
            ////client
            //else
            //{
            //    Program.socket.isServer = false;
            //    ///
            //    Program.login.Close();
            //    Program.main.Text = "client";
            //    Const.currentTeam = false;//right team
            //}
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtboxMyIP.Text = SocketManager.GetLocalIPv4_v2();
        }

        private void btEnterRoom_Click(object sender, EventArgs e)
        {
            try
            {
                //SocketManager.CloseConnection();
                SocketManager.ConnectServer(txtboxRivalIP.Text, 9999);
                Program.socket.isServer = false;
                //Program.login.Close();
                Program.main = new MainGameForm();
                Program.main.Text = "client";
                Program.login.Hide();
                Program.main.Show();

                Const.currentTeam = false;//right team
            }
            catch
            {
                SocketManager.ConnectServer(txtboxRivalIP.Text, 9999);
                Program.socket.isServer = false;
                //Program.login.Close();
                Program.main = new MainGameForm();
                Program.main.Text = "client";
                Program.login.Hide();
                Program.main.Show();

                Const.currentTeam = false;//right team
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtboxMyIP.Text);
        }




        private void InitProperties()
        {
            Const.listSpells = new List<Spell>();
            Const.listSpells.Clear();
            Const.listTrops = new List<Trop>();
            Const.listTrops.Clear();
            Const.spriteAvailableMoney = Const.spriteMoney0;
        }
        private void LoginForm_Activated(object sender, EventArgs e)
        {
            InitProperties();
            SocketManager.CloseConnection();
        }
    }
}
