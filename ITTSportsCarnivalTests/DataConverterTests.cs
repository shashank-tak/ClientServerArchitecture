using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITTSportsCarnivalApp.DataConverter;
using ITTSportsCarnivalApp.Models;
using System.IO;
using System.Text.RegularExpressions;
using ITTSportsCarnivalApp;

namespace ITTSportsCarnivalTests
{
    [TestClass]
    public class DataConverterTests
    {
        DataConverterClass _dataConverter = new DataConverterClass();
        [TestMethod]
        public void DeserializeJsonIntoObjects_Success()
        {
            //Arrange
            string inputFilePath = "D://Team1.json";

            //Act
            var result = _dataConverter.DeserializeJsonIntoObjects<GameModel>(inputFilePath);

            //Assert
            Assert.IsInstanceOfType(result, typeof(GameModel));
        }

        [TestMethod]
        public void DeserializeJsonIntoObjects_Failure()
        {
            //Arrange
            string inputFilePath = "D://Team1.json";

            //Act
            var result = _dataConverter.DeserializeJsonIntoObjects<string>(inputFilePath);

            //Assert
            Assert.AreEqual(result,ApplicationConstants.DeserializeJsonIntoObjectsFailureMessage);
        }

        [TestMethod]
        public void SerializeJsonIntoObjects_Success()
        {
            //Arrange
            var filePath = "D://Serializer.json";
            string inputFilePath = "D://Team1.json";
            GameModel game = _dataConverter.DeserializeJsonIntoObjects<GameModel>(inputFilePath);

            //Act
            var result = _dataConverter.SerializeJsonIntoObjects(filePath, game);

            //Assert
            var actual = Regex.Replace(File.ReadAllText(result), @"\s+", " "); 
            var expected = Regex.Replace(File.ReadAllText(inputFilePath), @"\s+", " ");
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void SerializeJsonIntoObjects_Failure()
        {
            //Arrange
            var filePath = "";
            string inputFilePath = "D://Team1.json";
            var game = "wrong object";

            //Act
            var result = _dataConverter.SerializeJsonIntoObjects(filePath, game);

            //Assert
            Assert.AreEqual(result, ApplicationConstants.SerializeJsonIntoObjectsFailureMessage);
        }
    }
}
