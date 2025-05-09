
namespace Name
{
    public class BinarySearchTreeClass
    {
        public Node Root;

        public void Insert(int key)

        {
            Node control = Root;
            if (Root == null) //if the root is empty inserted value being new root
            {

                Root = new Node();
                Root.Key = key;
                return;
            }
            while (true)
            {
                if (key < control.Key) //if inserted value smaller than current node go left
                {

                    if (control.Left == null)
                    {
                        control.Left = new Node();
                        control.Left.Parent = control;
                        control.Left.Key = key;
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
                        control.Right = new Node();
                        control.Right.Parent = control;
                        control.Right.Key = key;
                        break;
                    }
                    else
                    {
                        control = control.Right;
                    }
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
            // if node is not null start
            if (x != null)
            {
                OrderedPrinting(x.Left); // go to left node (for smaller elements)
                Console.WriteLine(x.Key); // printing current key
                OrderedPrinting(x.Right); // go to right node (for bigger elements)
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
                            break; // node finded
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
                            successor = ancestor; // going up to right way
                            ancestor = ancestor.Right;
                        }
                        else if (node.Key < ancestor.Key)
                        {
                            ancestor = ancestor.Left;
                        }
                        else
                        {
                            break; // node find
                        }
                    }
                    return successor;
                }
            }
        }

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




            // if there is 2 chid reaching right tree's minumum value
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



            // childless situation
            if (current.Left == null && current.Right == null)
            {
                if (parent == null)
                {
                    // if root is leaf at the same time emptying the tree
                    Root = null;
                }
                else
                {
                    if (parent.Left == current)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }
            }


            else if (current.Left == null || current.Right == null) // 1 child situation
            {
                Node child;

                if (current.Left != null)
                {
                    child = current.Left;
                }
                else
                {
                    child = current.Right;
                }

                if (parent == null)
                {
                    // Kök düğüm siliniyor ve tek çocuk kök oluyor
                    Root = child;
                    child.Parent = null;
                }
                else
                {
                    if (parent.Left == current)
                        parent.Left = child;
                    else
                        parent.Right = child;

                    child.Parent = parent;
                }
            }
        }
        /* Node child;
         if (current.Left != null)
         {
             child = current.Left;
         }
         else
         {
             child = current.Right;
         }

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
     }*/
        public void PrintConnections(Node node)
        {
            if (node != null)
            {
                string parent = node.Parent != null ? node.Parent.Key.ToString() : "null";
                string left = node.Left != null ? node.Left.Key.ToString() : "null";
                string right = node.Right != null ? node.Right.Key.ToString() : "null";

                Console.WriteLine($"Node: {node.Key} | Parent: {parent} | Left: {left} | Right: {right}");

                PrintConnections(node.Left);
                PrintConnections(node.Right);
            }
        }

        public int CountNodes()
        {
            return CountNodesRecursive(Root);
        }

        private int CountNodesRecursive(Node node)
        {
            if (node == null)
                return 0;
            return 1 + CountNodesRecursive(node.Left) + CountNodesRecursive(node.Right);
        }



    }


}