using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BinarySearchTree
    {
        public class Node
        {
            private int data;
            private Node leftChild;
            private Node rightChild;

            public Node()
            {
                data = 0;
                leftChild = null;
                rightChild = null;
            }

            public Node(int d)
            {
                data = d;
                leftChild = null;
                rightChild = null;
            }
            public Node(Node lc, int d, Node rc)
            {
                data = d;
                leftChild = lc;
                rightChild = rc;
            }

            public int Data
            {
                get { return this.data; }
                set { this.data = value; }
            }

            public Node LeftChild
            {
                get { return this.leftChild; }
                set { this.leftChild = value; }
            }

            public Node RightChild
            {
                get { return this.rightChild; }
                set { this.rightChild = value; }
            }
        }

        public class BST
        {
            Node root;

            public BST()
            {
                root = null;
            }

            public void Add(int data)
            {
                root = Add(root, data);
            }

            private Node Add(Node root, int data)
            {

                if (root == null)
                {
                    root = new Node(data);
                }
                else if (root.Data > data)
                {
                    root.LeftChild = Add(root.LeftChild, data);
                }
                else if (root.Data < data)
                {
                    root.RightChild = Add(root.RightChild, data);
                }
                return root;
            }

            public bool Search(int text)
            {
                return Search(root, text);
            }

            public bool Search(Node node, int searchText)
            {
                bool found = false;
                while ((node != null) && (!found))
                {
                    if (node.Data > searchText)
                        node = node.LeftChild;
                    else if (node.Data < searchText)
                        node = node.RightChild;
                    else
                    {
                        found = true;
                        break;
                    }
                    found = Search(node, searchText);
                }
                return found;
            }

            void printUtil(Node root)
            {
                if (root == null)
                    return;

                // Process right child first
                printUtil(root.RightChild);
                Console.WriteLine(root.Data);

                // Process left child
                printUtil(root.LeftChild);
            }

            public void Print()
            {
                printUtil(root);
            }

        }

        static void Main(string[] args)
        {
            BST tree = new BST();
            tree.Add(5);
            tree.Add(2);
            tree.Add(34);
            tree.Add(18);
            tree.Add(55);
            tree.Add(-1);
            tree.Add(-2);

            tree.Print();
            Console.WriteLine(tree.Search(2));
            Console.WriteLine(tree.Search(100));
            Console.ReadLine();
        }
    }
}
