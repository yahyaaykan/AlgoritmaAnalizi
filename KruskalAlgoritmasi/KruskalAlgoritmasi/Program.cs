using System;

class Kruskal
{
    // Kenar sınıfı, kenar bilgilerini tutar ve IComparable arayüzünü uygular
    class Kenar : IComparable<Kenar>
    {
        public int Kaynak, Hedef, Agirlik; // Kenar bilgileri
        public int CompareTo(Kenar k) => Agirlik - k.Agirlik; // Ağırlığa göre sıralama
    }

    // AltKume sınıfı, alt küme bilgilerini tutar
    class AltKume
    {
        public int Ust, Derece; // Alt küme bilgileri
    }

    int V, E; // Düğüm ve kenar sayıları
    Kenar[] kenar; // Kenarlar dizisi

    // Kurucu metot, düğüm ve kenar sayısını alır ve kenar dizisini başlatır
    Kruskal(int v, int e)
    {
        V = v;
        E = e;
        kenar = new Kenar[E]; // Kenar dizisini başlat
        for (int i = 0; i < e; i++) kenar[i] = new Kenar(); // Kenarları başlat
    }

    // Belirtilen düğümün üst düğümünü bulur
    int Find(AltKume[] altKumeler, int i)
    {
        if (altKumeler[i].Ust != i) altKumeler[i].Ust = Find(altKumeler, altKumeler[i].Ust); // Üst düğüm bulma
        return altKumeler[i].Ust;
    }

    // İki alt küme arasında birleştirme işlemi yapar
    void Union(AltKume[] altKumeler, int x, int y)
    {
        int xKok = Find(altKumeler, x), yKok = Find(altKumeler, y); // Kökleri bul
        if (altKumeler[xKok].Derece < altKumeler[yKok].Derece) altKumeler[xKok].Ust = yKok; // Birleştirme işlemi
        else if (altKumeler[xKok].Derece > altKumeler[yKok].Derece) altKumeler[yKok].Ust = xKok;
        else { altKumeler[yKok].Ust = xKok; altKumeler[xKok].Derece++; } // Dereceye göre birleştirme işlemi
    }

    // Kruskal algoritması ile minimum kapsayan ağacı bulur
    void KruskalMST()
    {
        var sonuc = new Kenar[V]; // Sonuç dizisi
        int e = 0, i = 0;
        for (; i < V; ++i) sonuc[i] = new Kenar(); // Sonuç dizisini başlat
        Array.Sort(kenar); // Kenarları ağırlıklarına göre sırala

        var altKumeler = new AltKume[V]; // Alt kümeler dizisi
        for (i = 0; i < V; ++i) altKumeler[i] = new AltKume { Ust = i, Derece = 0 }; // Alt kümeleri başlat

        i = 0;
        while (e < V - 1)
        {
            var k = kenar[i++]; // Kenarı al
            int x = Find(altKumeler, k.Kaynak), y = Find(altKumeler, k.Hedef); // Kenarın köklerini bul
            if (x != y) { sonuc[e++] = k; Union(altKumeler, x, y); } // Kenarı sonuca ekle ve kümeleri birleştir
        }

        Console.WriteLine("Minimum Kapsayan Ağaçtaki Kenarlar:");
        for (i = 0; i < e; ++i) Console.WriteLine($"{sonuc[i].Kaynak} -- {sonuc[i].Hedef} == {sonuc[i].Agirlik}"); // Sonucu yazdır
    }

    static void Main()
    {
        int V = 4, E = 5; // Düğüm ve kenar sayıları
        var g = new Kruskal(V, E); // Kruskal nesnesi oluştur
        // Kenarların bilgilerini ata
        g.kenar[0] = new Kenar { Kaynak = 0, Hedef = 1, Agirlik = 10 };
        g.kenar[1] = new Kenar { Kaynak = 0, Hedef = 2, Agirlik = 6 };
        g.kenar[2] = new Kenar { Kaynak = 0, Hedef = 3, Agirlik = 5 };
        g.kenar[3] = new Kenar { Kaynak = 1, Hedef = 3, Agirlik = 15 };
        g.kenar[4] = new Kenar { Kaynak = 2, Hedef = 3, Agirlik = 4 };
        g.KruskalMST(); // MST'yi bul
        Console.ReadLine();
    }
}
