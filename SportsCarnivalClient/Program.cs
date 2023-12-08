using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCarnivalClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client _echoClient = new Client();
            _echoClient.StartClient();
        }
    }
}
