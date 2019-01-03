using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using xNet;

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
            String sqlQuery = "select * from users where id='" + username + "'";
            SQLConnection connection = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
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


            ////////////////

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
            txtboxDatabaseIP.Text = SocketManager.GetLocalIPv4_v2();
            Const.serverIP = SocketManager.GetLocalIPv4_v2();
            Const.myIP = SocketManager.GetLocalIPv4_v2();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //logout current user
            string sql = "update users set isLoggedIn=0 where id='" + Const.userInfo[0] + "'";
            SQLConnection conn = new SQLConnection(SQLConnection.GetDatabasePath(txtboxDatabaseIP.Text + ",6969", "doan", "admin", "cuong123"));
            conn.AddRemoveAlter(sql);
            conn.Close();
            Application.Exit();
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
            if (string.IsNullOrEmpty(txtboxUsername.Text))
            {
                txtboxUsername.Enabled = false;
                //DisableAllButton();
                btFindMatch.Enabled = false;
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
                btFindMatch.Enabled = false;
            else
                btFindMatch.Enabled = true;
        }

        private void btDangki_Click(object sender, EventArgs e)
        {
            if (IsValidUsername(txtboxID.Text))
            {
                string sql = String.Format("insert into users values(N'{0}',N'{1}',N'{2}',{3},{4},'{5}',0)", txtboxID.Text, txtboxID.Text, txtboxPassword.Text, 0, 0, Const.myIP);
                SQLConnection connection = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
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
            string sql = "select name,isLoggedIn from users where id='" + txtboxID.Text + "' and password='" + txtboxPassword.Text + "'";
            SQLConnection connection = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
            SqlDataReader reader = connection.Query(sql);

            if (reader.HasRows && reader.Read() && reader.GetInt32(1) == 0)
            {
                SQLConnection conn = new SQLConnection(SQLConnection.GetDatabasePath(txtboxDatabaseIP.Text + ",6969", "doan", "admin", "cuong123"));

                //try to logout current user
                string sqlcmd = "update users set isLoggedIn=0 where id='" + Const.userInfo[0] + "'";
                conn.AddRemoveAlter(sqlcmd);
                //store new user info 
                Const.userInfo[0] = Const.userInfo[1] = reader.GetString(0);
                // update login status for new user
                sqlcmd = "update users set isLoggedIn=1 where id='" + Const.userInfo[0] + "'";
                conn.AddRemoveAlter(sqlcmd);

                //
                MessageBox.Show("Đăng nhập thành công");
                txtboxUsername.Text = txtboxID.Text;
                txtboxID.Text = "";
                txtboxPassword.Text = "";
                //txtboxRivalIP.Enabled = true;
                //btCreateRoom.Enabled = true;
                //btEnterRoom.Enabled = true;
                btFindMatch.Enabled = true;
                conn.Close();

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
        private void btShare_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["access_token"] = "2017210028392743|b6ca22605f1deda41ac0df3b7fda5ba0";
                values["href"] = "https://sites.google.com/a/gm.uit.edu.vn/uit-war/";

                var response = client.UploadValues("https://graph.facebook.com/device/share", values);
                var responseString = Encoding.Default.GetString(response);
                Dictionary<string, string> user_code = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
                DialogResult res = MessageBox.Show("Vui lòng đi đến liên kết này " + "https://www.facebook.com/device \n Nhập mã " + user_code["user_code"] + " để chia sẻ \n Bấm OK để copy mã và tự động chuyển đến liên kết", "Chia sẻ bằng Facebook", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    Clipboard.SetText(user_code["user_code"]);
                    System.Diagnostics.Process.Start("https://www.facebook.com/device");
                }
            }
        }

        //login by facebook
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/dialog/oauth?client_id=2017210028392743&redirect_uri=https://lephamhuycuong.000webhostapp.com/callback.php&scope=public_profile&state=" + Const.myIP);
            Thread thread = new Thread(() =>
            {
                RequestUntilHaveURL();
                DeteleUsedURL();
                Const.access_token = GetToken(Const.requestURL);
                GetUserInfo(Const.access_token);
                LoginByFBId(Const.userInfo);
            });
            thread.IsBackground = true;
            thread.Start();
        }
        private void LoginByFBId(string[] userInfo)
        {
            //try to insert new id
            SQLConnection connection = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
            string sql = string.Format("insert into users values(N'{0}',N'{1}',N'{2}',{3},{4},'{5}',{6})", userInfo[0], userInfo[1], "1", "0", "0", Const.IP, "0");
            connection.AddRemoveAlter(sql);
            connection.Close();
            //login
            connection = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
            sql = string.Format("select name from users where id='{0}' and password='1' and isLoggedIn=0", Const.userInfo[0]);
            SqlDataReader reader = connection.Query(sql);
            if (reader.HasRows)
            {
                reader.Read();
                txtboxUsername.Text = reader.GetString(0);//show name
                //create new connection to update user status
                SQLConnection conn = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
                sql = string.Format("update users set isLoggedIn=1 where id='{0}'", Const.userInfo[0]);
                conn.AddRemoveAlter(sql);
                conn.Close();
                btFindMatch.Enabled = true;
            }
            else
                MessageBox.Show("Tài khoản đang được đăng nhập ở nơi khác !!!");
            connection.Close();
        }
        private void DeteleUsedURL()
        {
            HttpRequest httpClient = new HttpRequest();
            string url = "http://lephamhuycuong.000webhostapp.com/api.php/deleteURL";
            string data = "{\"ip\":\"" + Const.myIP + "\"}";
            string content_type = "application/json";
            httpClient.Post(url, data, content_type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns>
        /// arr[0]=user_id
        /// arr[1]=username
        /// </returns>
        private void GetUserInfo(string access_token)
        {
            try
            {
                HttpRequest httpClient = new HttpRequest();
                string result = httpClient.Get("https://graph.facebook.com/me?access_token=" + access_token, null).ToString();
                Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                Const.userInfo[0] = data["id"];
                Const.userInfo[1] = data["name"];
            }
            catch
            {
                Thread.Sleep(100);
                GetUserInfo(access_token);
            }
        }
        private string GetToken(string requestURL)
        {
            HttpRequest httpClient = new HttpRequest();
            string result = httpClient.Get(requestURL, null).ToString();
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            return data["access_token"];
        }
        private void RequestUntilHaveURL()
        {
            try
            {
                HttpRequest httpClient = new HttpRequest();
                string result = httpClient.Get("http://lephamhuycuong.000webhostapp.com/api.php/requestURL", null).ToString();
                Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                Const.requestURL = data[Const.myIP];
                //EnableAllButton();
                btFindMatch.Enabled = true;
                
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                RequestUntilHaveURL();
            }
        }

        private void txtboxDatabaseIP_TextChanged(object sender, EventArgs e)
        {
            Const.serverIP = txtboxDatabaseIP.Text;
        }

        private void btFindMatch_Click(object sender, EventArgs e)
        {
            //update ip, isFindingMatch in database
            SQLConnection conn = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
            string sql = string.Format("update users set currentIP='{0}',isFindingMatch=1 where id='{1}'", Const.IP, Const.userInfo[0]);
            conn.AddRemoveAlter(sql);

            //search available room in database --> connect
            sql = string.Format("select top 1 currentIP from users where isFindingMatch=1 and id!='{0}'",Const.userInfo[0]);
            SqlDataReader reader= conn.Query(sql);
            if(reader.HasRows)//connect
            {
                reader.Read();
                string rivalIP = reader.GetString(0);
                try
                {
                    SocketManager.ConnectServer(rivalIP, 9999);
                    Program.socket.isServer = false;
                    Program.main = new MainGameForm();
                   // Program.main.Text = "client";
                    Program.login.Hide();
                    Program.main.Show();

                    Const.currentTeam = false;//right team
                    ////set isFindingMatch to false
                    //sql = string.Format("update users set isFindingMatch=0 where id='{0}'",Const.userInfo[0]);
                    //conn.AddRemoveAlter(sql);
                }
                catch (Exception)
                {
                    MessageBox.Show("Trận đấu chưa được tạo !!!");
                }
            }
            else// create server and wait if db has no available room
            {
                ////////////////

                Const.username = txtboxUsername.Text;

                try
                {
                    Program.socket.isServer = true;
                    Program.socket.CreateServer();
                    ///
                    Program.main = new MainGameForm();
                    //Program.main.Text = "server";
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
                   // Program.main.Text = "server";
                    Program.login.Hide();
                    Program.main.Show();

                    Const.currentTeam = true;//left team
                }
            }
            conn.Close();
            
        }
    }

}
