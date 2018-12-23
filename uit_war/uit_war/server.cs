using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace uit_war
{
    class Server:MainGameForm
    {
        
        private Socket server;
        private Socket acceptClient;
        private int x=0;
        private int y=0;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public void CreateServer(IPAddress ip,int port)
        {
            //init socket
             server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //init IPEndPoint
            IPEndPoint iep = new IPEndPoint(ip, port);
            //bind
            server.Bind(iep);
        }
        public void WaitingConnection()
        {
            server.Listen(500);
            //Console.WriteLine("Waiting for connection from client...");
            acceptClient = server.Accept();
            //Console.WriteLine("Accept connection from: {0}", acceptClient.RemoteEndPoint.ToString());
        }
        
        public bool Send()
        {
            //int[] location = { this.archer_left.Location.X, this.archer_left.Location.Y };
            //byte[] dataToSend = Both.SerializeData(location);
            try
            {
                //acceptClient.Send(dataToSend);
                return true;
            }
            catch (Exception)
            {
               // Console.WriteLine("Can not send message");
                return false;
            }
        }
        public new bool Show()
        {
            byte[] dataReceived=new byte[1024];
            try
            {
                int recv = acceptClient.Receive(dataReceived);
                if (recv > 0)
                {
                    int[] location=(int[])Both.DeserializeData(dataReceived);
                    //Console.SetCursorPosition(location[0], location[1]);
                    //Console.WriteLine("Client");
                    return true;
                }
                //else
                //{
                //    Console.WriteLine("Connection lost!!!");
                //    return false;
                //}
            }
            catch
            {
               // Console.WriteLine("@@@@@@@!!!");
                return false;
            }
            return false;
        }
       
        
        public bool SocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 && part2)
                return false;
            else
                return true;
        }
    }
}



