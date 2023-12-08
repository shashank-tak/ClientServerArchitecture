using SportsCarnivalClient.DataConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SportsCarnivalClient.Models;
using System.IO;
using CommunicationProtocolProject;
using Newtonsoft.Json;
using System.Configuration;
using log4net;

namespace SportsCarnivalClient
{
    class Client
    {
        private static readonly int PORT = Convert.ToInt32(ConfigurationSettings.AppSettings["PORT"]);
        private static readonly string IP = ConfigurationSettings.AppSettings["IP"];
        DataConverterClass _dataHandle = new DataConverterClass();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Client));
        public void StartClient()
        {
            TcpClient client = new TcpClient(IP, PORT);
            NetworkStream stream = client.GetStream();
            while (true)
            {
                Console.Write("Enter command with proper keywords for:\n1. Create Team - {0}\n2. Get Teams - {1}\n3. Type exit to stop.\nEnter choice:  ",ApplicationConstants.createTeam,ApplicationConstants.getTeam);
                string message = Console.ReadLine();
                if (message == "exit") break;
                var commandDetails = getDetailsFromCommand(message);
                var serverRequestMessage = convertIntoISCRequest(commandDetails, IP, PORT);
                stream.Write(serverRequestMessage, 0, serverRequestMessage.Length);
                byte[] serverResponseMessage = new byte[1024];
                int bytesRead = stream.Read(serverResponseMessage, 0, serverResponseMessage.Length);
                var finalMessage = ConvertIntoUserMessage(serverResponseMessage, bytesRead);
                Console.WriteLine(finalMessage);
            }
            stream.Close();
            client.Close();
        }

        private string ConvertIntoUserMessage(byte[] serverResponseMessage, int bytesRead)
        {
            var response = JsonConvert.DeserializeObject<ICSResponse>(Encoding.ASCII.GetString(serverResponseMessage, 0, bytesRead));
            var userMessage = JsonConvert.DeserializeObject<Response>(Encoding.ASCII.GetString(response.data, 0, response.size));
            return userMessage.Message;
        }

        private Request getDetailsFromCommand(string message)
        {
            string[] parts = message.Split(' ');
            Request _actionRequest = new Request();

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "-a")
                {
                    string action = parts[i + 1].Trim('\'');
                    _actionRequest.Action = action;
                    Console.WriteLine("Action: " + action);
                }
                else if (parts[i] == "-i")
                {
                    string inputPath = parts[i + 1].Trim('\'');
                    _actionRequest.requestData = inputPath;
                    Console.WriteLine("Input filepath: " + inputPath);
                }
                else if (parts[i] == "-o")
                {
                    string outputPath = parts[i + 1].Trim('\'');
                    _actionRequest.OutputFilePath = outputPath;
                    Console.WriteLine("Output filepath: " + outputPath);
                }
            }
            return _actionRequest;
        }

        private byte[] convertIntoISCRequest (Request request, string IP, int Port)
        {
            byte[] message = Encoding.ASCII.GetBytes(request.Action == ApplicationConstants.createTeamAction ? File.ReadAllText(request.requestData):ApplicationConstants.getRequest);
            ISCRequest _iscRequest = new ISCRequest()
            {
                size = message.Length,
                data = message,
                sourceIp = IP,
                sourcePort = Port,
                destIp = IP,
                destPort = Port,
                outputFilePath = request.OutputFilePath,
                action = request.Action

            };
            return Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(_iscRequest));
        }
    }
}
