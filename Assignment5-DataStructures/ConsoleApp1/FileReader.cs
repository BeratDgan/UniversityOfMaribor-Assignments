using System;
using System.IO;

namespace Name
{
    public class FileReader
    {
        //it gets file path and BST as a parameter, and readed movies from the file add to BST
        public static void LoadMoviesFromFile(string filePath, BinarySearchTreeClass bst)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                if (line == null) return;
                int n = int.Parse(line);

                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line) || line.Length < 9) continue;
                    int key = int.Parse(line.Substring(0, 8));
                    string movie = line.Substring(9).Trim();
                    bst.Insert(key, movie);
                }
            }
        }
    }
}