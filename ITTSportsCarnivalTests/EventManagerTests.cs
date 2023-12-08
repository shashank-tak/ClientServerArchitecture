using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITTSportsCarnivalApp.Models;
using ITTSportsCarnivalApp.DataConverter;
using ITTSportsCarnivalApp.Controllers;
using System.Collections.Generic;

namespace ITTSportsCarnivalTests
{
    [TestClass]
    public class EventManagerTests
    {
        DataBaseContext _dbContext = new DataBaseContext();
        EventManagerController eventManagerController = new EventManagerController();

        [TestMethod]
        public void CreateTeam_WithValidData()
        {
            //Arrange
            var dataConverter = new DataConverterClass();
            string outputFilePath = "D://Team2Output.json";
            GameModel game = dataConverter.DeserializeJsonIntoObjects<GameModel>("D://Team1.json");

            //Act
            var result = eventManagerController.CreateTeamForEvents(game, outputFilePath);

            //Assert
            Assert.IsTrue(result > 0);

        }

        [TestMethod]
        public void CreateTeam_WithInValidPlayers()
        {
            //Arrange
            var dataConverter = new DataConverterClass();
            string outputFilePath = "D://Team2Output.json";
            GameModel game = dataConverter.DeserializeJsonIntoObjects<GameModel>("D://Team3.json");

            //Act
            var result = eventManagerController.CreateTeamForEvents(game, outputFilePath);

            //Assert
            Assert.IsTrue(result == 0);

        }

        [TestMethod]
        public void CreateTeam_WithInValidData()
        {
            //Arrange
            var dataConverter = new DataConverterClass();
            string outputFilePath = "D://TeamOutput.json";
            GameModel game = dataConverter.DeserializeJsonIntoObjects<GameModel>("D://Team2.json");

            //Act
            var result = eventManagerController.CreateTeamForEvents(game, outputFilePath);

            //Assert
            Assert.IsTrue(result == 0);

        }

        [TestMethod]
        public void CreateTeam_WithInValidFilePath()
        {
            //Arrange
            var dataConverter = new DataConverterClass();
            string outputFilePath = "";
            GameModel game = dataConverter.DeserializeJsonIntoObjects<GameModel>("D://Team2.json");

            //Act
            var result = eventManagerController.CreateTeamForEvents(game, outputFilePath);

            //Assert
            Assert.IsTrue(result == 0);

        }

        [TestMethod]
        public void GetTeam_WithValidGameType()
        {
            //Arrange
            var gameTypeId = 1;
            string outputFilePath = "D://Team1Output.json";

            //Act
            var result = eventManagerController.GetTeams(gameTypeId, outputFilePath);

            //Assert
            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void GetTeam_WithInValidGameType()
        {
            //Arrange
            var gameTypeId = 10;
            string outputFilePath = "D://Team1Output.json";

            //Act
            var result = eventManagerController.GetTeams(gameTypeId, outputFilePath);

            //Assert
            Assert.IsTrue(result < 0);
        }
    }
}
