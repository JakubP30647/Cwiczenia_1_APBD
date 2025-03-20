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