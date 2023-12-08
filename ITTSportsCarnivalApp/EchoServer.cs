using CommunicationProtocolProject;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITTSportsCarnivalApp
{
    class EchoServer : Controllers.BaseController
    {
        private static readonly int Port = Convert.ToInt32(ConfigurationSettings.AppSettings["PORT"]);
        private static readonly IPAddress IP = IPAddress.Parse(ConfigurationSettings.AppSettings["IP"]);
        private static readonly TcpListener serverInstance = new TcpListener(IP, Port);
        private static readonly ILog _logger = LogManager.GetLogger(typeof(EchoServer));
        public void StartServer()
        {
            serverInstance.Start();
            Console.WriteLine("Server started on IP " + IP + " and port " + Port);
            while (true)
            {
                TcpClient client = serverInstance.AcceptTcpClient();
                _logger.Info("Client Registered at IP:" + IP);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Client connected from " + client.Client.RemoteEndPoint + "...");
                Thread thread = new Thread(new ParameterizedThreadStart(HandleClient));
                thread.Start(client);
            }
        }

        private void HandleClient(object obj)
        {
            try
            {
                TcpClient client = (TcpClient)obj;
                NetworkStream stream = client.GetStream();
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string messageGot = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    var response = HandleRequest(messageGot, IP.ToString(), Port);
                    if (bytesRead == 0) break;
                    stream.Write(response, 0, response.Length);
                }
                stream.Close();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Client disconnected!");
                _logger.Info("Client disconnected.");
                client.Close();
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Connection forcibly closed.");
            }
            
        }
    }
}
