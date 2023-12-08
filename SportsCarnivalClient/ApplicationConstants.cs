using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCarnivalClient
{
    public static class ApplicationConstants
    {
        public const string createTeam = "isc -a create_team -i <json_input_file> -o <json_output_file>";
        public const string getTeam = "isc - a get_team -o <json_output_file>";
        public const string createTeamAction = "create_team";
        public const string getRequest = "Not a post request!";
    }
}
