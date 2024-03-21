using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VeriYapilariYAHYAAYKAN.Program;

namespace VeriYapilariYAHYAAYKAN
{
    internal class Program
    {
        // Öğrenci sınıfı, her bir öğrencinin özelliklerini içerir
        public class Ogrenci
        {
            public int OgrenciNo { get; set; }
            public string Ad { get; set; }
            public string Bolum { get; set; }

            // Öğrenci sınıfının yapıcı metodu, öğrenci özelliklerini başlatır
            public Ogrenci(int ogrenciNo, string ad, string bolum)
            {
                this.OgrenciNo = ogrenciNo;
                this.Ad = ad;
                this.Bolum = bolum;
            }
        }

        // Bağlı liste düğümü
        public class Node
        {
            public Ogrenci Veri { get; set; }
            public Node Next { get; set; }

            // Düğüm yapıcısı, veriye erişimi ve bir sonraki düğümü tanımlar
            public Node(Ogrenci ogrenci)
            {
                Veri = ogrenci;
                Next = null;
            }
        }

        // Bağlı liste işlemlerini yapan sınıf
        public class BagliListe
        {
            public Node Bas { get; set; }
            public Node Son { get; set; }

            // Bağlı liste yapısını başlatır, baş ve son düğümleri null olarak ayarlar
            public BagliListe()
            {
                Bas = null;
                Son = null;
            }


            // SonunaEkle metodu, bağlı listenin sonuna yeni bir öğrenci düğümü ekler
            public void SonunaEkle(Ogrenci ogrenci)
            {
                // Yeni bir düğüm oluşturulur ve veri ile başlatılır
                Node yeniDugum = new Node(ogrenci);

                // Eğer liste boşsa, yeni düğüm hem baş hem de son olarak atanır
                if (Bas == null)
                {
                    Bas = yeniDugum;
                    Son = yeniDugum;
                }
                else
                {
                    // Liste boş değilse, son düğümün Next özelliği yeni düğümü gösterir ve yeni düğüm son olarak atanır
                    Son.Next = yeniDugum;
                    Son = yeniDugum;
                }
            }


            // Baştan ekleme metodu, bağlı listenin başına yeni bir öğrenci düğümü ekler
            public void BasaEkle(Ogrenci ogrenci)
            {
                // Yeni bir düğüm oluşturulur ve veri ile başlatılır
                Node yeniDugum = new Node(ogrenci);

                // Yeni düğümün Next özelliği listenin başını gösterir, ardından yeni düğüm baş olarak atanır
                yeniDugum.Next = Bas;
                Bas = yeniDugum;
            }

            // Listenin sonuna öğrenci ekler
            public void SonaEkle(Ogrenci ogrenci)
            {
                // Yeni bir düğüm oluşturulur ve veri ile başlatılır
                Node yeniDugum = new Node(ogrenci);

                // Eğer liste boşsa, yeni düğüm hem başı hem de sonu gösterir
                if (Bas == null)
                {
                    Bas = yeniDugum;
                    Son = yeniDugum;
                }
                else
                {
                    // Eğer liste doluysa, son düğümün Next özelliği yeni düğümü gösterir ve son düğüm güncellenir
                    Son.Next = yeniDugum;
                    Son = yeniDugum;
                }
            }



            public void Sil(int anahtar)
            {
                Node temp = Bas; // Geçici bir düğüm oluşturulur ve liste başıyla başlatılır
                Node onceki = null; // Bir önceki düğümü saklamak için bir referans oluşturulur

                // Baş düğümü boş değilse ve anahtar, baştaki düğümün anahtarına eşitse
                if (temp != null && temp.Veri.OgrenciNo == anahtar)
                {
                    Bas = temp.Next; // Baş düğümü bir sonraki düğümü gösterecek şekilde güncellenir

                    // Baş düğüm, aynı zamanda son düğümse, son düğüm de güncellenir
                    if (temp == Son)
                    {
                        Son = Bas;
                    }
                    return; // Anahtar değeri bulunduğu için işlem tamamlanır
                }

                // Anahtar değeri bulunana veya liste sonuna gelene kadar döngü devam eder
                while (temp != null && temp.Veri.OgrenciNo != anahtar)
                {
                    onceki = temp; // Önceki düğüm geçici düğümün değerini alır
                    temp = temp.Next; // Geçici düğüm bir sonraki düğüme geçer
                }

                // Eğer anahtar değeri bulunamazsa, işlem sonlandırılır
                if (temp == null)
                {
                    return;
                }

                onceki.Next = temp.Next; // Önceki düğümün Next özelliği, silinecek düğümün Next'ini gösterir

                // Eğer silinen düğüm son düğümse, son düğüm güncellenir
                if (temp == Son)
                {
                    Son = onceki;
                }
            }


            // Bağlı listedeki tüm elemanları siler
            public void TumunuSil()
            {
                Bas = null; // Liste başını null yaparak tüm bağlı listeyi siler
                Son = null; // Liste sonunu null yaparak tüm bağlı listeyi siler
            }

            // Bağlı listedeki öğrenci bilgilerini ekrana yazdırır
            public void Yazdir()
            {
                Node mevcutDugum = Bas; // Mevcut düğüm, liste başından başlar

                // Mevcut düğüm null olana kadar döngü devam eder
                while (mevcutDugum != null)
                {
                    // Mevcut düğümün öğrenci bilgilerini ekrana yazdırır
                    Console.WriteLine("\nOgrenci No: " + mevcutDugum.Veri.OgrenciNo + ", Adi: " + mevcutDugum.Veri.Ad + ", Bolumu: " + mevcutDugum.Veri.Bolum);
                    mevcutDugum = mevcutDugum.Next; // Mevcut düğümü bir sonraki düğüme ilerletir
                }
            }


