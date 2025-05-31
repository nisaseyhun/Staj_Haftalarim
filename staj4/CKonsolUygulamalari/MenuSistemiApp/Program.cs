using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("----- Menü -----");
        Console.WriteLine("1 - Toplama");
        Console.WriteLine("2 - Çıkarma");
        Console.WriteLine("3 - Çıkış");

        Console.Write("Seçiminiz: ");
        int secim = int.Parse(Console.ReadLine());

        switch (secim)
        {
            case 1:
                Console.Write("1. Sayı: ");
                int s1 = int.Parse(Console.ReadLine());
                Console.Write("2. Sayı: ");
                int s2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Toplam: " + (s1 + s2));
                break;

            case 2:
                Console.Write("1. Sayı: ");
                int s3 = int.Parse(Console.ReadLine());
                Console.Write("2. Sayı: ");
                int s4 = int.Parse(Console.ReadLine());
                Console.WriteLine("Fark: " + (s3 - s4));
                break;

            case 3:
                Console.WriteLine("Programdan çıkılıyor...");
                break;

            default:
                Console.WriteLine("Geçersiz seçim!");
                break;
        }
    }
}
