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
            LoadDataToTable("192.168.137.1");
        }
        private void LoadDataToTable(string databaseIP)
        {
            //Chuan bi cau lenh query viet bang SQL
            String sqlQuery = "select username,won_matchs from users order by won_matchs desc";
            SQLConnection connection = new SQLConnection(SQLConnection.GetDatabasePath(databaseIP+",6969","doan","admin","cuong123"));
            SqlDataReader reader = connection.Query(sqlQuery);
            //Su dung reader de doc tung dong du lieu
            //va thuc hien thao tac xu ly mong muon voi du lieu doc len
            while (reader.HasRows)//con dong du lieu thi doc tiep
            {
                if (reader.Read() == false) return;//doc ko duoc thi return
                                                   //xu ly khi da doc du lieu len
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetInt32(1));
            }
            connection.Close();
        }
    }
}
