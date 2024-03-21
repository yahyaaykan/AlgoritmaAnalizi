using System;

class EnKisaCarpmaA
{
    // En Kisa çarpma algoritması
    public static int EnKisaCarpma(int x, int y)
    {
        // Sayıların basamak sayısını belirle
        int n = Math.Max(x.ToString().Length, y.ToString().Length);

        // Eğer sayılar çok küçükse klasik çarpma yap
        if (n < 10)
            return x * y;

        // Sayıları ikiye bölmek için gereken basamak sayısını hesapla
        n = (n / 2) + (n % 2);

        // M değeri hesaplanarak kullanılacak
        int m = (int)Math.Pow(10, n);

        // Sayıları parçalara ayır
        int b = x / m;
        int a = x - (b * m);
        int d = y / m;
        int c = y - (d * m);

        // Carpma algoritması için tekrar çağrı yaparak çarpma işlemlerini gerçekleştir
        int z0 = EnKisaCarpma(a, c);
        int z1 = EnKisaCarpma(a + b, c + d);
        int z2 = EnKisaCarpma(b, d);

        // Sonuçları birleştirerek döndür
        return z0 + ((z1 - z0 - z2) * m) + (z2 * (int)Math.Pow(10, 2 * n));
    }

    static void Main(string[] args)
    {
        // Çarpılacak sayıları belirle
        int A = 2135;
        int B = 4014;

        // çarpma algoritmasını kullanarak sonucu hesapla
        int sonuc = EnKisaCarpma(A, B);

        // Sonucu ekrana yazdır
        Console.WriteLine("A * B = " + sonuc);
        Console.ReadLine();
    }
}
