﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uit_war
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
         public static SocketManager socket;
        public static bool isServer = false;
        public static LoginForm login;
        public static MainGameForm main;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                login = new LoginForm();
                main = new MainGameForm();
                //socket
                socket = new SocketManager();
                //
                //login.ShowDialog();
                Application.Run(login);
            }
            catch
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng kiểm tra lại kết nối và khởi động lại game !!!");
                Application.Exit();
            }
        }
    }
}
