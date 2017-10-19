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
            public Node root;
            private int count = 10;

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

            public void Delete(int data)
            {
                root = Delete(root, data);
            }

            public Node Delete(Node root, int data)
            {
                if (root == null) return root;
                else if (data < root.Data)
                {
                    root.LeftChild = Delete(root.LeftChild, data);
                }
                else if (data > root.Data)
                {
                    root.RightChild = Delete(root.RightChild, data);
                }
                else
                {
                    //Case 1: No Child
                    if ((root.LeftChild == null) && (root.RightChild == null))
                    {
                        root = null;
                    }
                    //Case 2: One Child
                    else if (root.LeftChild == null)
                    {
                        Node temp = root;
                        root = root.RightChild;
                        temp = null;
                    }
                    else if (root.RightChild == null)
                    {
                        Node temp = root;
                        root = root.LeftChild;
                        temp = null;
                    }
                    //Case 2: Two Child
                    else
                    {
                        Node temp = MinValueBST(root.RightChild);
                        root.Data = temp.Data;
                        root.RightChild = Delete(root.RightChild, temp.Data);
                        //temp = null;
                    }
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

            public void PreOrder(Node root)
            {
                if (root == null) return;
                Console.Write(root.Data + " ");
                PreOrder(root.LeftChild);
                PreOrder(root.RightChild);
            }

            public void InOrder(Node root)
            {
                if (root == null) return;
                InOrder(root.LeftChild);
                Console.Write(root.Data + " ");
                InOrder(root.RightChild);
            }

            public void PostOrder(Node root)
            {
                if (root == null) return;
                PostOrder(root.LeftChild);
                PostOrder(root.RightChild);
                Console.Write(root.Data + " ");
            }

            public void LevelOrder(Node root)
            {
                if (root == null) return;
                Queue<Node> q = new Queue<Node>();
                q.Enqueue(root);
                while (q.Count != 0)
                {
                    root = q.Dequeue();
                    Console.Write(root.Data + " ");

                    if (root.LeftChild != null)
                    {
                        q.Enqueue(root.LeftChild);
                    }

                    if (root.RightChild != null)
                    {
                        q.Enqueue(root.RightChild);
                    }
                }
            }

            public Node MinValueBST(Node root)
            {
                if ((root == null) || (root.LeftChild == null))
                {
                    return root;
                }
                root = MinValueBST(root.LeftChild);
                return root;
            }

            public Node MaxValueBST(Node root)
            {
                if ((root == null) || (root.RightChild == null))
                {
                    return root;
                }
                root = MaxValueBST(root.RightChild);
                return root;
            }

            public int HeightBST(Node root)
            {
                if (root == null)
                {
                    return -1;
                }

                return Math.Max(HeightBST(root.LeftChild), HeightBST(root.RightChild)) + 1;
            }

            public int SizeBST(Node root)
            {
                if (root == null)
                    return 0;
                return SizeBST(root.LeftChild) + SizeBST(root.RightChild) + 1;
            }

            void printUtil(Node root, int space)
            {
                if (root == null)
                    return;

                space += count;

                // Process right child first
                printUtil(root.RightChild, space);
                Console.Write("\n");
                for (int i = count; i < space; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(root.Data);

                // Process left child
                printUtil(root.LeftChild, space);
            }

            public void Print()
            {
                printUtil(root, 0);
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
            tree.Add(1);
            tree.Add(3);
            tree.Add(-1);
            tree.Add(-2);

            tree.Print();
            //Console.WriteLine(tree.Search(2));
            //Console.WriteLine(tree.Search(100));

            //Console.WriteLine("PreOrder Traversal");
            //tree.PreOrder(tree.root);
            //Console.WriteLine("\nInOrder Traversal");
            //tree.InOrder(tree.root);
            //Console.WriteLine("\nPostOrder Traversal");
            //tree.PostOrder(tree.root);
            Console.WriteLine("\nLevelOrder Traversal");
            tree.LevelOrder(tree.root);


            //Node minValue = tree.MinValueBST(tree.root);
            //Console.WriteLine("\nMin Value of BST is {0}", minValue.Data);

            //Node maxValue = tree.MaxValueBST(tree.root);
            //Console.WriteLine("\nMax Value of BST is {0}", maxValue.Data);

            //int heightBST = tree.HeightBST(tree.root);
            //Console.WriteLine("\nHeight of the BST is {0}", heightBST);

            //int sizeBST = tree.SizeBST(tree.root);
            //Console.WriteLine("\nSize of the BST is {0}", sizeBST);
            
            //Console.WriteLine("\nBefore Deleting");
            //tree.Print();

            //Console.WriteLine("\nAfter Deleting");
            //tree.Delete(34);
            //tree.Print();
            Console.ReadLine();
        }
    }
}