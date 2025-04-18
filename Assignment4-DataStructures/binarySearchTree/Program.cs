using System;

namespace Name
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTreeClass bst = new BinarySearchTreeClass();
            int choice;

            do
            {
                Console.WriteLine("\nBinary Search Tree – Operations:");
                Console.WriteLine("1) Insert a value");
                Console.WriteLine("2) Ordered print of keys");
                Console.WriteLine("3) Print of connections");
                Console.WriteLine("4) Search a key");
                Console.WriteLine("5) Print Min/Max");
                Console.WriteLine("6) Print Successor and Predecessor");
                Console.WriteLine("7) Remove a node");
                Console.WriteLine("8) End");
                Console.Write("Operation: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Insert
                        Console.Write("Enter an integer to insert: ");
                        if (int.TryParse(Console.ReadLine(), out int insertValue))
                        {
                            if (bst.Search(insertValue) != null)
                            {
                                Console.WriteLine("Value already exists in the tree. Insertion rejected.");
                            }
                            else
                            {
                                bst.Insert(insertValue);
                                Console.WriteLine("Inserted.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                        break;

                    case 2: // Ordered print
                        Console.WriteLine("Tree values (In-Order):");
                        if (bst.FindMin() == null)
                            Console.WriteLine("Tree is empty.");
                        else
                            bst.OrderedPrinting(bst.Root);
                        break;

                    case 3: // Print connections
                        Console.WriteLine("Tree connections:");
                        if (bst.Root == null)
                            Console.WriteLine("Tree is empty.");
                        else
                            bst.PrintConnections(bst.Root);
                        break;

                    case 4: // Search
                        Console.Write("Enter key to search: ");
                        if (int.TryParse(Console.ReadLine(), out int searchKey))
                        {
                            Node found = bst.Search(searchKey);
                            Console.WriteLine(found != null ? "Key found in tree." : "Key not found.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                        break;

                    case 5: // Min/Max
                        Node min = bst.FindMin();
                        Node max = bst.FindMax();
                        if (min == null || max == null)
                        {
                            Console.WriteLine("Tree is empty.");
                        }
                        else
                        {
                            Console.WriteLine($"Minimum: {min.Key}");
                            Console.WriteLine($"Maximum: {max.Key}");
                        }
                        break;

                    case 6: // Successor and Predecessor
                        Console.Write("Enter key to find successor and predecessor: ");
                        if (int.TryParse(Console.ReadLine(), out int spKey))
                        {
                            if (bst.Search(spKey) == null)
                            {
                                Console.WriteLine("Key not found in tree.");
                            }
                            else
                            {
                                Node succ = bst.Successor(spKey);
                                Node pred = bst.Predecessor(spKey);

                                Console.WriteLine($"Successor: {(succ != null ? succ.Key.ToString() : "None")}");
                                Console.WriteLine($"Predecessor: {(pred != null ? pred.Key.ToString() : "None")}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                        break;

                    case 7: // Remove
                        Console.Write("Enter key to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeKey))
                        {
                            if (bst.Search(removeKey) == null)
                            {
                                Console.WriteLine("Key not found in tree.");
                            }
                            else
                            {
                                bst.RemoveNode(removeKey);
                                Console.WriteLine("Node removed.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                        break;

                    case 8: // Exit
                        Console.WriteLine("Exiting program.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
                        break;
                }

            } while (choice != 8);
        }
    }
}
