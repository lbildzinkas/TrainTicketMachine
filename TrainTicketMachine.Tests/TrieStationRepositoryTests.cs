using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTicketMachine.DataStructures;
using TrainTicketMachine.Repos;

namespace TrainTicketMachine.Tests
{
    [TestClass]
    public class TrieStationRepositoryTests
    {
        [TestMethod]
        public void GivenTextShouldReturnCorrectStationsAndNextChars()
        {
            //Given
            var stationSource = new List<string>() {"DARTFORD", "DARTMOUTH"};
            var charSource = new List<char>() {'F', 'M'};
            var trie = new Trie();
            trie.InsertRange(new List<string>() { "DARTFORD", "DARTMOUTH", "TOWER HILL", "DERBY" });
            var trieStationRepository = new TrieStationRepository(trie);
            var text = "DART";

            //When
            var stations = trieStationRepository.MatchStationNamesStartingWith(text);
            var chars = trieStationRepository.GetNextPossibleCharacters(text);

            //Then
            Assert.IsTrue(stations.ToList().TrueForAll(r => stationSource.Contains(r)));
            Assert.IsTrue(chars.ToList().TrueForAll(c => charSource.Contains(c)));
        }

        [TestMethod]
        public void GivenTextShouldReturnCorrectStationsAndNoNextChars()
        {
            //Given
            var stationSource = new List<string>() { "LIVERPOOL", "LIVERPOOL LIME STREET" };
            var charSource = new List<char>() {  };
            var trie = new Trie();
            trie.InsertRange(new List<string>() { "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON" });
            var trieStationRepository = new TrieStationRepository(trie);
            var text = "LIVERPOOL";

            //When
            var stations = trieStationRepository.MatchStationNamesStartingWith(text);
            var chars = trieStationRepository.GetNextPossibleCharacters(text);

            //Then
            Assert.IsTrue(stations.ToList().TrueForAll(r => stationSource.Contains(r)));
            Assert.IsTrue(chars.ToList().TrueForAll(c => charSource.Contains(c)));
        }

        [TestMethod]
        public void GivenTextShouldNotReturnStationsOrCharacters()
        {
            //Given
            var stationSource = new List<string>() { };
            var charSource = new List<char>() {};
            var trie = new Trie();
            trie.InsertRange(new List<string>() { "EUSTON", "LONDON BRIDGE", "VICTORIA" });
            var trieStationRepository = new TrieStationRepository(trie);
            var text = "KINGS CROSS";

            //When
            var stations = trieStationRepository.MatchStationNamesStartingWith(text);
            var chars = trieStationRepository.GetNextPossibleCharacters(text);

            //Then
            Assert.IsTrue(stations.ToList().TrueForAll(r => stationSource.Contains(r)));
            Assert.IsTrue(chars.ToList().TrueForAll(c => charSource.Contains(c)));
        }


    }
}