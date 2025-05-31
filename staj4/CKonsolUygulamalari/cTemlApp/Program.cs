using System;

class Program
{
    // Fonksiyon: İki sayıyı toplar ve sonucu döner
    static int Topla(int a, int b)
    {
        return a + b;
    }

    static void Main()
    {
        // Değişken ve veri tipleri
        int sayi1 = 10;
        int sayi2 = 20;
        double oran = 0.75;
        bool aktifMi = true;
        string mesaj = "Merhaba C#";

        // Operatörler ve çıktı
        int toplam = sayi1 + sayi2;
        Console.WriteLine(mesaj);
        Console.WriteLine("Toplam: " + toplam);
        Console.WriteLine("Oran: " + oran);
        Console.WriteLine("Durum: " + aktifMi);

        // Koşul (if-else)
        if (toplam > 20)
        {
            Console.WriteLine("Toplam 20'den büyük.");
        }
        else
        {
            Console.WriteLine("Toplam 20'den küçük veya eşit.");
        }

        // Döngü (for)
        Console.WriteLine("For döngüsü ile sayılar:");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(i);
        }

        // Dizi tanımlama ve kullanma
        string[] meyveler = { "Elma", "Armut", "Muz" };
        Console.WriteLine("Meyveler listesi:");
        foreach (string meyve in meyveler)
        {
            Console.WriteLine(meyve);
        }

        // Fonksiyon kullanımı
        int sonuc = Topla(15, 25);
        Console.WriteLine("Fonksiyon sonucu: " + sonuc);

        // Kullanıcıdan veri alma
        Console.Write("Bir sayı girin: ");
        int kullaniciSayi = int.Parse(Console.ReadLine());
        Console.WriteLine("Kullanıcı sayısı: " + kullaniciSayi);
    }
}
