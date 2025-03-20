public class KontenerLiquid : Kontener, IHazardNotifier
{
    
    private static int selfNumber = 1;
    public KontenerLiquid(double loadMaxMass, double hight, double selfMass, double deep) : base(loadMaxMass, hight, selfMass, deep)
    {
        selfNumber = selfNumber + 1;
        this.serialNumber = "KON-L-" + selfNumber;
    }

    public void warningMassage(string serialNumber)
    {
        Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }
}