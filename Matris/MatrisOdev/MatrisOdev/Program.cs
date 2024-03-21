using System;

class Program
{
    // Iteratif matris çarpımı fonksiyonu
    static int[,] MatrisCarpimiIteratif(int[,] A, int[,] B)
    {
        int boyut = A.GetLength(0); // Matris boyutunu al
        int[,] C = new int[boyut, boyut]; // Sonuç matrisini oluştur

        // Matris çarpımı işlemi
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                C[i, j] = 0; // Sonuç matrisinin her elemanını sıfırla
                for (int k = 0; k < boyut; k++)
                {
                    C[i, j] += A[i, k] * B[k, j]; // Çarpım işlemi
                }
            }
        }

        return C; // Sonuç matrisini döndür
    }

    static void Main(string[] args)
    {
        int boyut = 2; // Örnek olarak 2x2 boyutunda matrisler kullanalım

        int[,] A = { { 1, 2 }, { 3, 4 } }; // İlk matris
        int[,] B = { { 5, 6 }, { 7, 8 } }; // İkinci matris

        int[,] C = MatrisCarpimiIteratif(A, B); // Iteratif matris çarpımı

        Console.WriteLine("Iteratif Yaklaşım:"); // Sonucu ekrana yazdır
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                Console.Write(C[i, j] + " "); // Sonuç matrisini yazdır
            }
            Console.WriteLine();
        }
    Console.ReadLine();
    }
    
}
