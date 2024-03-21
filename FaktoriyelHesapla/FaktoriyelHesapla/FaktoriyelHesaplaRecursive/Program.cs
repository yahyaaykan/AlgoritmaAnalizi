using System;

class Program
{
    static int FaktoriyelRekursive(int n)
    {
        if (n == 0)
            return 1;
        else
            return n * FaktoriyelRekursive(n - 1);
    }

    static void Main(string[] args)
    {
        Console.Write("Faktöriyelini almak istediğiniz sayıyı girin: ");
        int sayi = Convert.ToInt32(Console.ReadLine());
        int faktoriyel = FaktoriyelRekursive(sayi);
        Console.Write("Rekursive Yaklaşım: " + sayi + " sayısının faktöriyeli:  " + faktoriyel);
        Console.ReadLine();
    }
}
