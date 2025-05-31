using System;

class Program
{
    static void Main()
    {
        int[] sayilar = { 23, 45, 12, 67, 5, 89, 34 };

        int enBuyuk = sayilar[0];
        int enKucuk = sayilar[0];

        foreach (int sayi in sayilar)
        {
            if (sayi > enBuyuk)
                enBuyuk = sayi;
            if (sayi < enKucuk)
                enKucuk = sayi;
        }

        Console.WriteLine("En Büyük Sayı: " + enBuyuk);
        Console.WriteLine("En Küçük Sayı: " + enKucuk);
    }
}
