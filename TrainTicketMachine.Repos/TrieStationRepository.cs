using System.Collections.Generic;
using TrainTicketMachine.DataStructures;

namespace TrainTicketMachine.Repos
{
    public class TrieStationRepository : IStationRepository
    {
        private readonly ITrie _trie;

        public TrieStationRepository(ITrie trie)
        {
            _trie = trie;
        }

        public IEnumerable<string> MatchStationNamesStartingWith(string text)
        {
            return _trie.SearchMatchingTerms(text);
        }

        public IEnumerable<char> GetNextPossibleCharacters(string text)
        {
            return _trie.SearchNextMatchingChars(text);
        }
    }
}