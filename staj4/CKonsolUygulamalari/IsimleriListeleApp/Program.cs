using System;

class Program
{
    static void Main()
    {
        Console.Write("Kaç kişi girilecek? ");
        int kisiSayisi = int.Parse(Console.ReadLine());

        string[] isimler = new string[kisiSayisi];

        for (int i = 0; i < kisiSayisi; i++)
        {
            Console.Write($"{i + 1}. kişinin adını girin: ");
            isimler[i] = Console.ReadLine();
        }

        Console.WriteLine("\nGirilen İsimler:");
        foreach (string isim in isimler)
        {
            Console.WriteLine("- " + isim);
        }
    }
}
