using System;

class Program
{
    static void Main()
    {
        Console.Write("Kaç dersin notu girilecek? ");
        int dersSayisi = int.Parse(Console.ReadLine());

        double[] notlar = new double[dersSayisi];
        double toplam = 0;

        for (int i = 0; i < dersSayisi; i++)
        {
            Console.Write($"{i + 1}. dersi giriniz: ");
            notlar[i] = double.Parse(Console.ReadLine());
            toplam += notlar[i];
        }

        double ortalama = toplam / dersSayisi;
        Console.WriteLine($"\nNot Ortalaması: {ortalama}");

        if (ortalama >= 60)
        {
            Console.WriteLine("Durum: Geçtiniz");
        }
        else
        {
            Console.WriteLine("Durum: Kaldınız");
        }
    }
}
