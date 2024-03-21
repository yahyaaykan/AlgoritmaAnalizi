using System;

class Program
{
    static int N = 4; // Şehir sayısı
    static int[,] mesafeler = new int[,]
    {
        {0, 10, 15, 20},
        {10, 0, 35, 25},
        {15, 35, 0, 30},
        {20, 25, 30, 0}
    };

    static int EnKisaYolMaliyeti(int mevcutSehir, bool[] ziyaretEdilenSehirler)
    {
        // Tüm şehirleri ziyaret ettiğimizi kontrol ediyoruz
        bool hepsiZiyaretEdildi = true;
        for (int i = 0; i < N; i++)
        {
            if (!ziyaretEdilenSehirler[i])
            {
                hepsiZiyaretEdildi = false;
                break;
            }
        }
        if (hepsiZiyaretEdildi)
        {
            return mesafeler[mevcutSehir, 0]; // Başlangıç şehrine dönme maliyeti
        }

        int minMaliyet = int.MaxValue;

        // Henüz ziyaret edilmemiş şehirleri kontrol ediyoruz
        for (int sehir = 0; sehir < N; sehir++)
        {
            if (!ziyaretEdilenSehirler[sehir])
            {
                // Şehri ziyaret ediyoruz
                ziyaretEdilenSehirler[sehir] = true;
                // Şehri ziyaret etmek için gereken maliyeti hesaplıyoruz
                int maliyet = mesafeler[mevcutSehir, sehir] + EnKisaYolMaliyeti(sehir, ziyaretEdilenSehirler);
                // Minimum maliyeti güncelliyoruz
                minMaliyet = Math.Min(minMaliyet, maliyet);
                // Geri dönüşte şehri ziyaret etmemizi kaldırıyoruz
                ziyaretEdilenSehirler[sehir] = false;
            }
        }

        return minMaliyet;
    }

    static void Main(string[] args)
    {
        bool[] ziyaretEdilenSehirler = new bool[N];
        ziyaretEdilenSehirler[0] = true; // Baş
    }
}