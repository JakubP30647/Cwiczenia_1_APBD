namespace Cwiczenia_1_APBD;

public class ContainerFreezer : Container, IHazardNotifier
{
    
    private static int selfNumber = 0;
    
    public ContainerFreezer(double loadMaxMass, double hight, double selfMass, double deep) : base(loadMaxMass, hight, selfMass, deep)
    {
        
        selfNumber = selfNumber + 1;
        this.serialNumber = "KON-C-" + selfNumber;
        
        
    }

    public void warningMassage(string massage)
    {
        Console.WriteLine(massage);
    }
}