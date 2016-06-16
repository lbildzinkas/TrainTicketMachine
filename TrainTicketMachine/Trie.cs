using System.Collections.Generic;
using System.Text;

namespace TrainTicketMachine.DataStructures
{
    /// <summary>
    /// This class represents a Trie. It´s commonly used to search strings more efficiently, the worst case is O(n).
    /// The insertion is usually less efficient, but it compensates when you need to search for text patterns, because it´s much faster.
    /// </summary>
    public class Trie : ITrie
    {
        private readonly Node _root;

        public Trie()
        {
            _root = new Node(' ', new Dictionary<char, Node>(), 0, 0 );
        }

        public Node Prefix(string text)
        {
            var currentNode = _root;
            var result = currentNode;

            foreach (var c in text)
            {
                currentNode = currentNode.FindChild(c);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }

        public IList<string> SearchMatchingTerms(string text)
        {
            var terms = new List<string>();
            var node = Prefix(text);
            if (node == _root) return terms;

            var buffer = new StringBuilder();
            buffer.Append(text);
            GetTerms(node, terms, buffer);
            return terms;
        }

        private void GetTerms(Node node, ICollection<string> words,
            StringBuilder buffer)
        {
            if (node.IsTerm())
            {
                words.Add(buffer.ToString());
            }

            foreach (var child in node.GetChildren())
            {
                buffer.Append(child.Value);
                GetTerms(child, words, buffer);
                buffer.Length--;
            }
        }

        public IList<char> SearchNextMatchingChars(string text)
        {
            var chars = new List<char>();
            var node = Prefix(text);
            if (node == _root) return chars;

            GetChars(node, chars);

            return chars;
        }

        private void GetChars(Node node, IList<char> chars)
        {
            foreach (var child in node.GetChildren())
            {
                if (node.Depth + 1 == child.Depth && !child.Value.Equals(' '))
                {
                    chars.Add(child.Value);
                }
                else if(child.Depth > node.Depth + 1)
                {
                    return;
                }
            }
        }
        
        public void InsertRange(IList<string> items)
        {
            foreach (var character in items)
                Insert(character);
        }

        public void Insert(string text)
        {
            InsertNode(_root, text.ToCharArray());
        }

        private void InsertNode(Node node, char[] term)
        {
            foreach (var character in term)
            {
                var child = node.FindChild(character);
                if (child == null)
                {
                    child = new Node(character, new Dictionary<char, Node>(), 0, node.Depth + 1);
                    node.SetChild(child);
                }
                node = child;
            }
            node.WordCount++;
        }
    }
}