            // Bubble Sort algoritması
            // Bu algoritma, bir diziyi sıralamak için kullanılır.
            static void BubbleSort(int[] dizi)
            {
                int n = dizi.Length;

                // Dizinin tüm elemanları üzerinde geçiş yapılır
                for (int i = 0; i < n - 1; i++)
                {
                    // Dizi elemanlarını karşılaştırmak için bir iç döngü
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        // Mevcut eleman, bir sonraki elemandan büyükse yer değiştirme işlemi yapılır
                        if (dizi[j] > dizi[j + 1])
                        {
                            // Değişken kullanarak elemanların yerleri değiştirilir
                            int temp = dizi[j];
                            dizi[j] = dizi[j + 1];
                            dizi[j + 1] = temp;
                        }
                    }
                }
            }


            // Selection Sort algoritması
            // Bu algoritma, bir diziyi sıralamak için kullanılır.
            static void SelectionSort(int[] dizi)
            {
                int n = dizi.Length;

                // Dizinin tüm elemanları üzerinde geçiş yapılır
                for (int i = 0; i < n - 1; i++)
                {
                    // Minimum elemanı bulmak için geçerli indeksi kaydeder
                    int minIndex = i;

                    // Minimum elemanı bulmak için bir sonraki elemanlarla karşılaştırılır
                    for (int j = i + 1; j < n; j++)
                    {
                        // Minimum eleman bulunursa indeksi güncellenir
                        if (dizi[j] < dizi[minIndex])
                        {
                            minIndex = j;
                        }
                    }

                    // Minimum eleman bulunan elemanla yer değiştirilir
                    int temp = dizi[minIndex];
                    dizi[minIndex] = dizi[i];
                    dizi[i] = temp;
                }
            }


            // Insertion Sort algoritması
            // Bu algoritma, bir diziyi sıralamak için kullanılır.
            static void InsertionSort(int[] dizi)
            {
                int n = dizi.Length;

                // Dizinin ikinci elemanından başlanarak elemanları sıralar
                for (int i = 1; i < n; ++i)
                {
                    // İç içe döngü, sıralı alandaki elemanların yerini belirler
                    int key = dizi[i]; // Geçici olarak mevcut elemanı kaydeder
                    int j = i - 1;

                    // Key elemanını, ondan önceki sıralı alana doğru yerleştirir
                    while (j >= 0 && dizi[j] > key)
                    {
                        dizi[j + 1] = dizi[j]; // Önceki elemanı bir sonraki pozisyona kaydırır
                        j = j - 1;
                    }
                    dizi[j + 1] = key; // Doğru konuma key elemanını yerleştirir
                }
            }

            // Merge Sort algoritması
            // Bu algoritma, bir diziyi sıralamak için kullanılır ve birleştirme (merge) adımıyla çalışır.
            static void MergeSort(int[] dizi, int sol, int sag)
            {
                if (sol < sag)
                {
                    // Ortayı bulur, diziyi ikiye böler ve her iki parçayı sıralar
                    int orta = sol + (sag - sol) / 2;

                    MergeSort(dizi, sol, orta);     // Sol parçayı sıralamak için MergeSort'u çağırır
                    MergeSort(dizi, orta + 1, sag); // Sağ parçayı sıralamak için MergeSort'u çağırır

                    // İki parçayı birleştirir ve sıralı bir dizi elde eder
                    Birlestir(dizi, sol, orta, sag);
                }
            }

            // İki parçayı birleştiren yardımcı fonksiyon
            // Bu fonksiyon, iki parçayı sıralı bir şekilde birleştirir.
            static void Birlestir(int[] dizi, int sol, int orta, int sag)
            {
                int n1 = orta - sol + 1; // Sol parçanın uzunluğunu bulur
                int n2 = sag - orta;     // Sağ parçanın uzunluğunu bulur

                // Geçici diziler oluşturulur ve veriler kopyalanır
                int[] L = new int[n1];
                int[] R = new int[n2];

                // Veriler kopyalanır
                for (int i = 0; i < n1; ++i)
                {
                    L[i] = dizi[sol + i];
                }
                for (int j = 0; j < n2; ++j)
                {
                    R[j] = dizi[orta + 1 + j];
                }

                int k = sol;
                int p = 0, q = 0;

                // İki parçayı karşılaştırır ve birleştirir
                while (p < n1 && q < n2)
                {
                    if (L[p] <= R[q])
                    {
                        dizi[k] = L[p];
                        p++;
                    }
                    else
                    {
                        dizi[k] = R[q];
                        q++;
                    }
                    k++;
                }

                // Kalan elemanları diziye ekler
                while (p < n1)
                {
                    dizi[k] = L[p];
                    p++;
                    k++;
                }

                while (q < n2)
                {
                    dizi[k] = R[q];
                    q++;
                    k++;
                }
            }


            // Quick Sort algoritması
            static void QuickSort(int[] dizi, int baslangic, int bitis)
            {
                if (baslangic < bitis)
                {
                    // Pivot seçilir ve diziyi bu pivot etrafında böler
                    int partitionIndex = Bol(dizi, baslangic, bitis);

                    // Pivot etrafındaki alt diziler ayrı ayrı sıralanır
                    QuickSort(dizi, baslangic, partitionIndex - 1);
                    QuickSort(dizi, partitionIndex + 1, bitis);
                }
            }

            // Diziyi bölen ve pivotun doğru konumunu bulan yardımcı fonksiyon
            // Bu fonksiyon, diziyi bir pivot etrafında böler ve pivotun doğru konumunu belirler
            static int Bol(int[] dizi, int baslangic, int bitis)
            {
                int pivot = dizi[bitis]; // Son elemanı pivot olarak seçiyoruz
                int i = (baslangic - 1);

                // Pivot etrafındaki elemanlar yer değiştirir
                for (int j = baslangic; j < bitis; j++)
                {
                    if (dizi[j] < pivot)
                    {
                        i++;
                        int temp = dizi[i];
                        dizi[i] = dizi[j];
                        dizi[j] = temp;
                    }
                }

                int temp1 = dizi[i + 1];
                dizi[i + 1] = dizi[bitis];
                dizi[bitis] = temp1;

                return i + 1; // Pivotun yeni konumunu döndürür
            }





