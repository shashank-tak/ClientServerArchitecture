using ITTSportsCarnivalApp.Models;
using ITTSportsCarnivalApp.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ITTSportsCarnivalApp.DBO;
using log4net;

namespace ITTSportsCarnivalApp.Repository
{
    class TeamRepo : ITeamRepo
    {
        DataBaseContext _dbContext = new DataBaseContext();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(TeamRepo));
        public int AddTeam(TeamListModel teamListModel)
        {
            foreach (var team in teamListModel.teamList)
            {
                Team addTeam = new Team()
                {
                    name = team.teamName,
                    eventId = 1,
                    gameId = team.gameType
                };
                _dbContext.Team.Add(addTeam);
            }
            return _dbContext.SaveChanges();
        }
        public List<TeamModel> GetTeams(int gameTypeId)
        {
            return _dbContext.Team.Where(x => x.gameId == gameTypeId).Select(type => new TeamModel
            {
                teamId = type.teamId,
                teamName = type.name
            }).ToList();
        }
    }
}
