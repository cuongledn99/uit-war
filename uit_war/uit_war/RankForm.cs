using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uit_war
{
    public partial class RankForm : Form
    {
        //xac dinh duong dan den database
        //public string GetDatabasePath(string servername,string databasename,string username,string password)
        //{
        //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        //    //builder.DataSource = "192.168.137.1,6969";
        //    //builder.InitialCatalog = "doan";
        //    //builder.UserID = "admin";
        //    //builder.Password = "cuong123";
        //    builder.DataSource = servername;
        //    builder.InitialCatalog = databasename;
        //    builder.UserID = username;
        //    builder.Password = password;
        //    return builder.ToString();
        //}
            
        public RankForm()
        {
            InitializeComponent();
        }
        
        private void RankForm_Load(object sender, EventArgs e)
        {
            LoadDataToTable(Const.serverIP);
        }
        private void LoadDataToTable(string databaseIP)
        {
            //Chuan bi cau lenh query viet bang SQL
            String sqlQuery = "select top 5 name,won_matchs from users order by won_matchs desc";
            SQLConnection connection = new SQLConnection(SQLConnection.GetDatabasePath(databaseIP+",6969","doan","admin","cuong123"));
            SqlDataReader reader = connection.Query(sqlQuery);
            lbTitle.Font= new Font("Arial", 22);
            lbTitle.ForeColor = Color.Yellow;
            lbTitle.Location = new Point((this.ClientSize.Width - lbTitle.Width) / 2, 0);
            lbTitle.BackColor = Color.Transparent;
            int y = 40;
            while (reader.HasRows)//con dong du lieu thi doc tiep
            {
                if (reader.Read() == false)
                    return;//doc ko duoc thi return
                           //dataGridView1.Rows.Add(reader.GetString(0), reader.GetInt32(1));
                Label labelName = new Label();
                labelName.Location = new Point(20, y);
                labelName.Font= new Font("Arial", 22);
                labelName.Size = new Size(labelName.Width + 100, labelName.Height+20);
                labelName.Text = reader.GetString(0);
                labelName.BackColor = Color.Transparent;
                labelName.ForeColor = Color.White;
                Label lbScore = new Label();
                lbScore.Location = new Point(labelName.Location.X+labelName.Width, y);
                lbScore.Font= new Font("Arial", 22);
                lbScore.Size = new Size(lbScore.Width+10, lbScore.Height + 20);
                lbScore.RightToLeft = RightToLeft.Yes;
                lbScore.Text = reader.GetInt32(1).ToString();
                lbScore.BackColor = Color.Transparent;
                lbScore.ForeColor = Color.White;
                Controls.Add(labelName);
                Controls.Add(lbScore);
                y += labelName.Height;
            }
            connection.Close();
        }

        
    }
}