            class Denklem
            {
                // Operatörlerin önceliklerini belirleme
                static int Oncelik(char op)
                {
                    switch (op)
                    {
                        case '+':
                        case '-':
                            return 1;
                        case '*':
                        case '/':
                            return 2;
                        case '^':
                            return 3;
                        default:
                            return -1;
                    }
                }

                // Karakterin operatör olup olmadığını kontrol etme
                static bool OperatorMu(char c)
                {
                    return (c == '+' || c == '-' || c == '*' || c == '/' || c == '^');
                }

                // Infix den postfix'e dönüştürme
                public static string InfixToPostfix(string infix)
                {
                    string postfix = "";
                    Stack<char> yigin = new Stack<char>();

                    for (int i = 0; i < infix.Length; ++i)
                    {
                        char karakter = infix[i];

                        // Karakter operand ise direkt postfix ifadeye ekleme
                        if (char.IsLetterOrDigit(karakter))
                        {
                            postfix += karakter;
                        }
                        // Parantez durumları kontrolü
                        else if (karakter == '(')
                        {
                            yigin.Push(karakter);
                        }
                        else if (karakter == ')')
                        {
                            // Parantez kapatma durumu
                            while (yigin.Count > 0 && yigin.Peek() != '(')
                            {
                                postfix += yigin.Pop();
                            }
                            // Geçersiz parantez kapatma kontrolü
                            if (yigin.Count > 0 && yigin.Peek() != '(')
                            {
                                return "Geçersiz İnfix ifade";
                            }
                            else
                            {
                                yigin.Pop();
                            }
                        }
                        else
                        {
                            // Operatör işlemleri
                            while (yigin.Count > 0 && Oncelik(karakter) <= Oncelik(yigin.Peek()))
                            {
                                postfix += yigin.Pop();
                            }
                            yigin.Push(karakter);
                        }
                    }

                    // Yığındaki elemanları postfix ifadeye ekleme
                    while (yigin.Count > 0)
                    {
                        postfix += yigin.Pop();
                    }

                    return postfix;
                }

                // Infix den prefix'e dönüştürme
                public static string InfixToPrefix(string infix)
                {
                    // Infix ifadeyi ters çevirme
                    char[] karakterDizisi = infix.ToCharArray();
                    Array.Reverse(karakterDizisi);

                    // Parantezlerin ters hale getirilmesi
                    for (int i = 0; i < karakterDizisi.Length; i++)
                    {
                        if (karakterDizisi[i] == '(')
                        {
                            karakterDizisi[i] = ')';
                            i++;
                        }
                        else if (karakterDizisi[i] == ')')
                        {
                            karakterDizisi[i] = '(';
                            i++;
                        }
                    }

                    // Ters çevrilmiş infix ifadeyi postfix ifadeye dönüştürme
                    string tersInfix = new string(karakterDizisi);
                    string tersPostfix = InfixToPostfix(tersInfix);

                    // Ters çevrilmiş postfix ifadeyi tekrar ters çevirme
                    karakterDizisi = tersPostfix.ToCharArray();
                    Array.Reverse(karakterDizisi);

                    return new string(karakterDizisi);
                }
            }
            public class AgacNode
            {
                public int veri;
                public AgacNode sol, sag;

                // Yapıcı metot, düğümün verisini ve başlangıçta sol ve sağ düğümleri null olarak ayarlar
                public AgacNode(int item)
                {
                    veri = item;
                    sol = sag = null;
                }
            }

            public class IkiliAramaAgaci
            {
                AgacNode kok; // Kök düğümü

                // Yapıcı metot, ikili arama ağacının başlangıçta kökünü null olarak ayarlar
                public IkiliAramaAgaci()
                {
                    kok = null;
                }

                // Yeni bir düğümü ağaca eklemek için kullanılır.
                public void Ekle(int veri)
                {
                    kok = EkleRecursive(kok, veri);
                }

                // Yeni bir düğümü ağaca eklemek için recursive (özyinelemeli) metot
                AgacNode EkleRecursive(AgacNode node, int veri)
                {
                    if (node == null)
                    {
                        // Eğer düğüm yoksa, yeni bir düğüm oluşturulur ve veri eklenir
                        node = new AgacNode(veri);
                        return node;
                    }

                    // Veri, düğümün verisinden küçükse sol tarafa eklenir, büyükse sağ tarafa
                    if (veri < node.veri)
                    {
                        node.sol = EkleRecursive(node.sol, veri);
                    }
                    else if (veri > node.veri)
                    {
                        node.sag = EkleRecursive(node.sag, veri);
                    }

                    return node;
                }



                // Ağaçta bir değeri aramak için kullanılır.
                public AgacNode Ara(int veri)
                {
                    return AraRecursive(kok, veri);
                }

                // Ağaçta bir değeri aramak için recursive (özyinelemeli) metot
                AgacNode AraRecursive(AgacNode node, int veri)
                {
                    if (node == null || node.veri == veri)
                    {
                        // Eğer düğüm null veya aranan değere sahipse düğümü döndürür
                        return node;
                    }

                    if (veri < node.veri)
                    {
                        // Eğer aranan değer düğümün değerinden küçükse sol tarafa devam eder
                        return AraRecursive(node.sol, veri);
                    }

                    // Değilse sağ tarafa devam eder
                    return AraRecursive(node.sag, veri);
                }

                // Ağaçtaki en küçük değeri bulur.
                public AgacNode MinDeger()
                {
                    return MinDegerRecursive(kok);
                }

                // Ağaçtaki en küçük değeri bulan recursive (özyinelemeli) metot
                AgacNode MinDegerRecursive(AgacNode node)
                {
                    AgacNode current = node;

                    // Sol alt ağaca kadar inerek en küçük değeri bulur
                    while (current.sol != null)
                    {
                        current = current.sol;
                    }

                    return current;
                }


                // Ağaçtaki en büyük değeri bulur.
                public AgacNode MaxDeger()
                {
                    return MaxDegerRecursive(kok);
                }

