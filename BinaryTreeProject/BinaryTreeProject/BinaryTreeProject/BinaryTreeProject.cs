using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeProject
{
    internal class BinaryTreeProject
    {
        public class BinarySearchTree
        {
            private class Node
            {
                public int data;
                public Node left, right;

                public Node(int item)
                {
                    data = item;
                    left = right = null;
                }
            }

            private Node root;

            public BinarySearchTree()
            {
                root = null;
            }

            public void Insert(int data)
            {
                root = InsertRec(root, data);
            }

            private Node InsertRec(Node root, int data)
            {
                if (root == null)
                {
                    root = new Node(data);
                    return root;
                }

                if (data < root.data)
                    root.left = InsertRec(root.left, data);
                else if (data > root.data)
                    root.right = InsertRec(root.right, data);

                return root;
            }

            public void Delete(int data)
            {
                root = DeleteRec(root, data);
            }

            private Node DeleteRec(Node root, int data)
            {
                if (root == null)
                    return root;

                if (data < root.data)
                    root.left = DeleteRec(root.left, data);
                else if (data > root.data)
                    root.right = DeleteRec(root.right, data);
                else
                {
                    if (root.left == null)
                        return root.right;
                    else if (root.right == null)
                        return root.left;

                    root.data = MinValue(root.right);

                    root.right = DeleteRec(root.right, root.data);
                }

                return root;
            }

            private int MinValue(Node root)
            {
                int minValue = root.data;
                while (root.left != null)
                {
                    minValue = root.left.data;
                    root = root.left;
                }
                return minValue;
            }

            public bool Search(int data)
            {
                return SearchRec(root, data);
            }

            private bool SearchRec(Node root, int data)
            {
                if (root == null)
                    return false;

                if (data == root.data)
                    return true;

                return data < root.data ? SearchRec(root.left, data) : SearchRec(root.right, data);
            }

            public int FindMin()
            {
                if (root == null)
                    throw new InvalidOperationException("Tree is empty");

                Node current = root;
                while (current.left != null)
                {
                    current = current.left;
                }
                return current.data;
            }

            public int FindMax()
            {
                if (root == null)
                    throw new InvalidOperationException("Tree is empty");

                Node current = root;
                while (current.right != null)
                {
                    current = current.right;
                }
                return current.data;
            }

            public void InOrderTraversal()
            {
                InOrderTraversalRec(root);
            }

            private void InOrderTraversalRec(Node root)
            {
                if (root != null)
                {
                    InOrderTraversalRec(root.left);
                    Console.Write(root.data + " ");
                    InOrderTraversalRec(root.right);
                }
            }

            public void PreOrderTraversal()
            {
                PreOrderTraversalRec(root);
            }

            private void PreOrderTraversalRec(Node root)
            {
                if (root != null)
                {
                    Console.Write(root.data + " ");
                    PreOrderTraversalRec(root.left);
                    PreOrderTraversalRec(root.right);
                }
            }

            public void PostOrderTraversal()
            {
                PostOrderTraversalRec(root);
            }
            private void PostOrderTraversalRec(Node root)
            {
                if (root != null)
                {
                    PostOrderTraversalRec(root.left);
                    PostOrderTraversalRec(root.right);
                    Console.Write(root.data + " ");
                }
            }
        }
    }
}
