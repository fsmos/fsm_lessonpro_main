using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace LessonProScanConnect
{
    public class ConnectScanServer
    {
        public static void Connect(string ip,int port,int id)
        {
            IPAddress localAddress = IPAddress.Parse(ip);
            System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEndpoint = new IPEndPoint(localAddress, port);
            listenSocket.Connect(ipEndpoint);
            byte[] file = new byte[2];
            file[1] = System.Convert.ToByte(id / 255);
            file[0] = System.Convert.ToByte(id % 255);
            listenSocket.Send(file);
            listenSocket.Close();
        }
    }
}
