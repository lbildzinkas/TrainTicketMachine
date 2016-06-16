using System;
using System.Collections.Generic;

namespace TrainTicketMachine.Services
{
    public interface IStationService
    {
        Tuple<IEnumerable<char>, IEnumerable<string>> MatchStationsStartingWith(string text);
    }
}