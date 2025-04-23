
namespace Name
{
    public class BinarySearchTreeClass
    {
        public Node Root;


        public void Insert(int key, string movie)
        {
            Node control = Root;
            if (Root == null) //if the root is empty inserted value being new root
            {
                Root = new Node(key, movie);
                Root.Key = key;
                Root.Movies = new List<string>(); // start the list
                Root.Movies.Add(movie); // add a
                return;
            }
            while (true)
            {
                if (key < control.Key) //if inserted value smaller than current node go left
                {
                    if (control.Left == null)
                    {
                        control.Left = new Node(key, movie);
                        control.Left.Parent = control;
                        control.Left.Key = key;
                        control.Left.Movies = new List<string>(); // start the list
                        control.Left.Movies.Add(movie); // add movie
                        break;
                    }
                    else
                    {
                        control = control.Left;
                    }
                }
                else if (key > control.Key)  //if inserted value bigger than current node go right
                {
                    if (control.Right == null)
                    {
                        control.Right = new Node(key, movie); ;
                        control.Right.Parent = control;
                        control.Right.Key = key;
                        control.Right.Movies = new List<string>(); // start the list    
                        control.Right.Movies.Add(movie); // add movie
                        break;
                    }
                    else
                    {
                        control = control.Right;
                    }
                }
                else if (key == control.Key)
                {
                    // if the same date is exists than add movie name to list
                    control.Movies.Add(movie);
                    break; // break the loop
                }
                else
                {
                    break;
                }
            }
        }
        public Node Search(int key)
        {
            if (Root == null) //if searching node is not in tree return null
            {
                return null;
            }
            Node current = Root;
            while (current != null)
            {
                if (current.Key == key)
                {
                    return current;
                }
                else if (key > current.Key) //if searching node bigger than current node it is goin right child node
                {
                    current = current.Right;
                }
                else //if searching node lower than current node it is goin left child node
                {
                    current = current.Left;
                }
            }
            return null;
        }
        public void FindMoviesAtDate(int key)
        {
            Node found = Search(key);
            if (found == null)
            {
                Console.WriteLine("No movies found on this date.");
                return;
            }
            Console.WriteLine($"Movies on {key}:");
            foreach (var movie in found.Movies)
                Console.WriteLine("  " + movie);
        }


        public Node FindMax(Node node)  //this function exist for using in 
        {
            Node current = node;
            if (current == null)//if node is null it's mean the node is not in this tree
            {
                return null;
            }

            else
            {

                while (current.Right != null)
                {
                    current = current.Right;
                }
            }
            return current;
        }
        public Node FindMax()
        {
            Node current = Root;
            if (current == null)//if root is null it's mean the tree is empty
            {
                return null;
            }

            else
            {

                while (current.Right != null)
                {
                    current = current.Right;
                }
            }
            return current;
        }
        public Node FindMin()
        {

            Node current = Root;
            if (current == null)//if root is null it's mean the tree is empty
            {
                return null;
            }
            else
            {

                while (current.Left != null)
                {
                    current = current.Left;
                }
            }
            return current;

        }

        public Node FindMin(Node node)
        {

            Node current = node;
            if (current == null)//if node is null it's mean the node is not in this tree
            {
                return null;
            }
            else
            {

                while (current.Left != null)
                {
                    current = current.Left;
                }
            }
            return current;

        }
        public void OrderedPrinting(Node x)
        {
            if (x != null)
            {
                OrderedPrinting(x.Left);
                Console.WriteLine($"Date: {x.Key}");
                foreach (var movie in x.Movies)
                    Console.WriteLine("  " + movie);
                OrderedPrinting(x.Right);
            }
        }

        public Node Successor(int key)//for finding smallest value bigger than key
        {
            Node node = Search(key);
            if (node == null)
            {
                return null;
            }
            else
            {
                if (node.Right != null)
                {
                    return FindMin(node.Right);
                }
                else
                {
                    Node successor = null;
                    Node ancestor = Root;
                    while (ancestor != null)
                    {
                        if (node.Key < ancestor.Key)
                        {
                            successor = ancestor; // going up from left way
                            ancestor = ancestor.Left;
                        }
                        else if (node.Key > ancestor.Key)
                        {
                            ancestor = ancestor.Right;
                        }
                        else
                        {
                            break; // node found
                        }
                    }
                    return successor;
                }
            }
        }

