using System;
using System.Threading.Tasks.Dataflow;

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
                Console.WriteLine("\nBinary search tree – operations:");
                Console.WriteLine("1) Insert a movie");
                Console.WriteLine("2) Print all movies");
                Console.WriteLine("3) Find movies at the specific date");
                Console.WriteLine("4) Print minimum and maximum date");
                Console.WriteLine("5) Print successor and predecessor");
                Console.WriteLine("6) Remove all movies at specific date");
                Console.WriteLine("7) Load movies from the file");
                Console.WriteLine("8) End");
                Console.WriteLine("9) Two or more movies");
                Console.Write("Operation: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Insert a movie
                        Console.Write("Enter the date (yyyymmdd): ");
                        if (int.TryParse(Console.ReadLine(), out int dateKey))
                        {
                            Console.Write("Enter the movie name: ");
                            string movie = Console.ReadLine();
                            bst.Insert(dateKey, movie);
                            Console.WriteLine("Movie inserted.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case 2: // Print all movies
                        if (bst.Root == null)
                        {
                            Console.WriteLine("Tree is empty.");
                        }
                        else
                        {
                            bst.OrderedPrinting(bst.Root);
                        }
                        break;

                    case 3: // Find movies at the specific date
                        Console.Write("Enter the date (yyyymmdd): ");
                        if (int.TryParse(Console.ReadLine(), out int searchDate))
                        {
                            bst.FindMoviesAtDate(searchDate);
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case 4: // Print minimum and maximum date
                        var min = bst.FindMin();
                        var max = bst.FindMax();
                        if (min == null || max == null)
                        {
                            Console.WriteLine("Tree is empty.");
                        }
                        else
                        {
                            Console.WriteLine($"Minimum date: {min.Key}");
                            Console.WriteLine($"Maximum date: {max.Key}");
                        }
                        break;

                    case 5: // Print successor and predecessor
                        Console.Write("Enter the date (yyyymmdd): ");
                        if (int.TryParse(Console.ReadLine(), out int spDate))
                        {
                            var succ = bst.Successor(spDate);
                            var pred = bst.Predecessor(spDate);
                            Console.WriteLine($"Successor: {(succ != null ? succ.Key.ToString() : "None")}");
                            Console.WriteLine($"Predecessor: {(pred != null ? pred.Key.ToString() : "None")}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case 6: // Remove all movies at specific date
                        Console.Write("Enter the date (yyyymmdd): ");
                        if (int.TryParse(Console.ReadLine(), out int removeDate))
                        {
                            if (bst.Search(removeDate) == null)
                                Console.WriteLine("No movies found at this date.");
                            else
                            {
                                bst.RemoveNode(removeDate);
                                Console.WriteLine("All movies at this date removed.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case 7: // Load movies from the file
                        Console.WriteLine("Select file to load:");
                        Console.WriteLine("1) IMDB_date_name_mini.list");
                        Console.WriteLine("2) IMDB_date_name_full.list");
                        Console.WriteLine("3) IMDB_date_name_full_sorted.list");
                        Console.WriteLine("4) IMDB_date_name_mini_sorted.list");
                        Console.Write("Choice: ");
                        if (int.TryParse(Console.ReadLine(), out int fileChoice))
                        {
                            string filePath = "";
                            switch (fileChoice)
                            {
                                case 1:
                                    filePath = "C:/Users/dganb/OneDrive/Belgeler/UniversityOfMaribor-Assignments/Assignment5-DataStructures/ConsoleApp1/resources/IMDB_date_name_mini.list";
                                    break;
                                case 2:
                                    filePath = "C:/Users/dganb/OneDrive/Belgeler/UniversityOfMaribor-Assignments/Assignment5-DataStructures/ConsoleApp1/resources/IMDB_date_name_full.list";
                                    break;
                                case 3:
                                    filePath = "C:/Users/dganb/OneDrive/Belgeler/UniversityOfMaribor-Assignments/Assignment5-DataStructures/ConsoleApp1/resources/IMDB_date_name_full_sorted.list";
                                    break;
                                case 4:
                                    filePath = "C:/Users/dganb/OneDrive/Belgeler/UniversityOfMaribor-Assignments/Assignment5-DataStructures/ConsoleApp1/resources/IMDB_date_name_mini_sorted.list";
                                    break;
                                default:
                                    Console.WriteLine("Invalid file choice.");
                                    break;
                            }
                            if (!string.IsNullOrEmpty(filePath))
                            {
                                FileReader.LoadMoviesFromFile(filePath, bst);
                                Console.WriteLine("File loaded.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                        break;

                    case 8: // End
                        Console.WriteLine("Exiting program.");
                        break;
                    case 9: // two or more movies count at same date
                        int count = bst.CountNodesWithTwoOrMoreMovies();
                        Console.WriteLine($"{count} 2 or more movies at same date");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
                        break;
                }
            } while (choice != 8);
        }
    }
}