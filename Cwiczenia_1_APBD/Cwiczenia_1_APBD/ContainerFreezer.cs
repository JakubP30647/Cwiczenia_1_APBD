namespace Cwiczenia_1_APBD;

using static Cwiczenia_1_APBD.Products;

public class ContainerFreezer : Container, IHazardNotifier
{
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

    ~ContainerFreezer()
    {
        Console.WriteLine($"Destructor called for ContainerFreezer with SerialNumber: {this.SerialNumber}");
        // Perform any additional cleanup if necessary
    }


    public void WarningMassage(string massage)
    {
        Console.WriteLine(massage);
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}, Products: {Products}, Temperature: {Temperature}°C, TemperatureMap: {TemperatureMap}";
    }
}