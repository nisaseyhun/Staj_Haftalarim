using System;

class Ogrenci
{
    public string Isim { get; set; }
    public int Yas { get; set; }
    public double[] Notlar { get; set; }

    public Ogrenci(string isim, int yas, int notSayisi)
    {
        Isim = isim;
        Yas = yas;
        Notlar = new double[notSayisi];
    }

    public double OrtalamaHesapla()
    {
        double toplam = 0;
        foreach (var not in Notlar)
        {
            toplam += not;
        }
        return Notlar.Length > 0 ? toplam / Notlar.Length : 0;
    }

    public void NotEkle(int indeks, double not)
    {
        if (indeks >= 0 && indeks < Notlar.Length)
        {
            Notlar[indeks] = not;
        }
        else
        {
            Console.WriteLine("Geçersiz not indeksi!");
        }
    }
}

class Program
{
    static Ogrenci[] ogrenciler = new Ogrenci[3]; // 3 öğrenci kapasitesi
    static int ogrenciSayisi = 0;

    static void Main()
    {
        bool devam = true;
        while (devam)
        {
            Console.WriteLine("\n--- Öğrenci Yönetim Sistemi ---");
            Console.WriteLine("1. Öğrenci Ekle");
            Console.WriteLine("2. Not Gir");
            Console.WriteLine("3. Öğrencileri Listele");
            Console.WriteLine("4. Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    OgrenciEkle();
                    break;
                case "2":
                    NotGir();
                    break;
                case "3":
                    OgrencileriListele();
                    break;
                case "4":
                    devam = false;
                    Console.WriteLine("Programdan çıkılıyor...");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }
        }
    }

    static void OgrenciEkle()
    {
        if (ogrenciSayisi >= ogrenciler.Length)
        {
            Console.WriteLine("Öğrenci kapasitesi doldu!");
            return;
        }

        Console.Write("Öğrenci ismi: ");
        string isim = Console.ReadLine();
        Console.Write("Öğrenci yaşı: ");
        int yas = int.Parse(Console.ReadLine());
        Console.Write("Kaç not girilecek? ");
        int notSayisi = int.Parse(Console.ReadLine());


        ogrenciler[ogrenciSayisi] = new Ogrenci(isim, yas, notSayisi);
        ogrenciSayisi++;

        Console.WriteLine("Öğrenci başarıyla eklendi.");
    }

    static void NotGir()
    {
        if (ogrenciSayisi == 0)
        {
            Console.WriteLine("Önce öğrenci ekleyin.");
            return;
        }

        Console.WriteLine("Not girmek istediğiniz öğrencinin numarasını girin (1-" + ogrenciSayisi + "): ");
        int ogrNo = int.Parse(Console.ReadLine()) - 1;

        if (ogrNo < 0 || ogrNo >= ogrenciSayisi)
        {
            Console.WriteLine("Geçersiz öğrenci numarası!");
            return;
        }

        Ogrenci secilenOgrenci = ogrenciler[ogrNo];

        for (int i = 0; i < secilenOgrenci.Notlar.Length; i++)
        {
            Console.Write($"{secilenOgrenci.Isim} için {i + 1}. notu girin: ");
            double not = double.Parse(Console.ReadLine());
            secilenOgrenci.NotEkle(i, not);
        }

        Console.WriteLine("Notlar başarıyla kaydedildi.");
    }

    static void OgrencileriListele()
    {
        if (ogrenciSayisi == 0)
        {
            Console.WriteLine("Listelenecek öğrenci yok.");
            return;
        }

        Console.WriteLine("\n--- Öğrenci Listesi ---");
        for (int i = 0; i < ogrenciSayisi; i++)
        {
            var o = ogrenciler[i];
            Console.WriteLine($"{i + 1}. İsim: {o.Isim}, Yaş: {o.Yas}, Ortalama: {o.OrtalamaHesapla():F2}");
        }
    }
}
