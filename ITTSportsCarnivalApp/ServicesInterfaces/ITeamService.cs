using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITTSportsCarnivalApp.Models;

namespace ITTSportsCarnivalApp.Controllers
{
    interface ITeamService
    {
        int CreateTeam(GameModel game, string filePath);
        int GetTeams(int gameTypeId, string filePath);
    }
}
