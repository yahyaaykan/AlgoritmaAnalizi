using System;

class Program
{
    // Rekürsif matris çarpımı fonksiyonu
    static int[,] MatrisCarpimiRekursive(int[,] A, int[,] B, int boyut)
    {
        int[,] C = new int[boyut, boyut]; // Sonuç matrisini oluştur
        return MatrisCarpimiRekursive(A, B, C, boyut, 0, 0, 0); // Yardımcı rekürsif fonksiyonu çağır
    }

    // Yardımcı rekürsif fonksiyon
    static int[,] MatrisCarpimiRekursive(int[,] A, int[,] B, int[,] C, int boyut, int i, int j, int k)
    {
        // Matris boyutunu kontrol et
        if (i >= boyut) return C;

        // Matris çarpımını hesapla
        if (j < boyut)
        {
            if (k < boyut)
            {
                C[i, j] += A[i, k] * B[k, j]; // Çarpma işlemi
                return MatrisCarpimiRekursive(A, B, C, boyut, i, j, k + 1); // Bir sonraki elemana geç
            }
            else
                return MatrisCarpimiRekursive(A, B, C, boyut, i, j + 1, 0); // Bir sonraki satıra geç
        }
        else
            return MatrisCarpimiRekursive(A, B, C, boyut, i + 1, 0, 0); // Bir sonraki satıra geç
    }

    static void Main(string[] args)
    {
        int boyut = 2; // Örnek olarak 2x2 boyutunda matrisler kullanalım

        int[,] A = { { 1, 2 }, { 3, 4 } }; // İlk matris
        int[,] B = { { 5, 6 }, { 7, 8 } }; // İkinci matris

        int[,] C = MatrisCarpimiRekursive(A, B, boyut); // Rekürsif matris çarpımı

        Console.WriteLine("Rekürsif Yaklaşım:"); // Sonucu ekrana yazdır
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