        public Node Predecessor(int key)
        {
            Node node = Search(key);
            if (node == null)
            {
                return null;
            }
            else
            {
                if (node.Left != null)
                {
                    return FindMax(node.Left);
                }
                else
                {
                    Node successor = null;
                    Node ancestor = Root;
                    while (ancestor != null)
                    {
                        if (node.Key > ancestor.Key)
                        {
                            successor = ancestor; // going up from right way
                            ancestor = ancestor.Right;
                        }
                        else if (node.Key < ancestor.Key)
                        {
                            ancestor = ancestor.Left;
                        }
                        else
                        {
                            break; // node found
                        }
                    }
                    return successor;
                }
            }
        }

        /*     public void RemoveNode(int key)
              {
                  Node current = Root;
                  Node parent = null;

                  // Find node and parent
                  while (current != null && current.Key != key)
                  {
                      parent = current;
                      if (key < current.Key)
                          current = current.Left;
                      else
                          current = current.Right;
                  }

                  if (current == null)
                  {
                      Console.WriteLine("Key not found in tree");
                      return;
                  }

                  // if there is 2 chid
                  if (current.Left != null && current.Right != null)
                  {
                      // find right tree's succsessor
                      Node successor = current.Right;
                      while (successor.Left != null)
                      {
                          successor = successor.Left;
                      }

                      // copy successors value to current
                      current.Key = successor.Key;

                      // now delete the successor
                      RemoveNode(successor.Key);
                      return;
                  }

                  // 1 child or childless situation
                  Node child = (current.Left != null) ? current.Left : current.Right;

                  if (parent == null)
                  {
                      // root node deleting
                      Root = child;
                      if (child != null)
                          child.Parent = null;
                  }
                  else
                  {
                      if (parent.Left == current)
                          parent.Left = child;
                      else
                          parent.Right = child;

                      if (child != null)
                          child.Parent = parent;
                  }
              }
           */

        public void RemoveNode(int key)
        {
            Node current = Root;
            Node parent = null;

            // Find node and parent
            while (current != null && current.Key != key)
            {
                parent = current;
                if (key < current.Key)
                    current = current.Left;
                else
                    current = current.Right;
            }

            if (current == null)
            {
                Console.WriteLine("Key not found in tree");
                return;
            }

            // if there are 2 children
            if (current.Left != null && current.Right != null)
            {
                Node successor = current.Right;
                Node successorParent = current;

                while (successor.Left != null)
                {
                    successorParent = successor;
                    successor = successor.Left;
                }

                // Kopyala: successor’ın key VE movies listesini
                // copy 
                current.Key = successor.Key;
                current.Movies = new List<string>(successor.Movies);

                // Şimdi successor node’unu sil (kesinlikle 0 ya da 1 çocuğu olur)
                if (successorParent.Left == successor)
                    successorParent.Left = (successor.Left != null) ? successor.Left : successor.Right;
                else
                    successorParent.Right = (successor.Left != null) ? successor.Left : successor.Right;

                return;
            }

            // 1 child or no child
            Node child = (current.Left != null) ? current.Left : current.Right;

            if (parent == null)
            {
                Root = child;
                if (child != null)
                    child.Parent = null;
            }
            else
            {
                if (parent.Left == current)
                    parent.Left = child;
                else
                    parent.Right = child;

                if (child != null)
                    child.Parent = parent;
            }
        }
        public int CountNodesWithTwoOrMoreMovies()
        {
            return CountNodesWithTwoOrMoreMoviesHelper(Root);
        }

        private int CountNodesWithTwoOrMoreMoviesHelper(Node? node)
        {
            if (node == null)
                return 0;
            int count = (node.Movies != null && node.Movies.Count >= 2) ? 1 : 0;
            return count
                + CountNodesWithTwoOrMoreMoviesHelper(node.Left)
                + CountNodesWithTwoOrMoreMoviesHelper(node.Right);
        }
    }


}