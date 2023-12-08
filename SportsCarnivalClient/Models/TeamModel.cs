using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCarnivalClient.Models
{
    class TeamModel
    {
        public int teamId { get; set; }
        public string teamName { get; set; }
        public List<PlayerModel> team { get; set; }
        public int gameType { get; set; }
    }
    class TeamListModel
    {
        public List<TeamModel> teamList {get; set;}
        public int totalTeams { get; set; }
    }
}
