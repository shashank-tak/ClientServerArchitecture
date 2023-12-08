using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTSportsCarnivalApp.Models
{
    class Response
    {
        public Response()
        {
            Type = "Error";
            Message = "Failed To Save: Invalid Data";
        }
        public string Type;
        public string Message;
    }
}
