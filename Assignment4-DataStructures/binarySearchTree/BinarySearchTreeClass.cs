
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
                OrderedPrinting(x.Left); //go to left node (for smaller elements)
                Console.WriteLine(x.Key); //printing current key
                OrderedPrinting(x.Left);//go to left node (for smaller elements)
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
                            successor = ancestor; // Sol yoldan yukarı çıkıyoruz
                            ancestor = ancestor.Left;
                        }
                        else if (node.Key > ancestor.Key)
                        {
                            ancestor = ancestor.Right;
                        }
                        else
                        {
                            break; // node bulundu
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
                            successor = ancestor; // sag yoldan yukarı çıkıyoruz
                            ancestor = ancestor.Right;
                        }
                        else if (node.Key < ancestor.Key)
                        {
                            ancestor = ancestor.Left;
                        }
                        else
                        {
                            break; // node bulundu
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

            // 1. Düğümü ve parent'ı bul
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

            // 2. Eğer iki çocuğu varsa
            if (current.Left != null && current.Right != null)
            {
                // Sağ alt ağacın en küçük elemanını (successor) bul
                Node successor = current.Right;
                while (successor.Left != null)
                {
                    successor = successor.Left;
                }

                // Successor’un değerini şimdiki düğüme kopyala
                current.Key = successor.Key;

                // Şimdi successor’ü sil (successor'un en fazla 1 çocuğu olur)
                RemoveNode(successor.Key);
                return;
            }

            // 3. Tek çocuk veya hiç çocuk durumu
            Node child = (current.Left != null) ? current.Left : current.Right;

            if (parent == null)
            {
                // root düğümü siliniyor
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




    }


}