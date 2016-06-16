using System;
using System.Collections.Generic;
using TrainTicketMachine.Repos;

namespace TrainTicketMachine.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationSearchRepository;

        public StationService(IStationRepository stationSearchRepository)
        {
            _stationSearchRepository = stationSearchRepository;
        }

        public Tuple<IEnumerable<char>, IEnumerable<string>> MatchStationsStartingWith(string text)
        {
            var stationNames = _stationSearchRepository.MatchStationNamesStartingWith(text);
            var nextPossibleChars = _stationSearchRepository.GetNextPossibleCharacters(text);
            return new Tuple<IEnumerable<char>, IEnumerable<string>>(nextPossibleChars, stationNames);
        }
    }
}