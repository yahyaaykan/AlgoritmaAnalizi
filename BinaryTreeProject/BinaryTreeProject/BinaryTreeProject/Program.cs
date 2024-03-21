using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BinaryTreeProject.BinaryTreeProject;

namespace BinaryTreeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();

            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            Console.WriteLine("Minimum Değer: " + tree.FindMin());
            Console.WriteLine("Maksimum Değer: " + tree.FindMax());

            Console.WriteLine("Ağaçta 40 var mı? " + tree.Search(40));
            Console.WriteLine("Ağaçta 90 var mı? " + tree.Search(90));

            tree.Delete(20);
            Console.WriteLine("20 değeri silindi.");

            tree.Delete(30);
            Console.WriteLine("30 değeri silindi.");

            Console.WriteLine("Minimum Değer: " + tree.FindMin());
            Console.WriteLine("Maksimum Değer: " + tree.FindMax());

            Console.WriteLine("Inorder Dolaşma:");
            tree.InOrderTraversal();
            Console.WriteLine("\n\nPreorder Dolaşma:");
            tree.PreOrderTraversal();
            Console.WriteLine("\n\nPostorder Dolaşma:");
            tree.PostOrderTraversal();

            Console.ReadLine();
        }
    }
}
