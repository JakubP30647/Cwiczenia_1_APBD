using Cwiczenia_1_APBD;

public class Container
{
    public double loadMass;
    public double loadMaxMass;
    public double hight;
    public double selfMass;
    public double deep;
    public String serialNumber;


    public Container(double loadMaxMass, double hight, double selfMass, double deep)
    {
        this.loadMass = 0;
        this.loadMaxMass = loadMaxMass;
        this.hight = hight;
        this.selfMass = selfMass;
        this.deep = deep;
        this.serialNumber = "lol";
    }

    public override string ToString()
    {
        return
            $"{nameof(loadMass)}: {loadMass}, {nameof(loadMaxMass)}: {loadMaxMass}, {nameof(hight)}: {hight}, {nameof(selfMass)}: {selfMass}, {nameof(deep)}: {deep}, {nameof(serialNumber)}: {serialNumber}";
    }

    public virtual void loadOut()
    {
        this.loadMass = 0;
    }

    public virtual void loadIn(int mass)
    {

        if (mass <= this.loadMaxMass)
        {
            this.loadMass = mass;
        }
        else if (mass > this.loadMaxMass)
        {
            throw new OverfillException("Container IS TOO SMALL");
            
        }

    }
    


}