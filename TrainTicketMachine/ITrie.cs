using System.Collections.Generic;

namespace TrainTicketMachine.DataStructures
{
    public interface ITrie
    {
        void Insert(string text);
        void InsertRange(IList<string> items);
        Node Prefix(string text);
        IList<string> SearchMatchingTerms(string text);
        IList<char> SearchNextMatchingChars(string text);
    }
}