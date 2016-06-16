using System.Collections.Generic;

namespace TrainTicketMachine.Repos
{
    public interface IStationRepository
    {
        IEnumerable<string> MatchStationNamesStartingWith(string text);
        IEnumerable<char> GetNextPossibleCharacters(string text);
    }
}