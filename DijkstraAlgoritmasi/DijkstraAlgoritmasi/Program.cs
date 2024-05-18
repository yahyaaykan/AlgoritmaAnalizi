using System;

class Dijkstra
{
    public static int[] DijkstraAlgoritmasi(int[][] grafik, int kaynak)
    {
        int V = grafik.Length; // Grafikteki düğüm sayısını al
        int[] mesafe = new int[V]; // Kaynaktan olan mesafeleri tutan dizi
        bool[] enKisaYolKumesi = new bool[V]; // Kısa yolu bulunmuş düğümleri işaretlemek için dizi

        for (int i = 0; i < V; i++)
            mesafe[i] = int.MaxValue; // Başlangıçta tüm mesafeleri sonsuz yap

        mesafe[kaynak] = 0; // Kaynağın mesafesini 0 yap

        for (int sayac = 0; sayac < V - 1; sayac++)
        {
            int u = MinimumMesafe(mesafe, enKisaYolKumesi); // İşlenmemiş düğümler arasından minimum mesafeye sahip olanı bul
            enKisaYolKumesi[u] = true; // Bu düğümü işlenmiş olarak işaretle

            // Tüm düğümleri kontrol et
            for (int v = 0; v < V; v++)
                // Eğer düğüm işlenmemişse, arada kenar varsa ve yeni mesafe daha küçükse güncelle
                if (!enKisaYolKumesi[v] && grafik[u][v] != 0 && mesafe[u] + grafik[u][v] < mesafe[v])
                    mesafe[v] = mesafe[u] + grafik[u][v]; // Mesafeyi güncelle
        }

        return mesafe; // Kaynaktan tüm düğümlere olan mesafeleri döndür
    }

    private static int MinimumMesafe(int[] mesafe, bool[] set)
    {
        int min = int.MaxValue, minIndex = -1; // Minimum mesafeyi ve indeksini başlat

        // Tüm düğümleri kontrol et
        for (int v = 0; v < mesafe.Length; v++)
            // Eğer düğüm işlenmemişse ve mesafe mevcut minimumdan küçükse güncelle
            if (!set[v] && mesafe[v] < min)
            {
                min = mesafe[v];
                minIndex = v;
            }

        return minIndex; // Minimum mesafeye sahip düğümün indeksini döndür
    }

    static void Main()
    {
        // Grafiği matris olarak tanımla
        int[][] grafik = {
            new int[] { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
            new int[] { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
            new int[] { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
            new int[] { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
            new int[] { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
            new int[] { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
            new int[] { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
            new int[] { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
        };

        int kaynak = 0; // Kaynak düğümü belirle
        int[] mesafeler = DijkstraAlgoritmasi(grafik, kaynak); // Dijkstra algoritmasını çalıştır

        Console.WriteLine("Düğüm \t Kaynaktan Mesafe");
        for (int i = 0; i < mesafeler.Length; i++)
            Console.WriteLine(i + " \t\t " + mesafeler[i]); // Sonuçları yazdır

        Console.ReadLine();
    }
}
