using System;
using System.ComponentModel.DataAnnotations;

public class Element
{
    public int Key;
    public Element Prev;
    public Element Next;

    public Element(int key)
    {
        Key = key;
        Prev = null;
        Next = null;
    }
}

public class DoublyLinkedList
{
    Element head = null;
    Element tail = null;

    public Element ElementSearch(int key)
    {
        Element current = head;
        while (current != null && current.Key != key)
        {
            current = current.Next;
        }
        return current;
    }

    public void InsertIntoHead(int key)
    {
        Element newE = new Element(key);
        newE.Next = head;
        if (head != null) head.Prev = newE; //if list is not empty update head's previous
        else { tail = newE; head = newE; } //list is empty
        head = newE;
    }
    public Element MaxWriter()
    {
        Element current = head;
        Element Max=head ;

        while (current !=null)
        {
            if (current.Key>Max.Key)
            {
                Max = current;
            }
            current = current.Next;
            
        }
        return Max;
        
    }

    public void InsertAfter(Element elem, int key)
    {
        Element newE = new Element(key);
        if (elem.Next == null)
        {  //if the after element is tail' the inserting element becomes new tail
            newE.Prev = tail;
            tail.Next = newE;
            tail = newE;
        }
        else
        {
            newE.Next = elem.Next;
            newE.Prev = elem;
            elem.Next.Prev = newE; //elem's old next's previous become the new element
            elem.Next = newE;
        }
    }

    public void InsertAfterTail(int key)
    {
        Element newE = new Element(key);
        if (tail == null)
        {
            tail = newE;
            head = newE;
        }
        else
        {
            newE.Prev = tail;
            tail.Next = newE;
            tail = newE;
        }
    }

    public void DeleteElement(Element elemDel)
    {
        if (elemDel.Next != null && elemDel.Prev != null)
        {
            elemDel.Prev.Next = elemDel.Next;
            elemDel.Next.Prev = elemDel.Prev;
            elemDel = null;
        }
        else if (elemDel.Next == null && elemDel.Prev != null)//that means number to the deleted is tail
        {
            tail = elemDel.Prev;
            elemDel.Prev.Next = null;
            elemDel = null;
        }
        else if (elemDel.Prev == null && elemDel.Next != null)//that means number to the deleted is head
        {
            head = elemDel.Next;
            elemDel.Next.Prev = null;
            elemDel = null;
        }
        else if (elemDel.Prev == null && elemDel.Next == null) // single element in the list
        {
            head = null;
            tail = null;
            elemDel = null;
        }
    }

    public void PrintHeadToTail()
    {
        Element current = head;
        while (current != null)
        {
            Console.WriteLine(current.Key);
            current = current.Next;
        }
    }

    public void PrintTailToHead()
    {
        Element current = tail;
        while (current != null)
        {
            Console.WriteLine(current.Key);
            current = current.Prev;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        DoublyLinkedList list = new DoublyLinkedList();
        int selection;

        //Menu Selection
        do
        {
            //
            Console.Clear();
            Console.WriteLine("Doubly Linked List Operations:");
            Console.WriteLine("1- Search data");
            Console.WriteLine("2- Insert data into head");
            Console.WriteLine("3- Insert data after the element");
            Console.WriteLine("4- Insert data after tail");
            Console.WriteLine("5- Delete one element");
            Console.WriteLine("6- Print list from head to tail");
            Console.WriteLine("7- Print list from tail to head");
            Console.WriteLine("8 End");
            Console.WriteLine("9 return the biggest value");
            Console.Write("Select: ");

            
            selection = Convert.ToInt32(Console.ReadLine());

            
            switch (selection)
            {
                case 1:
                    //for searching data

                    Console.Write("Enter the data to search: ");
                    int searchData = Convert.ToInt32(Console.ReadLine());
                    Element foundElement = list.ElementSearch(searchData);
                    if (foundElement != null)
                    {
                        Console.WriteLine("Element found: " + foundElement.Key);
                    }
                    else
                    {
                        Console.WriteLine("Element not found");
                    }
                    break;

                case 2:
                    // for inserting data to head

                    Console.Write("Enter the data to insert at the head: ");
                    int headData = Convert.ToInt32(Console.ReadLine());
                    list.InsertIntoHead(headData);
                    break;

                case 3:
                    //for insetrting data after the element

                    Console.Write("Enter the data to insert: ");
                    int afterData = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the element after which to insert: ");
                    int elementAfter = Convert.ToInt32(Console.ReadLine());
                    
                    Element element = list.ElementSearch(elementAfter);
                    if (element != null)
                    {
                        list.InsertAfter(element, afterData);
                    }
                    else
                    {
                        Console.WriteLine("Element not found");
                    }
                    break;

                case 4:
                    //for inserting data to tail
                    
                    Console.Write("Enter the data to insert at the tail: ");
                    int tailData = Convert.ToInt32(Console.ReadLine());
                    list.InsertAfterTail(tailData);
                    break;

                case 5:
                    //for deleting data
                    
                    Console.Write("Enter the data to delete: ");
                    int deleteData = Convert.ToInt32(Console.ReadLine());
                    Element deleteElement = list.ElementSearch(deleteData);
                    if (deleteElement != null)
                    {
                        list.DeleteElement(deleteElement);
                    }
                    else
                    {
                        Console.WriteLine("Element not found");
                    }
                    break;

                case 6:
                    
                    list.PrintHeadToTail();
                    break;

                case 7:
                    
                    list.PrintTailToHead();
                    break;

                case 8:
                    
                    Console.WriteLine("Exiting program");
                    break;

                case 9:
            Element maxElement = list.MaxWriter();
            if (maxElement != null)
        {
            Console.WriteLine("Biggest value in the list is: " + maxElement.Key);
        }
        else
        {
            Console.WriteLine("List is empty.");
        }
        break;


                default:
                    
                    Console.WriteLine("Invalid selection Please try again");
                    break;
            }

            
            if (selection != 8)
            {
                Console.WriteLine("Press any key to continue ");
                Console.ReadKey();
            }

        } while (selection != 8);  // Seçim 8 (End) olmadığı sürece döngü devam eder
    }
}