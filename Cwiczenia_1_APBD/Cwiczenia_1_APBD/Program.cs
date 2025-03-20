using System.Security.AccessControl;

public class Kontener
{
    public double loadMass { get; private set; }
    public double loadMaxMass;
    public double hight;
    public double selfMass;
    public double deep;
    public String serialNumber;


    public Kontener(double loadMaxMass, double hight, double selfMass, double deep)
    {
        this.loadMass = 0;
        this.loadMaxMass = loadMaxMass;
        this.hight = hight;
        this.selfMass = selfMass;
        this.deep = deep;
        this.serialNumber = "lol";
    }

    public void loadOut()
    {
        this.loadMass = 0;
    }

    public void loadIn(int mass)
    {

        if (mass < this.loadMaxMass)
        {
            this.loadMass = mass;
        }
        else if (mass > this.loadMaxMass)
        {
            throw new OverfillException("Kontener IS TOO SMALL");
            
        }

    }


}

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


public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
    
}

public interface IHazardNotifier
{

    public void warningMassage(String serialNumber);


}





public class Program
{

    public static void Main(string[] args)
    {


        Kontener kontener = new Kontener(100, 5, 10, 10);

        
        Console.WriteLine(kontener.loadMass);
        kontener.loadOut();
        Console.WriteLine(kontener.loadMass);
        kontener.loadIn(1);
        Console.WriteLine(kontener.loadMass);
        Console.WriteLine(kontener.loadMass);
        
        //kontener.loadIn(1000);
        Console.WriteLine(kontener.loadMass);
        
        

    }
    
}