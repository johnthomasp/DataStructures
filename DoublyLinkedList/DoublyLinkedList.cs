using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class Node
    {
        private object data;
        private Node previous;
        private Node next;

        public Node()
        {
            previous = null;
            data = null;
            next = null;
        }

        public Node(object o)
        {
            previous = null;
            data = o;
            next = null;
        }

        public Node(Node p, object o, Node n)
        {
            previous = p;
            data = o;
            next = n;
        }

        public object Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Node Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }

        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }

    public class DoublyLinkedList
    {
        private Node head;
        private int count;

        public DoublyLinkedList()
        {
            head = null;
            count = 0;
        }

        public void insertAt(int index, object data)
        {
            if ((head != null) && (index >= 1 && index <= count))
            {
                {
                    Node current = head;
                    Node newNode = null;
                    int i = 1;
                    while (i < index)
                    {
                        current = current.Next;
                        i++;
                    }

                    if (current.Previous == null)
                    {
                        newNode = new Node(null, data, current);
                        current.Previous = newNode;
                        head = newNode;
                    }
                    else
                    {
                        newNode = new Node(current.Previous, data, current);
                        current.Previous.Next = newNode;
                        current.Previous = newNode;
                    }
                    count++;
                }
            }
        }

        public void addToFront(object data)
        {
            if (head == null)
            {
                head = new Node(null, data, null);
            }
            else
            {
                Node newNode = new Node(null, data, head);
                head.Previous = newNode;
                head = newNode;
            }
            count++;
        }

        public void addToRear(object data)
        {
            if (head == null)
            {
                head = new Node(null, data, null);
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                Node newNode = new Node(current, data, null);
                current.Next = newNode;
            }
            count++;
        }

        public void removeAt(int index)
        {
            if ((head != null) && (index >= 1 && index <= count))
            {
                Node current = head;
                int i = 1;
                while (i < index)
                {
                    current = current.Next;
                    i++;
                }

                if (current.Previous == null)
                {
                    current = current.Next;
                    current.Previous = null;
                    head = current;
                }
                else if (current.Next == null)
                {
                    current.Previous.Next = null;

                }
                else
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                }
                count--;
            }
        }

        public void removeFromFront()
        {
            if (head != null)
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
        }

        public void removeFromRear()
        {
            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            count--;
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public int Count()
        {
            return count;
        }

        public void printList()
        {
            Node curr = head;
            Console.Write("Head-->");
            while (curr != null)
            {
                Console.Write(curr.Data);
                curr = curr.Next;
                Console.Write("-->");
            }
            Console.Write("NULL");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList dll = new DoublyLinkedList();
            Console.WriteLine();
            Console.WriteLine("**Insert at Start***");
            dll.addToFront(3);
            dll.addToFront(2);
            dll.addToFront(1);
            dll.printList();

            Console.WriteLine();
            Console.WriteLine("**Insert at End***");

            dll.addToRear(4);
            dll.addToRear(5);
            dll.addToRear(6);
            dll.printList();

            Console.WriteLine();
            Console.WriteLine("**Insert At***");
            dll.insertAt(1, 11);
            dll.insertAt(2, 22);
            dll.insertAt(3, 33);
            dll.printList();


            Console.WriteLine();
            Console.WriteLine("**Remove At***");
            dll.removeAt(1);
            dll.removeAt(2);
            dll.removeAt(3);
            dll.printList();

            Console.WriteLine();
            Console.WriteLine("**Remove from Start***");
            dll.removeFromFront();
            dll.removeFromFront();
            dll.removeFromFront();
            dll.printList();

            Console.WriteLine();
            Console.WriteLine("**Remove from Rear***");
            dll.removeFromRear();
            dll.removeFromRear();
            dll.removeFromRear();
            dll.printList();


            Console.ReadLine();
        }
    }
}
