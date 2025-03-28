using System.Data.SqlTypes;

public class ContainerLiquid : Container, IHazardNotifier
{
    // private static int _selfNumber = 0;
    public bool IsDangerous;

    public ContainerLiquid(double loadMaxMass, double hight, double selfMass, double deep, bool isDangerous) : base(
        loadMaxMass, hight, selfMass, deep)
    {
        _selfNumber = _selfNumber + 1;
        this.SerialNumber = "KON-L-" + _selfNumber;
        this.IsDangerous = isDangerous;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, IsDangerous: {IsDangerous}";
    }


    public void WarningMassage(String massage)
    {
        Console.WriteLine(massage + " involved container serial number " + this.SerialNumber);
    }

    public override void LoadIn(double mass)
    {
        switch (this.IsDangerous)
        {
            case true:
                if (mass + this.LoadMass <= this.LoadMaxMass * 0.5)
                {
                    this.LoadMass = mass;
                }
                else
                {
                    WarningMassage("Container with dangerous load " +
                                   "can only be loaded to 50% of max load mass");

                    // throw new OverflowException("Container with dangerous load " +
                    //                                 "can only be loaded to 50% of max load mass");
                }

                break;

            case false:
                if (mass + this.LoadMass <= this.LoadMaxMass * 0.9)
                {
                    this.LoadMass = mass;
                }
                else
                {
                    WarningMassage("Container  " +
                                   "can only be loaded to 90% of max load mass");

                    // throw new OverflowException("Container  " +
                    //                             "can only be loaded to 90% of max load mass");
                }

                break;
        }
    }
}