using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Arcomage_alpha3
{
    class NetManO2O
    {
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        //protected Socket client;
        //protected Socket serverIn;
        protected IPEndPoint ep;
        public static bool online = false;
        private const int BufferSize = 256;
        private byte[] buffer = new byte[BufferSize];
        private string answer = "";
        private string type = "";
        private static Socket sendOponent;

        //events
        public delegate void MethodOnConnect();
        public delegate void MethodOnRecieve();
        public delegate void MethodOnSend();
        public delegate void MethodOnDisconnect();
        public event MethodOnConnect onConnect;
        public event MethodOnRecieve onRecieve;
        public event MethodOnSend onSend;
        public event MethodOnDisconnect onDisconnect;


        public void CreateServer(int port = 12345)
        {
            type = "server";
            ep = new IPEndPoint(IPAddress.Any, port);
            Socket serverIn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverIn.Bind(ep);
            serverIn.Listen(1);
            while (!online)
            {
                //Console.WriteLine("Loop In");
                allDone.Reset();
                serverIn.BeginAccept(new AsyncCallback(ServerRecieveConnectionCallback), serverIn);
                allDone.WaitOne();
                //Console.WriteLine("Loop out");
            }
        }

        public void CreateClient(string ip, int port = 12345)
        {
            type = "client";
            ep = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sendOponent = client;
            client.BeginConnect(ep, new AsyncCallback(ClientConnectCallback), client);
            connectDone.WaitOne();
            //
        }

        public void ServerRecieveConnectionCallback(IAsyncResult ar)
        {
            //
            allDone.Set();
            Socket serverIn = (Socket)ar.AsyncState;
            Socket client = serverIn.EndAccept(ar);
            sendOponent = client;
            online = true;
            if (onConnect != null)
                onConnect();

            client.BeginReceive(buffer, 0, BufferSize, 0, new AsyncCallback(ReadCallback), client);
        }

        public void ClientConnectCallback(IAsyncResult ar)
        {
            //
            Socket client = (Socket)ar.AsyncState;
            client.EndConnect(ar);
            connectDone.Set();
            online = true;
            //Console.WriteLine("Connected client");
            if (onConnect != null)
                onConnect();

            client.BeginReceive(buffer, 0, BufferSize, 0, new AsyncCallback(ReadCallback), client);
            receiveDone.WaitOne();
        }

        public void ReadCallback(IAsyncResult ar)
        {
            //String content = String.Empty;
            Socket client = (Socket)ar.AsyncState;
            int bytesLength = 0;
            try
            {
                bytesLength = client.EndReceive(ar);//Disconect exception
            }
            catch (Exception)
            {
                global::System.Windows.MessageBox.Show("Disconected");
                return;
            }
            if (bytesLength > 0)
            {
                answer = Encoding.ASCII.GetString(buffer, 0, bytesLength);
            }
            int summBytes = getSummOfBytes(buffer);
            if (summBytes == 0)
            {
                Disconnect(true);
            }
            else
            {
                if (onRecieve != null)
                    onRecieve();
            }
            if (type == "client")
            {
                receiveDone.Set();
            }

            if (online)
            {
                client.BeginReceive(buffer, 0, BufferSize, 0, new AsyncCallback(ReadCallback), client);
                receiveDone.WaitOne();
            }
        }

        public void SendCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            sendDone.Set();
            if (onSend != null)
                onSend();
        }

        public void Send(byte[] byteData)
        {
            //byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            sendOponent.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), sendOponent);
            sendDone.WaitOne();
        }

        public void Disconnect(bool isNetMessage = false)
        {

            if (!isNetMessage && online)
            {
                byte[] zeroBytes = new byte[BufferSize];
                for (int i = 0; i < BufferSize; i++)
                {
                    zeroBytes[i] = 0;
                }
                Send(zeroBytes);
            }
            online = false;
            if (onDisconnect != null)
                onDisconnect();
        }

        private int getSummOfBytes(byte[] bytes)
        {
            int summ = 0;
            for (int i = 0; i < BufferSize; i++)
            {
                summ += bytes[i];
            }
            return summ;
        }
        public void SendStr(string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            Send(byteData);
        }


        //helpers
        public byte[] getBytes()
        {
            return buffer;
        }

        public override string ToString()
        {
            return answer;
        }

        public bool isOnline()
        {
            return online;
        }

        public string getType()
        {
            return type;
        }
    }
}