                // Ağaçtaki en büyük değeri bulmak için özyinelemeli bir işlem yapar.
                AgacNode MaxDegerRecursive(AgacNode node)
                {
                    // Geçerli düğümü saklamak için bir değişken oluşturulur.
                    AgacNode current = node;

                    // En sağdaki düğümü bulana kadar döngü devam eder.
                    while (current.sag != null)
                    {
                        current = current.sag;
                    }

                    // En büyük değeri içeren düğüm döndürülür.
                    return current;
                }

                // Ağaçtaki bir değeri siler.
                public AgacNode Sil(int veri)
                {
                    return SilRecursive(kok, veri);
                }

                // Ağaçtaki bir değeri silmek için özyinelemeli bir işlem yapar.
                AgacNode SilRecursive(AgacNode node, int veri)
                {
                    // Eğer düğüm null ise veya silinecek değer bulunamazsa, mevcut durumu döndürür.
                    if (node == null)
                    {
                        return node;
                    }

                    // Silinecek değeri sol veya sağ alt ağaçta arar ve uygun işlemi gerçekleştirir.
                    if (veri < node.veri)
                    {
                        node.sol = SilRecursive(node.sol, veri);
                    }
                    else if (veri > node.veri)
                    {
                        node.sag = SilRecursive(node.sag, veri);
                    }
                    else
                    {
                        // Eğer sadece bir alt ağaç bulunuyorsa, o ağacı döndürür.
                        if (node.sol == null)
                        {
                            return node.sag;
                        }
                        else if (node.sag == null)
                        {
                            return node.sol;
                        }

                        // Sağ alt ağaçtan en küçük değeri alır ve düğümü günceller.
                        node.veri = MinDegerRecursive(node.sag).veri;
                        node.sag = SilRecursive(node.sag, node.veri);
                    }

                    // Güncellenmiş düğümü döndürür.
                    return node;
                }


                // Ağacı inorder (soldan kök düğüme sağdan) şekilde listeler.
                public void Listele()
                {
                    // Listeleme işlemini başlatır ve sonucu yazdırır.
                    ListeleRecursive(kok);
                    Console.WriteLine();
                }

                // Ağacı inorder şekilde listelemek için özyinelemeli bir işlem yapar.
                void ListeleRecursive(AgacNode node)
                {
                    // Düğüm null değilse, sol alt ağacı, kök düğümü ve sağ alt ağacı sırayla listeler.
                    if (node != null)
                    {
                        ListeleRecursive(node.sol);
                        Console.Write(node.veri + " "); // Kök düğümü yazdırır.
                        ListeleRecursive(node.sag);
                    }
                }

                // Ağacın tümünü siler.
                public void AgaciSil()
                {
                    // Ağacın kök düğümünü null yaparak ağacı temizler.
                    kok = null;
                }



                class HashTablosu
                {
                    private LinkedList<int>[] hashDizi; // Hash tablosunu temsil eden dizi
                    private int boyut; // Tablo boyutu

                    // HashTablosu sınıfı kurucusu
                    public HashTablosu(int boyut)
                    {
                        this.boyut = boyut;
                        hashDizi = new LinkedList<int>[boyut]; // Boyuta göre dizi oluşturuluyor

                        // Her bir dizi elemanı için linked list oluşturuluyor
                        for (int i = 0; i < boyut; i++)
                        {
                            hashDizi[i] = new LinkedList<int>();
                        }
                    }

                    // Hash fonksiyonu - Gelen anahtarın indis değerini hesaplar
                    private int HashFonksiyonu(int anahtar)
                    {
                        return anahtar % boyut; // Mod alma işlemi ile indis değeri belirlenir
                    }

                    // Hash tablosuna eleman ekleme metodu
                    public void Ekle(int veri)
                    {
                        int indeks = HashFonksiyonu(veri); // Eklenecek verinin indis değeri bulunuyor
                        hashDizi[indeks].AddLast(veri); // İlgili indise veri linked list'e ekleniyor
                    }

