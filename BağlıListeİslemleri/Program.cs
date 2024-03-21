using System;
using System.Collections.Generic;
using System.Linq;

public class Ogrenci
{
    public int OgrenciNo { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Ogrenci> ogrenciListesi = new List<Ogrenci>();

        while (true)
        {
            Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçin:");
            Console.WriteLine("Öğrenci Eklemek için 1'e basınız.");
            Console.WriteLine("Baştan Silmek için 2'ye basınız.");
            Console.WriteLine("Sondan Silmek için 3'e basınız.");
            Console.WriteLine("Öğrenci Silmek için 4'e basınız.");
            Console.WriteLine("Öğrenci Aramak için 5'e basınız.");
            Console.WriteLine("Listeyi Görüntülemek için 6'ya basınız.");
            Console.WriteLine("Çıkış yapmak için 7'e basınız.");
            Console.Write("Yapmak istediğiniz işlemi giriniz ( 1 | 2 | 3 | 4 | 5 | 6 | 7 ): ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Ekle(ogrenciListesi);
                    break;

                case "2":
                    BastanSil(ogrenciListesi);
                    break;

                case "3":
                    SondanSil(ogrenciListesi);
                    break;

                case "4":
                    Sil(ogrenciListesi);
                    break;

                case "5":
                    Ara(ogrenciListesi);
                    break;

                case "6":
                    ListeyiGoruntule(ogrenciListesi);
                    break;

                case "7":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\nGeçersiz seçenek, lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    static void Ekle(List<Ogrenci> liste)
    {
        Console.Write("Öğrenci No: ");
        int ogrenciNo = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ad: ");
        string ad = Console.ReadLine();

        Console.Write("Soyad: ");
        string soyad = Console.ReadLine();
        liste.Add(new Ogrenci { OgrenciNo = ogrenciNo, Ad = ad, Soyad = soyad });
    }

    static void Sil(List<Ogrenci> liste)
    {
        Console.Write("Silmek istediğiniz öğrenci no'sunu girin: ");
        int silinecekNo = Convert.ToInt32(Console.ReadLine());
        liste.RemoveAll(ogrenci => ogrenci.OgrenciNo == silinecekNo);
    }

    static void BastanSil(List<Ogrenci> liste)
    {
        if (liste.Count > 0)
        {
            liste.RemoveAt(0);
            Console.WriteLine("\n Baştaki öğrenci silindi.");
        }
        else
        {
            Console.WriteLine("\n Liste boş, baştaki öğrenci silinemedi.");
        }
    }

    static void SondanSil(List<Ogrenci> liste)
    {
        if (liste.Count > 0)
        {
            liste.RemoveAt(liste.Count - 1);
            Console.WriteLine("\n Sondaki öğrenci silindi.");
        }
        else
        {
            Console.WriteLine("\n Liste boş, sondaki öğrenci silinemedi.");
        }
    }

    static void Ara(List<Ogrenci> liste)
    {
        Console.Write("Aramak istediğiniz öğrenci no'sunu girin: ");
        int aranacakNo = Convert.ToInt32(Console.ReadLine());
        var arananOgrenci = liste.FirstOrDefault(ogrenci => ogrenci.OgrenciNo == aranacakNo);

        if (arananOgrenci != null)
            Console.WriteLine($"\nAranan Öğrenci: No: {arananOgrenci.OgrenciNo}, Ad: {arananOgrenci.Ad}, Soyad: {arananOgrenci.Soyad}");
        else
            Console.WriteLine("\nAranan öğrenci bulunamadı.");
    }

    static void ListeyiGoruntule(List<Ogrenci> liste)
    {
        Console.WriteLine("\n\n\n +  Öğrenci Listesi :   ");
        foreach (var ogrenci in liste)
        {
            Console.WriteLine($"No: {ogrenci.OgrenciNo}, Ad: {ogrenci.Ad}, Soyad: {ogrenci.Soyad}");
        }
    }
}
