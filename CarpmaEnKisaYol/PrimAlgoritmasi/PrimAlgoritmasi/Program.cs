using System;

class Prim
{
    // MinimumMesafe metodu, verilen mesafeler arasında minimum mesafeyi bulur
    private static int MinimumMesafe(int[] mesafe, bool[] mstSet, int V)
    {
        int min = int.MaxValue, minIndex = -1;

        // Tüm düğümleri dolaşarak minimum mesafeyi bul
        for (int v = 0; v < V; v++)
            if (!mstSet[v] && mesafe[v] < min)
            {
                min = mesafe[v];
                minIndex = v;
            }

        return minIndex; // Minimum mesafeli düğümün indisini döndür
    }

    // PrimAlgoritmasi metodu, verilen grafik üzerinde Prim algoritmasını uygular
    private static void PrimAlgoritmasi(int[,] grafik, int V)
    {
        int[] mst = new int[V]; // Minimum kapsayan ağacı tutmak için
        int[] mesafe = new int[V]; // Kaynaktan olan mesafeler
        bool[] mstSet = new bool[V]; // Minimum kapsayan ağaca dahil olan düğümler

        // Başlangıç ayarlamaları
        for (int i = 0; i < V; i++)
        {
            mesafe[i] = int.MaxValue; // Tüm mesafeleri sonsuz yap
            mstSet[i] = false; // Henüz hiçbir düğüm işlenmedi
        }

        mesafe[0] = 0; // Kaynağın mesafesi 0

        // Tüm düğümleri dolaşarak minimum kapsayan ağacı oluştur
        for (int sayac = 0; sayac < V - 1; sayac++)
        {
            int u = MinimumMesafe(mesafe, mstSet, V); // Minimum mesafeli düğümü bul
            mstSet[u] = true; // Bu düğümü işlenmiş olarak işaretle

            // Düğümleri güncelle
            for (int v = 0; v < V; v++)
                if (grafik[u, v] != 0 && !mstSet[v] && grafik[u, v] < mesafe[v])
                {
                    mst[v] = u;
                    mesafe[v] = grafik[u, v]; // Mesafeyi güncelle
                }
        }

        // Sonucu yazdır
        Console.WriteLine("Kenar \t Ağırlık");
        for (int i = 1; i < V; i++)
            Console.WriteLine($"{mst[i]} - {i}\t{grafik[i, mst[i]]}");
    }

    // Main metodu, programın giriş noktasıdır
    static void Main()
    {
        int V = 5; // Düğüm sayısı
        int[,] grafik = new int[,] {
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }
        };

        PrimAlgoritmasi(grafik, V); // Prim algoritmasıyla minimum kapsayan ağacı oluştur
        Console.ReadLine();
    }
}
