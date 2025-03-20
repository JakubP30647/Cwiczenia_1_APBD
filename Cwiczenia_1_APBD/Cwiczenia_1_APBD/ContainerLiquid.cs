using System.Data.SqlTypes;

public class ContainerLiquid : Container, IHazardNotifier
{
    private static int selfNumber = 0;
    public bool isDanger;

    public ContainerLiquid(double loadMaxMass, double hight, double selfMass, double deep, bool isDanger) : base(
        loadMaxMass, hight, selfMass, deep)
    {
        selfNumber = selfNumber + 1;
        this.serialNumber = "KON-L-" + selfNumber;
        this.isDanger = isDanger;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(isDanger)}: {isDanger}";
    }

    public void warningMassage(String massage)
    {
        Console.WriteLine(massage + " involved container serial number " + this.serialNumber);
    }

    public override void loadIn(int mass)
    {
        switch (this.isDanger)
        {
            case true:
                if (mass <= this.loadMaxMass * 0.5) { 
                    this.loadMass = mass;
                }else {
                    
                    warningMassage("Container with dangerous load " +
                                                     "can only be loaded to 50% of max load mass");
                    
                    // throw new OverflowException("Container with dangerous load " +
                    //                                 "can only be loaded to 50% of max load mass");
                }
                break;

            case false:
                if (mass <= this.loadMaxMass * 0.9) {
                    this.loadMass = mass;
                }
                else {
                    warningMassage("Container  " +
                                   "can only be loaded to 90% of max load mass");
                    
                    // throw new OverflowException("Container  " +
                    //                             "can only be loaded to 90% of max load mass");
                }
                break;
        }
    }
    
    
    
    
}