                    // Hash tablosunu ekrana yazdıran metot
                    public void TabloyuGoster()
                    {
                        // Hash tablosunun boyutu kadar döngü oluşturulur
                        for (int i = 0; i < boyut; i++)
                        {
                            Console.Write($"{i}: "); // İndisi yazdırır

                            // Her indis için linked list içindeki elemanlar yazdırılır
                            foreach (var eleman in hashDizi[i])
                            {
                                Console.Write($"{eleman} "); // Her elemanı yazdırır
                            }

                            Console.WriteLine(); // Her satır sonunda yeni bir satır oluşturur
                        }
                    }
                }
                class program
                {
                    static void Main(string[] args)
                    {

                        Console.WriteLine(" Lütfen Yapıcagınız İşlemi Giriniz: " + " \n \n1- Linked List'te Öğrenci No, Adı ve Bölümü bilgisi için 1' e Basınız  " + "\n2- Kuyruğa İşlemleri için 2' e Basınız" + "\n3- Yığın İşlemleri için 3'e Basınız " + "\n4- İnfix Bir İfadeyi Postfix ve Prefixe Çevirmek için 4 'e Basınız" + "\n5- 15'li Hash Tablosuna Göre 20 Sayı Sıralamak için 5'e Basınız" + "\n6- İkili Arama Ağacında İşlem Yapmak İçin 6'ya Basınız" + "\n7- Sıralama Yapmak İçin 7'e Basınız" + "\n8- Recursive ve İteratif Kodlar İçin 8'e Basınız");
                        int sayi = int.Parse(Console.ReadLine());
                        if (sayi == 1)
                        {
                            BagliListe ogrenciListesi = new BagliListe();
                            int secim = 0;
                            while (secim != 6)
                            {
                                Console.WriteLine("\n\nLütfen Yapmak İstediğiniz İşlemi Seçiniz:");
                                Console.WriteLine("1. Listenin Sonuna Öğrenci Ekle");
                                Console.WriteLine("2. Listenin Başına Öğrenci Ekle");
                                Console.WriteLine("3. Listenin Son Elemanını Sil");
                                Console.WriteLine("4. Tüm Öğrencileri Sil");
                                Console.WriteLine("5. Öğrenci Listesini Yazdır");
                                Console.WriteLine("6. Çıkış");

                                secim = int.Parse(Console.ReadLine());

                                switch (secim)
                                {
                                    case 1:
                                        Console.WriteLine("Eklemek istediğiniz öğrencinin bilgilerini girin:");
                                        Console.Write("Öğrenci No: ");
                                        int no = int.Parse(Console.ReadLine());
                                        Console.Write("Adı: ");
                                        string ad = Console.ReadLine();
                                        Console.Write("Bölümü: ");
                                        string bolum = Console.ReadLine();

                                        ogrenciListesi.SonunaEkle(new Ogrenci(no, ad, bolum));
                                        Console.WriteLine("\n!!! Bilgilerini Girdiğiniz Öğrenci Listenin Sonuna Eklenmiştir.");
                                        break;
                                    case 2:
                                        Console.WriteLine("Eklemek istediğiniz öğrencinin bilgilerini girin:");
                                        Console.Write("Öğrenci No: ");
                                        int noB = int.Parse(Console.ReadLine());
                                        Console.Write("Adı: ");
                                        string adB = Console.ReadLine();
                                        Console.Write("Bölümü: ");
                                        string bolumB = Console.ReadLine();

                                        ogrenciListesi.BasaEkle(new Ogrenci(noB, adB, bolumB));
                                        Console.WriteLine("\n!!! Bilgilerini Girdiğiniz Öğrenci Listenin Başına Eklenmiştir.");
                                        break;
                                    case 3:
                                        if (ogrenciListesi.Bas != null)
                                        {
                                            ogrenciListesi.Sil(ogrenciListesi.Son.Veri.OgrenciNo);
                                            Console.WriteLine("\n!!! Listedeki Son Eleman Silinmiştir.");
                                        }
                                        else
                                            Console.WriteLine("\nListe boş, silme işlemi yapılamaz.");
                                        break;
                                    case 4:
                                        ogrenciListesi.TumunuSil();
                                        Console.WriteLine("\n!!! Listedeki Tüm Bilgiler silinmiştir.");
                                        break;
                                    case 5:
                                        Console.WriteLine("\n Listemiz: ");
                                        ogrenciListesi.Yazdir();
                                        break;
                                    case 6:
                                        Console.WriteLine("Programdan çıkılıyor.");
                                        break;
                                    default:
                                        Console.WriteLine("Geçersiz seçim!");
                                        break;
                                }

                            }
                        }
                        else if (sayi == 2)
                        {
                            // Kuyruk oluşturuluyor
                            Queue<string> kuyruk = new Queue<string>();
                            int secim = 0;
                            while (secim != 8) // Kullanıcı çıkış yapana kadar işlemler devam edecek
                            {
                                // Kullanıcı için menü
                                Console.WriteLine("\nLütfen Yapmak İstediğiniz İşlemi Seçiniz:");
                                Console.WriteLine("1. Kuyruğa Ekle");
                                Console.WriteLine("2. Kuyruktan Sil");
                                Console.WriteLine("3. Araya Ekle");
                                Console.WriteLine("4. Başa Ekle");
                                Console.WriteLine("5. Sona Ekle");
                                Console.WriteLine("6. Tümünü Sil");
                                Console.WriteLine("7. Kuyruğu Listele");
                                Console.WriteLine("8. Çıkış");

                                secim = int.Parse(Console.ReadLine());

                                switch (secim)
                                {
                                    case 1:
                                        // Kuyruğa eleman ekleme işlemi
                                        Console.WriteLine("Kuyruğa eklemek istediğiniz elemanı girin:");
                                        string elemanEkle = Console.ReadLine();
                                        kuyruk.Enqueue(elemanEkle);
                                        Console.WriteLine("'" + elemanEkle + "' kuyruğa eklendi.");
                                        break;
                                    case 2:
                                        // Kuyruktan eleman silme işlemi
                                        if (kuyruk.Count > 0)
                                        {
                                            string silinenEleman = kuyruk.Dequeue();
                                            Console.WriteLine("'" + silinenEleman + "' kuyruktan silindi.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Kuyruk boş, silme işlemi yapılamaz.");
                                        }
                                        break;
                                    case 3:
                                        // Kuyruğa araya eleman ekleme işlemi
                                        Console.WriteLine("Araya eklemek istediğiniz elemanı girin:");
                                        string arayaEkle = Console.ReadLine();

                                        Queue<string> geciciKuyruk = new Queue<string>();

                                        // Kuyruktaki elemanlar geçici kuyruğa aktarılıyor
                                        while (kuyruk.Count > 0)
                                        {
                                            string eleman = kuyruk.Dequeue();
                                            geciciKuyruk.Enqueue(eleman);
                                        }

                                        // Yeni eleman araya ekleniyor
                                        geciciKuyruk.Enqueue(arayaEkle);

                                        // Elemanlar tekrar asıl kuyruğa aktarılıyor
                                        while (geciciKuyruk.Count > 0)
                                        {
                                            string eleman = geciciKuyruk.Dequeue();
                                            kuyruk.Enqueue(eleman);
                                        }
                                        Console.WriteLine("'" + arayaEkle + "' kuyruğa araya eklendi.");
                                        break;
                                    case 4:
                                        // Kuyruğun başına eleman ekleme işlemi
                                        Console.WriteLine("Başa eklemek istediğiniz elemanı girin:");
                                        string basaEkle = Console.ReadLine();
                                        kuyruk.Enqueue(basaEkle);
                                        Console.WriteLine("'" + basaEkle + "' kuyruğun başına eklendi.");
                                        break;
                                    case 5:
                                        // Kuyruğun sonuna eleman ekleme işlemi
                                        Console.WriteLine("Sona eklemek istediğiniz elemanı girin:");
                                        string sonaEkle = Console.ReadLine();
                                        kuyruk.Enqueue(sonaEkle);
                                        Console.WriteLine("'" + sonaEkle + "' kuyruğun sonuna eklendi.");
                                        break;
                                    case 6:
                                        // Tüm elemanları kuyruktan silme işlemi
                                        kuyruk.Clear();
                                        Console.WriteLine("Kuyruktaki tüm elemanlar silindi.");
                                        break;
                                    case 7:
                                        // Kuyruğu listeleme işlemi
                                        Console.WriteLine("\nKuyruk Elemanları:");
                                        foreach (var eleman in kuyruk)
                                        {
                                            Console.WriteLine(eleman);
                                        }
                                        break;
                                    case 8:
                                        // Çıkış yapma işlemi
                                        Console.WriteLine("Programdan çıkılıyor.");
                                        break;
                                    default:
                                        Console.WriteLine("Geçersiz seçim!");
                                        break;
                                }
                            }
                        }
                        else if (sayi == 3)
                        {
                            // Yığın oluşturuluyor
                            Stack<string> yigin = new Stack<string>();

                            int secim = 0;
                            while (secim != 7) // Kullanıcı çıkış yapana kadar işlemler devam edecek
                            {
                                // Kullanıcı için menü
                                Console.WriteLine("\nLütfen Yapmak İstediğiniz İşlemi Seçiniz:");
                                Console.WriteLine("1. Yığına Ekle");
                                Console.WriteLine("2. Yığından Sil");
                                Console.WriteLine("3. Başa Ekle");
                                Console.WriteLine("4. Sona Ekle");
                                Console.WriteLine("5. Tümünü Sil");
                                Console.WriteLine("6. Yığındaki Elemanları Listele");
                                Console.WriteLine("7. Çıkış");

                                secim = int.Parse(Console.ReadLine());

                                switch (secim)
                                {
                                    case 1:
                                        // Yığına eleman ekleme işlemi
                                        Console.WriteLine("Yığına eklemek istediğiniz elemanı girin:");
                                        string elemanEkle = Console.ReadLine();
                                        yigin.Push(elemanEkle);
                                        Console.WriteLine("'" + elemanEkle + "' yığına eklendi.");
                                        break;
                                    case 2:
                                        // Yığından eleman silme işlemi
                                        if (yigin.Count > 0)
                                        {
                                            string silinenEleman = yigin.Pop();
                                            Console.WriteLine("'" + silinenEleman + "' yığından silindi.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Yığın boş, silme işlemi yapılamaz.");
                                        }
                                        break;
                                    case 3:
                                        // Yığının başına eleman ekleme işlemi
                                        Console.WriteLine("Başa eklemek istediğiniz elemanı girin:");
                                        string basaEkle = Console.ReadLine();
                                        yigin.Push(basaEkle);
                                        Console.WriteLine("'" + basaEkle + "' yığının başına eklendi.");
                                        break;
                                    case 4:
                                        // Yığının sonuna eleman ekleme işlemi
                                        Console.WriteLine("Sona eklemek istediğiniz elemanı girin:");
                                        string sonaEkle = Console.ReadLine();
                                        Stack<string> geciciSonaEkle = new Stack<string>();

                                        // Yığındaki elemanlar geçici yığına aktarılıyor
                                        while (yigin.Count > 0)
                                        {
                                            string eleman = yigin.Pop();
                                            geciciSonaEkle.Push(eleman);
                                        }

                                        // Yeni eleman sona ekleniyor
                                        geciciSonaEkle.Push(sonaEkle);

                                        // Elemanlar tekrar asıl yığına aktarılıyor
                                        while (geciciSonaEkle.Count > 0)
                                        {
                                            string eleman = geciciSonaEkle.Pop();
                                            yigin.Push(eleman);
                                        }

                                        Console.WriteLine("'" + sonaEkle + "' yığının sonuna eklendi.");
                                        break;
                                    case 5:
                                        // Tüm elemanları yığından silme işlemi
                                        yigin.Clear();
                                        Console.WriteLine("Yığındaki tüm elemanlar silindi.");
                                        break;
                                    case 6:
                                        // Yığındaki elemanları listeleme işlemi
                                        Console.WriteLine("\nYığın Elemanları:");
                                        foreach (var eleman in yigin)
                                        {
                                            Console.WriteLine(eleman);
                                        }
                                        Console.ReadLine();
                                        break;
                                    case 7:
                                        // Çıkış yapma işlemi
                                        Console.WriteLine("Programdan çıkılıyor.");
                                        break;
                                    default:
                                        Console.WriteLine("Geçersiz seçim!");
                                        break;
                                }

                            }
                        }
                        else if (sayi == 4)
                        {
                            // Kullanıcıdan infix denklemi isteme
                            Console.WriteLine("İnfix denklemi girin:");
                            string infix = Console.ReadLine();

                            // Infix denklemi postfix ve prefix'e dönüştürme
                            string postfix = Denklem.InfixToPostfix(infix);
                            string prefix = Denklem.InfixToPrefix(infix);

                            // Postfix ve prefix notasyonları ekrana yazdırma
                            Console.WriteLine("Postfix notasyon: " + postfix);
                            Console.WriteLine("Prefix notasyon: " + prefix);

                            Console.ReadLine();
                        }
                        else if (sayi == 5)
                        {
                            HashTablosu hashTablosu = new HashTablosu(15); // Boyutu 15 olan bir hash tablosu oluşturuluyor
                            int girilenSayiSayisi = 0;

                            Console.WriteLine("Lütfen 20 adet sayı giriniz:");

                            // Kullanıcıdan 20 sayı alınıyor ve hash tablosuna ekleniyor
                            while (girilenSayiSayisi < 20)
                            {
                                if (int.TryParse(Console.ReadLine(), out int numara)) // Kullanıcıdan sayı girişi alınıyor
                                {
                                    hashTablosu.Ekle(numara); // Girilen sayı hash tablosuna ekleniyor
                                    girilenSayiSayisi++;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz giriş, lütfen sayı girin."); // Geçersiz giriş uyarısı
                                }
                            }

                            Console.WriteLine("\nOluşturulan 15'li Hash Tablosu:");
                            hashTablosu.TabloyuGoster(); // Oluşturulan hash tablosu ekrana yazdırılıyor

                            Console.ReadLine();
                        }
                        else if (sayi == 6)
                        {
                            IkiliAramaAgaci agac = new IkiliAramaAgaci();

                            while (true)
                            {
                                Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçiniz:");
                                Console.WriteLine("1. Ekle");
                                Console.WriteLine("2. Sil");
                                Console.WriteLine("3. Ara");
                                Console.WriteLine("4. Min Değer");
                                Console.WriteLine("5. Max Değer");
                                Console.WriteLine("6. Listele");
                                Console.WriteLine("7. Tüm Ağacı Sil");
                                Console.WriteLine("8. Çıkış");

                                int secim;
                                if (!int.TryParse(Console.ReadLine(), out secim))
                                {
                                    Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                                    continue;
                                }

                                switch (secim)
                                {
                                    case 1:
                                        Console.Write("Eklenecek sayıyı girin: ");
                                        int eklenecekSayi;
                                        if (!int.TryParse(Console.ReadLine(), out eklenecekSayi))
                                        {
                                            Console.WriteLine("Geçersiz giriş!");
                                            break;
                                        }
                                        agac.Ekle(eklenecekSayi);
                                        break;
                                    case 2:
                                        Console.Write("Silinecek sayıyı girin: ");
                                        int silinecekSayi;
                                        if (!int.TryParse(Console.ReadLine(), out silinecekSayi))
                                        {
                                            Console.WriteLine("Geçersiz giriş!");
                                            break;
                                        }
                                        agac.Sil(silinecekSayi);
                                        break;
                                    case 3:
                                        Console.Write("Aranacak sayıyı girin: ");
                                        int aranacakSayi;
                                        if (!int.TryParse(Console.ReadLine(), out aranacakSayi))
                                        {
                                            Console.WriteLine("Geçersiz giriş!");
                                            break;
                                        }
                                        AgacNode bulunan = agac.Ara(aranacakSayi);
                                        if (bulunan != null)
                                        {
                                            Console.WriteLine($"{aranacakSayi} ağaçta bulundu.");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{aranacakSayi} ağaçta bulunamadı.");
                                        }
                                        break;
                                    case 4:
                                        // AgacNode türünden bir değişken oluşturarak ağaç yapısındaki en küçük değeri bulur.
                                        AgacNode enKucukDeger = agac.MinDeger();

                                        // Eğer en küçük değer bulunursa, değeri ekrana yazdırır; aksi takdirde -1 olarak belirtilen bir değer döndürülür.
                                        Console.WriteLine($"Ağaçtaki en küçük değer: {enKucukDeger?.veri ?? -1}");

                                        break;
                                    case 5:
                                        AgacNode maxDeger = agac.MaxDeger();
                                        Console.WriteLine($"Ağaçtaki en büyük değer: {maxDeger?.veri ?? -1}");
                                        break;
                                    case 6:
                                        Console.WriteLine("Ağaç listesi (inorder):");
                                        agac.Listele();
                                        break;
                                    case 7:
                                        agac.AgaciSil();
                                        Console.WriteLine("Ağaç tamamen silindi.");
                                        break;
                                    case 8:
                                        Console.WriteLine("Programdan çıkılıyor.");
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        Console.WriteLine("Geçersiz seçim!");
                                        break;
                                }
                            }
                        }
                        else if (sayi == 7)
                        {
                            Console.WriteLine("Lütfen dizi uzunluğunu girin:");
                            if (!int.TryParse(Console.ReadLine(), out int uzunluk) || uzunluk <= 0)
                            {
                                Console.WriteLine("Geçersiz dizi uzunluğu!");
                                return;
                            }

                            int[] dizi = new int[uzunluk];
                            for (int i = 0; i < uzunluk; i++)
                            {
                                Console.WriteLine($"Lütfen {i + 1}. elemanı girin:");
                                if (!int.TryParse(Console.ReadLine(), out dizi[i]))
                                {
                                    Console.WriteLine("Geçersiz giriş, lütfen bir sayı girin.");
                                    i--; // Hatalı girişte i'yi geri al
                                }
                            }

                            Console.WriteLine("\nDizi elemanları:");
                            foreach (var eleman in dizi)
                            {
                                Console.Write(eleman + " ");
                            }
                            Console.WriteLine();

                            Console.WriteLine("\nSıralama yöntemini seçin:");
                            Console.WriteLine("1. Bubble Sort");
                            Console.WriteLine("2. Selection Sort");
                            Console.WriteLine("3. Insertion Sort");
                            Console.WriteLine("4. Merge Sort");
                            Console.WriteLine("5. Quick Sort");

                            if (int.TryParse(Console.ReadLine(), out int secim))
                            {
                                switch (secim)
                                {
                                    case 1:
                                        BubbleSort(dizi);
                                        break;
                                    case 2:
                                        SelectionSort(dizi);
                                        break;
                                    case 3:
                                        InsertionSort(dizi);
                                        break;
                                    case 4:
                                        MergeSort(dizi, 0, dizi.Length - 1);
                                        break;
                                    case 5:
                                        QuickSort(dizi, 0, dizi.Length - 1);
                                        break;
                                    default:
                                        Console.WriteLine("Geçersiz seçim!");
                                        break;
                                }

                                Console.WriteLine("\nSıralanmış dizi:");
                                foreach (var eleman in dizi)
                                {
                                    Console.Write(eleman + " ");
                                }
                                Console.WriteLine();
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("\nGeçersiz seçim!");
                            }
                        }
                        else if (sayi == 8)
                        {
                            Console.WriteLine("Lütfen yazdırmak istediğiniz algoritmayı seçin:");
                            Console.WriteLine("1. Faktoriyel Recursive");
                            Console.WriteLine("2. Faktoriyel Iterative");
                            Console.WriteLine("3. Fibonacci Recursive");
                            Console.WriteLine("4. Fibonacci Iterative");
                            Console.WriteLine("5. Üst Alma Recursive");
                            Console.WriteLine("6. Üst Alma Iterative");
                            Console.WriteLine("7. Asal Sayı Recursive");
                            Console.WriteLine("8. Asal Sayı Iterative");
                            Console.WriteLine("9. Dizi Elemanlarının Toplamı Recursive");
                            Console.WriteLine("10. Dizi Elemanlarının Toplamı Iterative");
                            Console.Write("Seçiminiz: ");
                            int kontrol = int.Parse(Console.ReadLine());
                            switch (kontrol)
                            {
                                case 1:
                                    Console.WriteLine("\nstatic int FaktoriyelRecursive(int n)\r\n{\r\n    if (n == 0 || n == 1)\r\n        return 1;\r\n    else\r\n        return n * FaktoriyelRecursive(n - 1);\r\n}\r\n");
                                    Console.WriteLine("\nRecursive faktöriyelde her bir adımda 1 işlem yapılır.\r\nÇalışma karmaşıklığı O(n).");
                                    Console.ReadLine();
                                    break;

                                case 2:
                                    Console.WriteLine("\nstatic int FaktoriyelIterative(int n)\r\n{\r\n    int faktoriyel = 1;\r\n    for (int i = 1; i <= n; i++)\r\n    {\r\n        faktoriyel *= i;\r\n    }\r\n    return faktoriyel;\r\n}\r\n");
                                    break;
                                case 3:
                                    Console.WriteLine("\nstatic int FibonacciRecursive(int n)\r\n{\r\n    if (n <= 1)\r\n        return n;\r\n    else\r\n        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);\r\n}\r\n");
                                    Console.WriteLine("\nRecursive Fibonacci'de her bir adımda daha önce hesaplanmış sayılar tekrar hesaplanır.\r\nÇalışma karmaşıklığı O(2^n)");
                                    break;
                                case 4:
                                    Console.WriteLine("\nstatic int FibonacciIterative(int n)\r\n{\r\n    int a = 0, b = 1, c = 0;\r\n    if (n == 0)\r\n        return a;\r\n    for (int i = 2; i <= n; i++)\r\n    {\r\n        c = a + b;\r\n        a = b;\r\n        b = c;\r\n    }\r\n    return b;\r\n}\r\n");
                                    Console.WriteLine("\nIterative Fibonacci'de her bir adımda 1 işlem yapılır.\r\nÇalışma karmaşıklığı O(n)");
                                    break;
                                case 5:
                                    Console.WriteLine("\nstatic double UsRecursive(double taban, int us)\r\n{\r\n    if (us == 0)\r\n        return 1;\r\n    else if (us > 0)\r\n        return taban * UsRecursive(taban, us - 1);\r\n    else\r\n        return 1 / taban * UsRecursive(taban, us + 1);\r\n}\r\n");
                                    Console.WriteLine("\nRecursive üst alma, us değerine bağlı olarak işlem sayısını artırır.\r\nPozitif us için çalışma karmaşıklığı O(us), negatif us için O(-us).");
                                    break;
                                case 6:
                                    Console.WriteLine("\nstatic double UsIterative(double taban, int us)\r\n{\r\n    double sonuc = 1;\r\n    if (us == 0)\r\n        return 1;\r\n    else if (us > 0)\r\n    {\r\n        for (int i = 1; i <= us; i++)\r\n        {\r\n            sonuc *= taban;\r\n        }\r\n    }\r\n    else\r\n    {\r\n        for (int i = -1; i >= us; i--)\r\n        {\r\n            sonuc /= taban;\r\n        }\r\n    }\r\n    return sonuc;\r\n}\r\n");
                                    Console.WriteLine("\nIterative üst alma, us değerine bağlı olarak işlem sayısını artırır.\r\nPozitif us için çalışma karmaşıklığı O(us), negatif us için O(-us).");
                                    break;
                                case 7:
                                    Console.WriteLine("\nstatic bool AsalRecursive(int n, int i = 2)\r\n{\r\n    if (n <= 2)\r\n        return (n == 2) ? true : false;\r\n    if (n % i == 0)\r\n        return false;\r\n    if (i * i > n)\r\n        return true;\r\n    return AsalRecursive(n, i + 1);\r\n}\r\n");
                                    Console.WriteLine("\nRecursive asal sayı kontrolünde her bir adımda n'in bölenleri kontrol edilir.\r\nÇalışma karmaşıklığı O(√n).");
                                    break;
                                case 8:
                                    Console.WriteLine("\nstatic bool AsalIterative(int n)\r\n{\r\n    if (n <= 1)\r\n        return false;\r\n    for (int i = 2; i * i <= n; i++)\r\n    {\r\n        if (n % i == 0)\r\n            return false;\r\n    }\r\n    return true;\r\n}\r\n");
                                    Console.WriteLine("\nIterative asal sayı kontrolünde her bir adımda n'in bölenleri kontrol edilir.\r\nÇalışma karmaşıklığı O(√n).");
                                    break;
                                case 9:
                                    Console.WriteLine("\nstatic int DiziToplamiRecursive(int[] dizi, int n)\r\n{\r\n    if (n <= 0)\r\n        return 0;\r\n    return DiziToplamiRecursive(dizi, n - 1) + dizi[n - 1];\r\n}\r\n");
                                    Console.WriteLine("\nRecursive dizi toplamında her bir adımda bir dizi elemanı toplanır.\r\nÇalışma karmaşıklığı O(n).");
                                    break;
                                case 10:
                                    Console.WriteLine("\nstatic int DiziToplamiIterative(int[] dizi)\r\n{\r\n    int toplam = 0;\r\n    foreach (var eleman in dizi)\r\n    {\r\n        toplam += eleman;\r\n    }\r\n    return toplam;\r\n}\r\n");
                                    Console.WriteLine("\nIterative dizi toplamında her bir adımda bir dizi elemanı toplanır.\r\nÇalışma karmaşıklığı O(n).");
                                    break;
                                default:
                                    Console.WriteLine("Geçersiz İşlem");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yanlış Değer Girdiniz Lütfen 1 ile 8 Arası Değer Giriniz...");
                            Console.ReadLine();
                        }
                    }


                }
            }
        }
    }
}

