using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace uit_war
{
    class Client:MainGameForm
    {
        private Socket client;
        public void CreateClient()
        {
             client = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        }
        public bool ConnectServer(IPAddress ip,int port)
        {
            IPEndPoint iep = new IPEndPoint(ip, port);
            while (client.Connected!=true)
            {
                try
                {
                    client.Connect(iep);
                    return true;
                }
                catch (Exception)
                {
                    //Console.WriteLine("Can not connect to server");
                    return false;
                }
            }
            return false;
        }
        public bool Send(int x,int y)
        {
            int[] location = { x, y };
            byte[] dataToSend = Both.SerializeData(location);
            try
            {
                client.Send(dataToSend);
                return true;
            }
            catch(Exception)
            {
                //Console.WriteLine("Can not send message");
                return false;
            }
        }
        public new bool Show()
        {
            byte[] dataReceived = new byte[1024];
            try
            {
                int recv = client.Receive(dataReceived);
                if (recv > 0)
                {
                    int[] location = (int[])Both.DeserializeData(dataReceived);
                    //set server's archer location
                    return true;
                }
                //else
                //{
                //    Console.WriteLine("Connection lost!!! no mess to show");
                //    return false;
                //}
            }
            catch
            {
                //Console.WriteLine("Connection lost!!!catch");
                return false;
            }
            return false;
        }
        public bool isConnectedToServer()
        {
            try
            {
                client.Connect(Const.IP, Const.PORT);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
