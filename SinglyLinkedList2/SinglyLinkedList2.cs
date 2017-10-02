using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList2
{

    public class Node
    {

        private object data;
        private Node next;

        public Node()
        {
            data = null;
            next = null;
        }

        public Node(object o)
        {
            data = o;
            next = null;
        }

        public Node(object o, Node n)
        {
            data = o;
            next = n;
        }

        public object Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }



    }

    public class SinglyLinkedList
    {
        //Add(object)
        //Add(position, object)
        //remove
        //isEmpty
        //isFull
        //replace(position,object)
        //getentry
        //contains
        //clear
        //getLength

        private Node headNode;
        public bool add(int position, object newEntry)
        {
            Node tmp = headNode;
            if (position >= 1)
            {
                Node newNode = new Node(newEntry);
                if (isEmpty() || position == 1)
                {
                    newNode.Next = tmp;
                    headNode = newNode;
                    return true;
                }
                else
                {
                    for (int i = 1; i < position - 1 && tmp != null; i++)
                    {
                        tmp = tmp.Next;
                    }
                    if (tmp == null)
                    {
                        return false;
                    }
                    newNode.Next = tmp.Next;
                    tmp.Next = newNode;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public bool add(object newEntry)
        {
            return add(getLength() + 1, newEntry);
        }

        public object Remove(int position)
        {
            object tmpObj = null;
            if (isEmpty() || position < 1)
            {
                return null;
            }

            Node currentNode = headNode;

            if (position == 1)
            {
                tmpObj = currentNode.Data;
                headNode = currentNode.Next;
            }
            else
            {
                for (int i = 1; i < position && currentNode != null; i++)
                {
                    currentNode = currentNode.Next;
                }
                if (currentNode == null)
                {
                    return null;
                }
                tmpObj = currentNode.Next.Data;
                currentNode.Next = currentNode.Next.Next;
            }
            return tmpObj;
        }

        private int getLength()
        {
            return 0;
        }

        public bool isFull()
        {
            return false;
        }

        public bool isEmpty()
        {
            return (headNode == null);
        }

        public void printAllNodes()
        {
            Node curr = headNode;
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

    class SinglyLinkedList2
    {
        static void Main(string[] args)
        {

            SinglyLinkedList sl = new SinglyLinkedList();

            Console.WriteLine();
            Console.WriteLine("**Insert***");

            sl.add(6);
            sl.add(5);
            sl.add(1);
            sl.printAllNodes();

            Console.WriteLine();
            Console.WriteLine("**Insert at***");

            sl.add(2, 3);
            sl.add(2, 2); ;
            sl.add(4, 4);
            sl.add(1, 100);
            sl.printAllNodes();

            Console.WriteLine();
            Console.WriteLine("**Remove postion # 1***");
            sl.Remove(1);
            sl.printAllNodes();

            Console.WriteLine();
            Console.WriteLine("**Remove postion # 4***");
            sl.Remove(3);
            sl.printAllNodes();

            Console.ReadLine();
        }
    }
}
