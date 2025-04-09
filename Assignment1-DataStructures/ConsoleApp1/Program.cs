using System;

class Assignment1_BeratDogan
{
    static int MAX; // for stack and queue sizes
    static int[] stack;
    static int top = -1; // top of stack  - assigned -1 because stack is recently empty
    static int[] queue;
    static int head = -1, tail = -1; // head and tail of queue
    static int count = 0; // it is for checking queue's fullness

    static void Main()
    {
        Console.Write("Enter the maximum size of queue and stackl: ");
        MAX = int.Parse(Console.ReadLine());
        stack = new int[MAX]; // creating array for stack
        queue = new int[MAX]; // creating array for queue

        while (true)
        {
            // menu selection
            Console.WriteLine();
            Console.WriteLine("STACK SELECTION");
            Console.WriteLine("1-) enter a number");
            Console.WriteLine("2-) read a number");
            Console.WriteLine("3-) print the stack");
            
            Console.WriteLine("QUEUE SELECTION");
            Console.WriteLine("4) enter a number");
            Console.WriteLine("5) read a number");
            Console.WriteLine("6) print the queue from head to tail");
            Console.WriteLine("7) exit");
            Console.Write("Selection: ");

            int choice = int.Parse(Console.ReadLine()); // reading user choice


           //**Menu for Selection**
            switch (choice)
            {
                case 1:
                    Console.Write("Enter a number to push: ");
                    int pushValue = int.Parse(Console.ReadLine());
                    Push(pushValue);
                    break;
                case 2:
                    Pop();
                    break;
                case 3:
                    PrintStack();
                    break;
                case 4:
                    Console.Write("Enter a number to enqueue: ");
                    int enqueueValue = int.Parse(Console.ReadLine());
                    Enqueue(enqueueValue);
                    break;
                case 5:
                    Dequeue();
                    break;
                case 6:
                    PrintQueue();
                    break;
                case 7:
                    return; // Program ends
                default:
                    Console.WriteLine("Invalid selection!");
                    break;
            }
        }
    }

    // Stack functions
    static void Push(int value)
    {
        if (top == MAX - 1)
        {
            Console.WriteLine("Stack overflow!"); // stack is full
            return;
        }
        stack[++top] = value; // add element to stack
    }

    static void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack underflow!"); // stack is empty
            return;
        }
        Console.WriteLine("Popped: " + stack[top--]); // remove top element
    }

    static void PrintStack()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is empty!");
            return;
        }
        Console.Write("Stack elements: ");

    for (int i = 0; i <= top; i++)
    {
        Console.Write(stack[i]);
        if (i < top) Console.Write(", ");
    }

    Console.WriteLine();
        
    }

    // queue operations
    static void Enqueue(int value)
    {
        // since one slot must remain empty, the queue is full if count == MAX - 1
        if (count == MAX - 1)
        {
            Console.WriteLine("Queue overflow! Cannot enqueue " + value);
            return;
        }
        if (head == -1) 
            head = 0; // Initialize head if it's the first element
        tail = (tail + 1) % MAX; // Move tail forward circularly
        queue[tail] = value; // Add element to queue
        count++;
    }

    static void Dequeue()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty!");
            return;
        }
        Console.WriteLine("Dequeued: " + queue[head]); // print the removed element
        if (head == tail)
        {
            // if only one element was in the queue
            head = tail = -1; // reset the queue
        }
        else
        {
            head = (head + 1) % MAX; // Move head forward circularly
        }
        count--;
    }

    static void PrintQueue()
    {
        if (count == 0)
    {
        Console.WriteLine("Queue is empty!");
        return;
    }

    Console.Write("Queue elements: ");

    int i = head;
    for (int j = 0; j < count; j++)
    {
        Console.Write(queue[i]);
        if (j < count - 1) Console.Write(", ");
        i = (i + 1) % MAX;
    }
    Console.WriteLine();
}
}