using ITTSportsCarnivalApp.Models;
using ITTSportsCarnivalApp.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITTSportsCarnivalApp.Controllers;

namespace ITTSportsCarnivalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EchoServer _echoServer = new EchoServer();
            _echoServer.StartServer();
        }
    }
}
