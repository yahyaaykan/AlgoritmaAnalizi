using System;
using System.Collections.Generic;

namespace GezginSatıcıProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Şehirlerin koordinatlarını temsil eden bir dizi nokta
            Point[] sehirler = new Point[]
            {
                new Point(0, 0), // Şehir 1
                new Point(3, 4), // Şehir 2
                new Point(6, 8), // Şehir 3
                // ... Diğer şehirler buraya eklenebilir
            };

            // En kısa turu hesapla
            List<int> enKisaTur = GezginSatıcıTurunuBul(sehirler);

            // Turu yazdır
            Console.WriteLine("En kısa tur:");
            foreach (int sehirIndex in enKisaTur)
            {
                Console.Write(sehirIndex + " ");
            }
            Console.ReadLine();
        }

        // İki nokta arasındaki mesafeyi hesaplayan fonksiyon
        static double Mesafe(Point a, Point b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Gezgin satıcının en kısa turunu bulan fonksiyon
        static List<int> GezginSatıcıTurunuBul(Point[] sehirler)
        {
            int n = sehirler.Length;
            bool[] ziyaretEdildi = new bool[n];
            List<int> tur = new List<int>();

            // Başlangıç noktası olarak ilk şehri seç
            tur.Add(0);
            ziyaretEdildi[0] = true;

            // Diğer şehirleri ziyaret et
            for (int i = 1; i < n; i++)
            {
                int enYakinSehir = -1;
                double enKisaMesafe = double.MaxValue;

                for (int j = 0; j < n; j++)
                {
                    if (!ziyaretEdildi[j])
                    {
                        double mesafe = Mesafe(sehirler[tur[i - 1]], sehirler[j]);
                        if (mesafe < enKisaMesafe)
                        {
                            enKisaMesafe = mesafe;
                            enYakinSehir = j;
                        }
                    }
                }

                tur.Add(enYakinSehir);
                ziyaretEdildi[enYakinSehir] = true;
            }

            // Son şehri başlangıç noktasına dön
            tur.Add(0);

            return tur;
        }
    }

    // Nokta sınıfı
    class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
