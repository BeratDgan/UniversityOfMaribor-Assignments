using System.Collections.Generic;

namespace Name
{
    public class Node
    {
        public int Key;
        public Node? Left;
        public Node? Right;
        public Node? Parent;
        public List<string> Movies; // list of movies of that day

        public Node(int key, string movie)
        {
            Key = key;
            Movies = new List<string> { movie };
            Left = null;
            Right = null;
            Parent = null;
        }
    }
}