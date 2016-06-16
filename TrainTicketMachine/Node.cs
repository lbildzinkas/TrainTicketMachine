using System.Collections.Generic;

namespace TrainTicketMachine.DataStructures
{
    public class Node
    {
        public char Value { get; set; }
        IDictionary<char, Node> Children { get; set; }
        public Node Parent { get; set; }
        public int Depth { get; set; }
        public int WordCount { get; set; }

        public Node(char value, IDictionary<char, Node> children,
            int wordCount, int deep)
        {
            Value = value;
            Children = children;
            WordCount = wordCount;
            Depth = deep;
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        public bool IsTerm()
        {
            return WordCount > 0;
        }

        public Node FindChild(char character)
        {
            Node node;
            Children.TryGetValue(character, out node);
            return node;
        }

        public IEnumerable<Node> GetChildren()
        {
            return Children.Values;
        }

        public void DeleteChild(char character)
        {
            Children.Remove(character);
        }

        public void SetChild(Node node)
        {
            Children[node.Value] = node;
        }
    }
}