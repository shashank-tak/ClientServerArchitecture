using ITTSportsCarnivalApp.Controllers;
using System;
using ITTSportsCarnivalApp.Models;
using ITTSportsCarnivalApp.DataConverter;
using System.IO;
using System.Collections.Generic;
using Exceptions;
using log4net;

namespace ITTSportsCarnivalApp.Controllers
{
    public class EventManagerController : DataConverterClass
    {
        ITeamService _teamService = new TeamService();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(EventManagerController));
        DataConverterClass _dataConverterClass = new DataConverterClass();
        public int CreateTeamForEvents(GameModel game, string filePath)
        {
            try
            {
                if (!ValidateGameModel(game))
                {
                    _dataConverterClass.SerializeJsonIntoObjects(filePath, new Response());
                    throw new InvalidPlayerData();
                }
                if (filePath.Length == 0)
                {
                    _dataConverterClass.SerializeJsonIntoObjects(filePath, new Response());
                    throw new InvalidFilePath();
                }
                var result = _teamService.CreateTeam(game, filePath);
                return result;
            }
            catch(InvalidPlayerData ex)
            {
                _logger.Error("Invalid player data passed. Error Message: " +ex.Message);
                return 0;
            }
            catch(InvalidFilePath ex)
            {
                _logger.Error("Invalid file path given. Error Message: " + ex.Message);
                return 0;
            }
            catch(NotRequiredPlayerRegistered ex)
            {
                _logger.Error(ex.Message);
                return 0;
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return 0;
            }

        }
        public bool ValidateGameModel(GameModel game)
        {
            if (game.players.Count == 0)
            {
                return false;
            }
            return true;
        }

        public int GetTeams(int gameTypeId, string outputFilePath)
        {
            try
            {
                if (!ValidateGameType(gameTypeId))
                {
                    throw new InvalidGameType();
                }
                return _teamService.GetTeams(gameTypeId, outputFilePath);
            }
            catch (InvalidGameType ex)
            {
                _logger.Error(ex.Message);
                return ex.HResult;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return ex.HResult;
            }
        }
        public bool ValidateGameType(int gameTypeId)
        {
            foreach (var game in ApplicationConstants.gameTypes)
            {
                if (game == gameTypeId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
