using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class TowerOfHanoi
{
    public static void Main()
    {
        Console.Write("Enter the number of disks: ");
         int numberOfDisks =int.Parse(Console.ReadLine()); // get the number of disks from the user
        if ( numberOfDisks <= 0) // checking the input is a positive number
        {
            Console.WriteLine("invalid number of disks ");
            return; // exit if input is invalid
        }

        TowerOfHanoi game = new TowerOfHanoi(numberOfDisks); // create a new game instance
        game.StartGame(); // start the game loop
    }
    public void StartGame()
    {
        while (true) 
        {

            if(IsGameComplete()){
                Console.WriteLine("The Game is Done!");
                break;
            }


            Console.WriteLine("1-) Print the towers");
            Console.WriteLine("2-) Move a disk from one tower to another");
            Console.WriteLine("3-) Exit");
            Console.Write("Enter your choice: ");

            int choice =  int.Parse(Console.ReadLine());//user input
        
            switch (choice)
            {
                case 1:
                    PrintTowers(); // display the current state of the towers
                    break;
                case 2:
                    Console.Write("enter the source tower (1-3): ");
                    int fromTower = int.Parse(Console.ReadLine()); // Get the source tower number
                    if (fromTower <1 || fromTower>3) // Validate input

                    {
                        Console.WriteLine("invalid input.");
                        continue;
                    }
                    Console.Write("Enter the Destination tower (1-3): ");
                    int toTower = int.Parse(Console.ReadLine()); // Get the destination tower number
                    if (toTower <1 || toTower>3) // Validate input
                    {
                        Console.WriteLine("ınvalid input");
                        continue;
                    }
                    MoveDisk(fromTower, toTower); // Move the disk
                    break;
                case 3:
                    Console.WriteLine("Bye");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice, Please enter 1, 2, 3");
                    break;
            }
        }
    }
    

    
    public Stack<int>[] towers; // Three towers represented as stacks
    public int numberOfDisks; // Number of disks in the game

    public  TowerOfHanoi(int numberOfDisks)
    {
        this.numberOfDisks = numberOfDisks;
        towers = new Stack<int>[3]; // Create three towers

        for (int i = 0; i < 3; i++)
        {
            towers[i] = new Stack<int>(); // Initialize each tower as an empty stack
        }

        // Place disks in the first tower (biggest at the bottom)
        for (int i = numberOfDisks; i > 0; i--)
        {
            towers[0].Push(i); // Add disks in descending order (largest at bottom)
        }
        
    }
    

    public void MoveDisk(int fromTower, int toTower)
    {
        //these if blocks for invalid moves
        if (fromTower < 1 || fromTower > 3 ) // checkin for valid tower numbers
        {
            Console.WriteLine("Invalid move, numbers must be between 1 and 3");
            return;
        }
        if (toTower < 1 || toTower > 3 ) // checkin for valid tower numbers
        {
            Console.WriteLine("Invalid move, numbers must be between 1 and 3");
            return;
        }
        if (fromTower == toTower) // checking moving a disk to the same tower
        {
            Console.WriteLine("You cant move a disk to the same tower");
            return;
        }
        if (towers[fromTower - 1].Count == 0) // check if the source tower has disks
        {
            Console.WriteLine("The source tower is empty ");
            return;
        }
        if (towers[toTower - 1].Count != 0 && towers[toTower - 1].Peek() < towers[fromTower - 1].Peek())
        {
            Console.WriteLine("Invalid move ,You cant place a larger disk on a smaller disk");
            return;
        }

        // move the disk
        towers[toTower - 1].Push(towers[fromTower - 1].Pop()); // Remove disk from source and add to destination
        Console.WriteLine("Disk moved from Tower :" + fromTower + " to Tower: " + toTower);
    }

    public void PrintTowers()
    {
        for (int i = 0; i < 3; i++) // Loop through each tower
        {
            Console.WriteLine("Tower " + (i + 1) + ":"); // print tower number
            int[] disks = towers[i].ToArray(); // convert stack to array to display correctly
            foreach (int disk in disks) // loop through the disks in the tower
            {
                Console.WriteLine(new string('*', disk)); // print each disk using '*' characters
            }
            Console.WriteLine();
        }
    }   
    public bool IsGameComplete(){ // if all disks moved to third tower game is end
        if(towers[2].Count==numberOfDisks){
            return true;
        }
        return false;
    }
}
