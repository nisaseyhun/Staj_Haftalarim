using System;
using System.Collections.Generic;

// Abstract class
abstract class Vehicle
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public int Yil { get; set; }

    public Vehicle(string marka, string model, int yil)
    {
        Marka = marka;
        Model = model;
        Yil = yil;
    }

    public abstract void BilgiGoster();
}

// Interface
interface IRentable
{
    void Kirala(Customer musteri);
    void IadeEt();
    bool KiradaMi { get; }
}

class Car : Vehicle, IRentable
{
    public bool KiradaMi { get; private set; }
    private Customer currentCustomer;

    public Car(string marka, string model, int yil) : base(marka, model, yil) { }

    public override void BilgiGoster()
    {
        Console.WriteLine($"{Marka} {Model} ({Yil}) - {(KiradaMi ? "Kirada" : "Boşta")}");
    }

    public void Kirala(Customer musteri)
    {
        if (!KiradaMi)
        {
            KiradaMi = true;
            currentCustomer = musteri;
            Console.WriteLine($"{Marka} {Model} kiralandı. Müşteri: {musteri.AdSoyad}");
        }
        else
        {
            Console.WriteLine($"{Marka} {Model} şu anda kirada.");
        }
    }

    public void IadeEt()
    {
        if (KiradaMi)
        {
            KiradaMi = false;
            Console.WriteLine($"{Marka} {Model} iade edildi. Müşteri: {currentCustomer.AdSoyad}");
            currentCustomer = null;
        }
        else
        {
            Console.WriteLine("Araç zaten boşta.");
        }
    }
}

class Customer
{
    public string AdSoyad { get; set; }
    public string Telefon { get; set; }

    public Customer(string adSoyad, string telefon)
    {
        AdSoyad = adSoyad;
        Telefon = telefon;
    }
}

class VehicleManager
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AracEkle(Vehicle v)
    {
        vehicles.Add(v);
    }

    public void AraclariListele()
    {
        foreach (var arac in vehicles)
        {
            arac.BilgiGoster();
        }
    }
}

// Program
class Program
{
    static void Main()
    {
        VehicleManager manager = new VehicleManager();

        Car car1 = new Car("Toyota", "Corolla", 2020);
        Car car2 = new Car("Ford", "Focus", 2018);

        manager.AracEkle(car1);
        manager.AracEkle(car2);

        manager.AraclariListele();

        Customer musteri = new Customer("Ahmet Yılmaz", "0555 123 45 67");

        car1.Kirala(musteri);
        car1.BilgiGoster();

        car1.IadeEt();
        car1.BilgiGoster();
    }
}
