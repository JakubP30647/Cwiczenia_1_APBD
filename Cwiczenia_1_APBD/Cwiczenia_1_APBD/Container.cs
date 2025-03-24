using Cwiczenia_1_APBD;

public class Container
{
    public double LoadMass;
    public double LoadMaxMass;
    public double Hight;
    public double SelfMass;
    public double Deep;
    public String SerialNumber;
    public static int _selfNumber = 0;


    public Container(double loadMaxMass, double hight, double selfMass, double deep)
    {
        this.LoadMass = 0;
        this.LoadMaxMass = loadMaxMass;
        this.Hight = hight;
        this.SelfMass = selfMass;
        this.Deep = deep;
        this.SerialNumber = "lol";
    }

    public override string ToString()
    {
        return $"LoadMass: {LoadMass} kg, LoadMaxMass: {LoadMaxMass} kg, Height: {Hight} m, SelfMass: {SelfMass} kg, Depth: {Deep} m, SerialNumber: {SerialNumber}";
    }

    public virtual void LoadOut()
    {
        this.LoadMass = 0;
    }

    public virtual void LoadIn(double mass)
    {
        if (mass + this.LoadMass <= this.LoadMaxMass)
        {
            this.LoadMass += mass;
        }
        else if (mass + this.LoadMass > this.LoadMaxMass)
        {
            throw new OverfillException("Container IS TOO SMALL");
        }
    }
}