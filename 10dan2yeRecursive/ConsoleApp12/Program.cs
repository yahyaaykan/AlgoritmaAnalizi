using System;

class Program
{
    static void Main()
    {
        Console.Write("10'luk sayıyı giriniz: "); // Kullanıcıdan 10'luk bir sayı istenir.
        int onlukSayi = Convert.ToInt32(Console.ReadLine());
        string ikilikSayi = OnlukDanIkilikRecursive(onlukSayi);  // Onluk sayıyı ikilik sayı sistemine çevirmek için fonksiyon çağrılır.
        Console.WriteLine("2'lik sayı sistemi: " + ikilikSayi); // Sonucu ekrana yazdırılır.
    }
    static string OnlukDanIkilikRecursive(int onlukSayi) // Onluk sayıyı ikilik sayı sistemine dönüştüren Recursive fonksiyon
    {
        if (onlukSayi == 0) // Eğer onluk sayı 0 ise, ikilik sayı da 0'dır.
        {
            return "0";
        }
        return OnlukDanIkilikRecursive(onlukSayi / 2) + (onlukSayi % 2); // Onluk sayıyı 2'ye böler ve kalanı toplar.
        
    }
}
