using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_20210140138
{
    class Node
    {
        public int noMhs;
        public string name;
        public string kelas;
        public Node next;
        public Node prev;
    }

    class Doublelinkedlist
    {
        Node START;
        public Doublelinkedlist()
        {
            START = null;
        }

        public void addnode()
        {
            int nim;
            string nm;
            string kls;
            Console.Write("\nEnter the roll number of the student : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student : ");
            nm = Console.ReadLine();
            Console.Write("\nEnter the class of the student : ");
            kls = Console.ReadLine();
            Node newnode = new Node();
            newnode.noMhs = nim;
            newnode.name = nm;
            newnode.kelas = kls;

            if (START == null || nim <= START.noMhs)
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nDuplicate number not allowed ");
                    return;
                }

                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }

            Node previous, current;
            for (current = previous = START;
                current != null && nim >= current.noMhs;
                previous = current, current = current.next)
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nDuplicate roll number not allowed ");
                    return;
                }
            }

            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }

            current.prev = newnode;
            previous.next = newnode;

        }

        public bool search(int rollNO, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                rollNO != current.noMhs; previous = current, current =
                current.next) { }
            return (current != null);
        }

        public bool dellnode(int rollno)
        {
            Node previous, current;
            previous = current = null;
            if (search(rollno, ref previous, ref current) == false)
                return false;
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }

            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void ascending()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty ");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "roll number are:\n");
                Node currentnode;
                for (currentnode = START; currentnode != null; currentnode =
                    currentnode.next)
                    Console.WriteLine(currentnode.noMhs + "" + currentnode.name + "" + currentnode.kelas + "\n");
            }
        }

        public void descending()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the descending order of " + "roll number are:\n");
                Node currentnode;
                for (currentnode = START; currentnode != null;
                    currentnode = currentnode.next) { }
                while (currentnode != null)
                {
                    Console.Write(currentnode.noMhs + "" + currentnode.name + "" + currentnode.kelas + "\n");
                    currentnode = currentnode.prev;
                }
            }
        }
    }
     class Program
    {
        static void Main(string[] args)
        {
            Doublelinkedlist obj = new Doublelinkedlist();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu ");
                    Console.WriteLine("1. Add a record to the list ");
                    Console.WriteLine("2. Delete a record from the list ");
                    Console.WriteLine("3. View all record in the ascending order of roll numbers ");
                    Console.WriteLine("4. View all record in the descending order of roll numbers ");
                    Console.WriteLine("5. Search for a record in the list ");
                    Console.WriteLine("6. EXIT\n");
                    Console.Write("Enter your choice (1-6) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addnode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nList is empty ");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student : " + "whose records is to deleted : ");
                                int rollno = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellnode(rollno) == false)
                                    Console.WriteLine("record not found");
                                else
                                    Console.WriteLine("record with roll number " + rollno + "deleted\n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("\nEnter the roll number of the student whose records you want to search : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nrecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number : ");
                                    Console.WriteLine("\nName : " + curr.name);
                                }

                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("check for the values entered");
                }
            }
        }
    }
}
