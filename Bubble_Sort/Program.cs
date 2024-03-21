
int[] deneme = new int[5];

for (int i = 0; i < 5; i++)
{
    Console.Write("{0}. Sayiyi Giriniz: ", i + 1);
    deneme[i] = int.Parse(Console.ReadLine());

}

int n = deneme.Length;
int kntrl = 0, tut;

for (int i = 0; i < n - 1; i++)
{
    for (int j = 0; j < n - kntrl - 1; j++)
    {
        if (deneme[j] > deneme[j + 1])
        {
            tut = deneme[j];
            deneme[j] = deneme[j + 1];
            deneme[j + 1] = tut;
        }
    }
}


foreach (int i in deneme)
{
    Console.Write(i + "  ");
}
