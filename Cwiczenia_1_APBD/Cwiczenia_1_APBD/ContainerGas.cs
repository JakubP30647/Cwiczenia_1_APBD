namespace Cwiczenia_1_APBD;

public class ContainerGas : Container, IHazardNotifier
{
    static int selfNumber = 0;
    public double pressure; // w atmosferach

    public ContainerGas(double loadMaxMass, double hight, double selfMass, double deep, double pressure) : base(
        loadMaxMass, hight, selfMass, deep)
    {
        selfNumber = selfNumber + 1;
        this.SerialNumber = "KON-G-" + selfNumber;
        this.pressure = pressure;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(pressure)}: {pressure}";
    }


    public override void LoadOut()
    {
        this.LoadMass = this.LoadMass * 0.05;
    }


    public void WarningMassage(string massage)
    {
        Console.WriteLine(massage);
    }
}