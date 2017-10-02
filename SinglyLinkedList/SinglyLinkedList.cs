using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    public class Node
    {
        public int Value;
        public Node Next;
    }

    public class SinglyLinkedList
    {
        public Node head;
        public Node tail;
        public int Count;

        public SinglyLinkedList()
        {
            head = new Node();
            tail = head;
        }

        public void InsertNodeAtEnd(int value)
        {
            Node InsertNode = new Node();
            InsertNode.Value = value;
            tail.Next = InsertNode;
            tail = InsertNode;
            Count++;
        }

        public void InsertNodeAtStart(int value)
        {
            Node InsertNode = new Node();
            InsertNode.Value = value;
            InsertNode.Next = head.Next;
            head.Next = InsertNode;
            Count++;
        }

        public void RemoveNodeFromStart()
        {
            if (Count > 0)
            {
                head.Next = head.Next.Next;
                Count--;
            }
            else
            {
                Console.WriteLine("List is empty");
            }
        }

        public void RemoveNodeFromPosition(int position)
        {
            int tempCount = 0;
            if (Count > 0)
            {
                Node temp = head;
                Node previousNode = null;
                
                while (temp.Next != null)
                {
                    if (tempCount == position)
                    {
                        previousNode.Next = temp.Next;
                        return;
                    }
                        tempCount++;
                        previousNode = temp;
                        temp = temp.Next;

                    if ((position == tempCount) && (tempCount == Count))
                    {
                        tail = previousNode;
                        tail.Next = null;
                    }
                }
            }
            else
            {
                Console.WriteLine("List is empty");
            }
        }

        public void printAllNodes()
        {
            Node curr = head;
            Console.Write("Head-->");
            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.Write(curr.Value);
                Console.Write("-->");
            }
            Console.Write("NULL");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList sl = new SinglyLinkedList();

            Console.WriteLine();
            Console.WriteLine("**Insert End***");

            sl.InsertNodeAtEnd(4);
            sl.InsertNodeAtEnd(5);
            sl.InsertNodeAtEnd(6);
            sl.printAllNodes();

            Console.WriteLine();
            Console.WriteLine("**Insert Start***");

            sl.InsertNodeAtStart(3);
            sl.InsertNodeAtStart(2);
            sl.InsertNodeAtStart(1);
            sl.printAllNodes();

            Console.WriteLine();
            Console.WriteLine("**Remove postion # 6***");
            sl.RemoveNodeFromPosition(6);
            sl.printAllNodes();

            Console.WriteLine();
            Console.WriteLine("**Remove postion # 4***");
            sl.RemoveNodeFromPosition(4);
            sl.printAllNodes();

            Console.WriteLine();
            Console.WriteLine("**Remove postion # 1***");
            sl.RemoveNodeFromPosition(1);
            sl.printAllNodes();

            Console.ReadLine();
        }
    }
}