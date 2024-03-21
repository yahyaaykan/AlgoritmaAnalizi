using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Dizinin eleman sayısını giriniz: "); // Kullanıcıdan dizinin eleman sayısını alıyoruz.
        int n = Convert.ToInt32(Console.ReadLine());

        
        int[] dizi = new int[n]; // Dizimizi Oluşturuyoruz.

       
        for (int i = 0; i < n; i++)  // Kullanıcıdan dizinin elemanlarını alıyourz.
        {
            Console.Write("Dizinin "+ (i+1)+". elemanını giriniz: ");
            dizi[i] = Convert.ToInt32(Console.ReadLine());
        }

       
        int enBuyuk = EnBuyukSayi(dizi);  // En büyük sayıyı bul

       
        Console.WriteLine("Dizideki en büyük sayı: "+ enBuyuk);  // Sonucu ekrana yazdırıyoruz.
    }

    // Dizideki en büyük sayıyı bulan fonksiyon
    static int EnBuyukSayi(int[] dizi)
    {
        
        int enBuyuk = dizi[0]; // Başlangıçta en büyük sayıyı ilk eleman olarak alıp hepsi ile karşılaştırıyoruz.

       
        for (int i = 1; i < dizi.Length; i++)  // Diziyi tarıyoruz.
        {
            if (dizi[i] > enBuyuk)
            {
                enBuyuk = dizi[i];
            }
        }

       
        return enBuyuk;  // En büyük sayıyı döndürür.
    }
}
