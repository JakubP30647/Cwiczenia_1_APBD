namespace Cwiczenia_1_APBD;

using static Cwiczenia_1_APBD.Products;

public class ContainerFreezer : Container, IHazardNotifier
{
    private static int _selfNumber = 0;
    public Products Products;
    public double Temperature;

    public Dictionary<Products, double> TemperatureMap = new Dictionary<Products, double>
    {
        { Bananas, 13.3 },
        { Chocolate, 18 },
        { Fish, 2 },
        { Meat, -15 },
        { IceCream, -18 },
        { FrozenPizza, -30 },
        { Cheese, 7.2 },
        { Sausage, 5 },
        { Butter, 20.5 },
        { Eggs, 19 }
    };


    public ContainerFreezer(double loadMaxMass, double hight, double selfMass, double deep,
        Products products, double temperature) : base(loadMaxMass, hight, selfMass, deep)
    {
        if (temperature > TemperatureMap[products])
        {
            Console.WriteLine("temperature is to high, container will not be created");
            return;
        }


        this.Products = products;
        _selfNumber = _selfNumber + 1;
        this.SerialNumber = "KON-C-" + _selfNumber;
        this.Products = products;
        this.Temperature = temperature;
    }


    // public void LoadInWithProduct(int mass, Products product)
    // {
    //     if (this.products != Empty && this.products != product)
    //     {
    //         throw new InvalidOperationException(
    //             $"Kontener przechowuje już {this.products}. Nie można załadować innego produktu.");
    //     }
    //
    //     if (!temperatureMap.ContainsKey(product))
    //     {
    //         throw new ArgumentException($"Nieznany produkt: {product}");
    //     }
    //
    //     double requiredTemperature = temperatureMap[product];
    //
    //     if (this.temperature > requiredTemperature)
    //     {
    //         throw new InvalidOperationException(
    //             $"Temperatura w kontenerze ({this.temperature} stopni) jest za wysoka dla {product} (wymagana: {requiredTemperature}°C).");
    //     }
    //
    //     
    //     this.products = product;
    //     this.loadMass = mass;
    //     Console.WriteLine($"Załadowano {mass} kg {product} do kontenera {this.serialNumber}.");
    // }


    public void WarningMassage(string massage)
    {
        Console.WriteLine(massage);
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}, {nameof(Products)}: {Products}, {nameof(Temperature)}: {Temperature}, {nameof(TemperatureMap)}: {TemperatureMap}";
    }
}