using Cwiczenia_1_APBD;

public class Container
{
    public double LoadMass;
    public double LoadMaxMass;
    public double Hight;
    public double SelfMass;
    public double Deep;
    public String SerialNumber;


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
        return
            $"{nameof(LoadMass)}: {LoadMass}, {nameof(LoadMaxMass)}: {LoadMaxMass}, {nameof(Hight)}: {Hight}, {nameof(SelfMass)}: {SelfMass}, {nameof(Deep)}: {Deep}, {nameof(SerialNumber)}: {SerialNumber}";
    }

    public virtual void LoadOut()
    {
        this.LoadMass = 0;
    }

    public virtual void LoadIn(int mass)
    {
        if (mass <= this.LoadMaxMass)
        {
            this.LoadMass = mass;
        }
        else if (mass > this.LoadMaxMass)
        {
            throw new OverfillException("Container IS TOO SMALL");
        }
    }
}