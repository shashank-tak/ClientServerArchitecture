using System.Collections.Generic;
using ITTSportsCarnivalApp.Models;
using ITTSportsCarnivalApp.RepositoryInterfaces;
using ITTSportsCarnivalApp.Repository;
using ITTSportsCarnivalApp.DataConverter;
using ENUM;
using log4net;
using System.IO;
using Exceptions;

namespace ITTSportsCarnivalApp.Controllers
{
    public class TeamService : ITeamService
    {
        ITeamRepo _teamRepo = new TeamRepo();
        DataConverterClass _dataConverterClass = new DataConverterClass();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(TeamService));
        public int getTeamPlayersForGame(GameModel game)
        {
    
            var playerCount = 0;
            if (game.gameType == (int)GameType.Cricket)
            {
                playerCount = (int)GameRule.CricketCount;
                return playerCount;
            }
            else if (game.gameType == (int)GameType.Badminton)
            {
                playerCount = (int)GameRule.BadmintonCount;
                return playerCount;
            }
            else if (game.gameType == (int)GameType.Chess)
            {
                playerCount = (int)GameRule.ChessCount;
                return playerCount;
            }
            return 0;
        }

        public int CreateTeam(GameModel game, string filePath)
        {
            var playerRequired = getTeamPlayersForGame(game);
            if (game.players.Count % playerRequired != 0)
            {
                throw new NotRequiredPlayerRegistered();
            }
            TeamListModel teamsList = new TeamListModel();
            TeamModel teams = new TeamModel(game.gameType);
            int playerCount = 1, asciiNo = 65; 
            foreach (var player in game.players)
            {
                PlayerModel candidate = new PlayerModel(player.playerId, player.name);
                teams.team.Add(candidate);
                if (playerCount == playerRequired)
                {
                    teamsList.teamList.Add(new TeamModel(teams.gameType) { teamName = "Team - "+ (char)(asciiNo), gameType = teams.gameType ,team = teams.team});
                    teamsList.totalTeams = teamsList.totalTeams + 1;
                    teams = new TeamModel(game.gameType);
                    playerCount = 0;
                    asciiNo = asciiNo + 1;
                }
                playerCount = playerCount + 1;
            }
            _dataConverterClass.SerializeJsonIntoObjects<TeamListModel>(filePath, teamsList);
            return _teamRepo.AddTeam(teamsList);
        }
        public int GetTeams(int gameTypeId, string outputFilePath)
        {
            var Teams = _teamRepo.GetTeams(gameTypeId);
            File.WriteAllText(outputFilePath, "");
            if (Teams != null)
            {
                foreach (var x in Teams)
                {
                    File.AppendAllText(outputFilePath, "TeamId: " + x.teamId + " " + "TeamName: " + x.teamName + "\n");
                }
                _logger.Info("Retrieved Teams data.");
                return 1;
            }
            else
            {
                _logger.Info("No Teams Found for Game Type: " + gameTypeId);
                return 0;
            }
        }
    }
}
