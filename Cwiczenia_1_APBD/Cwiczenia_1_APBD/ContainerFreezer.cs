namespace Cwiczenia_1_APBD;

using static Cwiczenia_1_APBD.Products;

public class ContainerFreezer : Container, IHazardNotifier
{
    private static int selfNumber = 0;
    public Products products;
    public double temperature;

    public Dictionary<Products, double> temperatureMap = new Dictionary<Products, double>
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
        Products products) : base(loadMaxMass, hight, selfMass, deep)
    {
        this.products = products;
        selfNumber = selfNumber + 1;
        this.serialNumber = "KON-C-" + selfNumber;
        this.products = products;
        this.temperature = temperatureMap[products];
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


    public void warningMassage(string massage)
    {
        Console.WriteLine(massage);
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}, {nameof(products)}: {products}, {nameof(temperature)}: {temperature}, {nameof(temperatureMap)}: {temperatureMap}";
    }
}