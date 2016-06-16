using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrainTicketMachine.Repos;
using TrainTicketMachine.Services;

namespace TrainTicketMachine.Tests
{
    [TestClass]
    public class StationSearchServiceTests
    {
        [TestMethod]
        public void GivenTextShouldReturnCorrectStationsAndNextChars()
        {
            //Given
            var stationRepository = new Mock<IStationRepository>();
            stationRepository.Setup(s => s.MatchStationNamesStartingWith(It.IsAny<string>()))
                .Returns(new List<string>() {"DARTFORD", "DARTMOUTH"});
            stationRepository.Setup(s => s.GetNextPossibleCharacters(It.IsAny<string>()))
                .Returns(new List<char>() { 'F', 'M' });
            var text = "DART";
            var stationSource = new List<string>() { "DARTFORD", "DARTMOUTH" };
            var charSource = new List<char>() { 'F', 'M' };
            var stationSearchService = new StationService(stationRepository.Object);

            //When
            var result = stationSearchService.MatchStationsStartingWith(text);

            //Then
            Assert.IsTrue(result.Item2.ToList().TrueForAll(r => stationSource.Contains(r)));
            Assert.IsTrue(result.Item1.ToList().TrueForAll(c => charSource.Contains(c)));
        }

        [TestMethod]
        public void GivenTextShouldReturnCorrectStationsAndNoNextChars()
        {
            //Given
            var stationSource = new List<string>() { "LIVERPOOL", "LIVERPOOL LIME STREET" };
            var charSource = new List<char>() { };
            var stationRepository = new Mock<IStationRepository>();
            stationRepository.Setup(s => s.MatchStationNamesStartingWith(It.IsAny<string>()))
                .Returns(stationSource);
            stationRepository.Setup(s => s.GetNextPossibleCharacters(It.IsAny<string>()))
                .Returns(charSource);
            var text = "LIVERPOOL";
            var stationSearchService = new StationService(stationRepository.Object);

            //When
            var result = stationSearchService.MatchStationsStartingWith(text);

            //Then
            Assert.IsTrue(result.Item2.ToList().TrueForAll(r => stationSource.Contains(r)));
            Assert.IsTrue(result.Item1.ToList().TrueForAll(c => charSource.Contains(c)));
        }

        [TestMethod]
        public void GivenTextShouldNotReturnStationsOrCharacters()
        {
            //Given
            var stationSource = new List<string>() { };
            var charSource = new List<char>() { };
            var stationRepository = new Mock<IStationRepository>();
            stationRepository.Setup(s => s.MatchStationNamesStartingWith(It.IsAny<string>()))
                .Returns(stationSource);
            stationRepository.Setup(s => s.GetNextPossibleCharacters(It.IsAny<string>()))
                .Returns(charSource);
            var text = "KINGS CROSS";
            var stationSearchService = new StationService(stationRepository.Object);

            //When
            var result = stationSearchService.MatchStationsStartingWith(text);

            //Then
            Assert.IsTrue(result.Item2.ToList().TrueForAll(r => stationSource.Contains(r)));
            Assert.IsTrue(result.Item1.ToList().TrueForAll(c => charSource.Contains(c)));
        }
    }
}