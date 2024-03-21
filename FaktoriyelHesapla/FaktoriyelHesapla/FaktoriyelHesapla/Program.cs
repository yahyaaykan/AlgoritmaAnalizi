using System;

class Program
{
    static int FaktoriyelIteratif(int n)
    {
        int sonuc = 1;
        for (int i = 2; i <= n; i++)
        {
            sonuc *= i;
        }
        return sonuc;
    }

    static void Main(string[] args)
    {
        Console.Write("Faktöriyelini almak istediğiniz sayıyı girin:");
        int sayi = Convert.ToInt32(Console.ReadLine());
        int faktoriyel = FaktoriyelIteratif(sayi);
        Console.Write("Iteratif Yaklaşım: " + sayi + " sayısının faktöriyeli:  " + faktoriyel);
        Console.ReadLine();
    }
}
