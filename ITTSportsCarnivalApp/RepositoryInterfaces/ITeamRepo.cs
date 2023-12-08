using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITTSportsCarnivalApp.Models;

namespace ITTSportsCarnivalApp.RepositoryInterfaces
{
    interface ITeamRepo
    {
        int AddTeam(TeamListModel teamList);
        List<TeamModel> GetTeams(int gameTypeId);
    }
}
