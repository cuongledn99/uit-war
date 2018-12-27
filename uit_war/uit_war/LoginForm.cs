using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uit_war
{

    public partial class LoginForm : Form
    {
        public static bool isServer = false;
        //public SoundPlayer Mcd = new SoundPlayer("Resources\\noel.wav");
        public LoginForm()
        {
            InitializeComponent();
            //no care
            Control.CheckForIllegalCrossThreadCalls = false;
            //axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Resources\\noel.wav";
            //axWindowsMediaPlayer1.settings.autoStart = true;
            //axWindowsMediaPlayer1.settings.setMode("loop", true);
        }
        bool IsValidUsername(string username)
        {
            //Chuan bi cau lenh query viet bang SQL
            String sqlQuery = "select * from users where username='" + username + "'";
            SQLConnection connection = new SQLConnection(SQLConnection.GetDatabasePath(txtboxDatabaseIP.Text + ",6969", "doan", "admin", "cuong123"));
            SqlDataReader reader = connection.Query(sqlQuery);
            if (reader.HasRows)
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
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
            Const.username = txtboxUsername.Text;

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


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           // Mcd.PlayLooping();
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
            catch (Exception)
            {
                MessageBox.Show("Trận đấu chưa được tạo !!!");
            }

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //logout current user
            string sql = "update users set isLoggedIn=0 where username='" + txtboxUsername.Text + "'";
            SQLConnection conn = new SQLConnection(SQLConnection.GetDatabasePath(txtboxDatabaseIP.Text + ",6969", "doan", "admin", "cuong123"));
            conn.AddRemoveAlter(sql);
            conn.Close();
            Application.Exit();
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtboxMyIP.Text);
        }


        private void EnableAllButton()
        {
            btEnterRoom.Enabled = true;
            btCreateRoom.Enabled = true;
        }
        private void DisableAllButton()
        {
            btCreateRoom.Enabled = false;
            btEnterRoom.Enabled = false;
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
            if (string.IsNullOrEmpty(Const.username))
            {
                txtboxUsername.Enabled = false;
                txtboxDatabaseIP.Text = txtboxMyIP.Text;
                txtboxMyIP.Enabled = false;
                txtboxRivalIP.Enabled = false;
                DisableAllButton();
                InitProperties();
            }
            SocketManager.CloseConnection();
        }

        private void btRank_Click(object sender, EventArgs e)
        {
            Const.serverIP = txtboxDatabaseIP.Text;
            RankForm rankForm = new RankForm();
            rankForm.ShowDialog();
        }

        private void lbMyIP_Click(object sender, EventArgs e)
        {

        }

        private void txtboxUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtboxUsername.Text.ToString() == "")
                DisableAllButton();
            else
                EnableAllButton();
        }

        private void btDangki_Click(object sender, EventArgs e)
        {
            if (IsValidUsername(txtboxID.Text))
            {
                string sql = String.Format("insert into users values('{0}','{1}','{2}',{3})", txtboxID.Text, txtboxPassword.Text, 0, 0);
                SQLConnection connection = new SQLConnection(SQLConnection.GetDatabasePath(txtboxDatabaseIP.Text + ",6969", "doan", "admin", "cuong123"));
                connection.AddRemoveAlter(sql);
                connection.Close();
                MessageBox.Show("Đăng kí thành công");
            }
            else
            {
                MessageBox.Show("username đã tồn tại !!!");
            }
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string sql = "select username,isLoggedIn from users where username='" + txtboxID.Text + "' and password='" + txtboxPassword.Text + "'";
            SQLConnection connection = new SQLConnection(SQLConnection.GetDatabasePath(txtboxDatabaseIP.Text + ",6969", "doan", "admin", "cuong123"));
            SqlDataReader reader = connection.Query(sql);

            if (reader.HasRows && reader.Read() && reader.GetInt32(1) == 0)
            {
                //create new connection to update login status
                SQLConnection conn = new SQLConnection(SQLConnection.GetDatabasePath(txtboxDatabaseIP.Text + ",6969", "doan", "admin", "cuong123"));
                string sqlcmd = "update users set isLoggedIn=1 where username='" + reader.GetString(0) + "'";
                conn.AddRemoveAlter(sqlcmd);
                //try to logout current user
                sqlcmd= "update users set isLoggedIn=0 where username='" + txtboxUsername.Text+ "'";
                conn.AddRemoveAlter(sqlcmd);
                conn.Close();
                //
                MessageBox.Show("Đăng nhập thành công");
                txtboxUsername.Text = txtboxID.Text;
                txtboxID.Text = "";
                txtboxPassword.Text = "";
                txtboxRivalIP.Enabled = true;
                btCreateRoom.Enabled = true;
                btEnterRoom.Enabled = true;
                

                Const.username = txtboxUsername.Text;
                Const.serverIP = txtboxDatabaseIP.Text;
            }
            else if (reader.HasRows && reader.GetInt32(1) == 1)
            {
                MessageBox.Show("Tài khoản đang được đăng nhập ở nơi khác !!!");
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !!!");

            }
            connection.Close();

        }


    }




}
