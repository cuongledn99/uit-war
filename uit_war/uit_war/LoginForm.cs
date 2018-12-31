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
                sqlcmd = "update users set isLoggedIn=0 where username='" + txtboxUsername.Text + "'";
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
            Process.Start("https://www.facebook.com/dialog/oauth?client_id=2017210028392743&redirect_uri=https://lephamhuycuong.000webhostapp.com/callback.php&scope=public_profile&state=" + txtboxMyIP.Text);
            Thread thread = new Thread(()=> {
                RequestUntilHaveURL();
                DeteleUsedURL();
                Const.access_token = GetToken(Const.requestURL);
                ShowUsernameAfterFBLogin();
                EnableAllButton();
                txtboxMyIP.Enabled = true;
                txtboxRivalIP.Enabled = true;
            });
            thread.IsBackground = true;
            thread.Start();
        }
        private void DeteleUsedURL()
        {
            HttpRequest httpClient = new HttpRequest();
            string url = "http://lephamhuycuong.000webhostapp.com/api.php/deleteURL";
            string data = "{\"ip\":\"" + txtboxMyIP.Text + "\"}";
            string content_type = "application/json";
            httpClient.Post(url, data, content_type);
        }
        private void ShowUsernameAfterFBLogin()
        {
            try
            {
                string[] userinfo = GetUserInfo(Const.access_token);
                txtboxUsername.Text = userinfo[1];
            }
            catch ( Exception)
            {
                Thread.Sleep(500);
                ShowUsernameAfterFBLogin();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns>
        /// arr[0]=user_id
        /// arr[1]=username
        /// </returns>
        private string[] GetUserInfo(string access_token)
        {
            HttpRequest httpClient = new HttpRequest();
            string result = httpClient.Get("https://graph.facebook.com/me?access_token="+access_token, null).ToString();
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            string[] userinfo = new string[2];
            userinfo[0] = data["id"];
            userinfo[1] = data["name"];
            return userinfo;
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
                Const.requestURL= data[txtboxMyIP.Text];
                EnableAllButton();
                txtboxMyIP.Enabled = true;
                txtboxRivalIP.Enabled = true;
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                RequestUntilHaveURL();
            }
        }
    }

}
