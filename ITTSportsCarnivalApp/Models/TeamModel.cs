using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTSportsCarnivalApp.Models
{
    public class TeamModel
    {
        public TeamModel(int GameType)
        {
            team = new List<PlayerModel>();
            gameType = GameType;
        }
        public int teamId { get; set; }
        public string teamName { get; set; }
        public int gameType { get; set; }
        public List<PlayerModel> team { get; set; }
    }
    public class TeamListModel
    {
        public TeamListModel()
        {
            teamList = new List<TeamModel>();
            totalTeams = 0;
        }
        public List<TeamModel> teamList {get; set;}
        public int totalTeams { get; set; }
    }
}
