using System.Security.AccessControl;
using Cwiczenia_1_APBD;


public class Program
{
    public static void Main(string[] args)
    {
        
        Container container = new Container(100, 5, 10, 10);
        ContainerLiquid containerLiquidDANGER = new ContainerLiquid(100, 5, 10, 10, true);
        ContainerLiquid containerLiquidNOTDANGER = new ContainerLiquid(100, 5, 10, 10, false);
        
        Console.WriteLine(container.serialNumber);
        
        
        containerLiquidDANGER.loadIn(1000);
        containerLiquidNOTDANGER.loadIn(1000);
        
        
        containerLiquidDANGER.loadIn(49);
        containerLiquidNOTDANGER.loadIn(89);
        
        Console.WriteLine(containerLiquidDANGER.loadMass);
        Console.WriteLine(containerLiquidNOTDANGER.loadMass);
        
        
        ContainerGas containerGas = new ContainerGas(100, 5, 10, 10,1);

        
        Console.WriteLine(containerGas.serialNumber);
        
        containerGas.loadIn(100);
        Console.WriteLine("[PRZED]  "+containerGas.loadMass);
        
        containerGas.loadOut();
        Console.WriteLine(containerGas.loadMass);

    }
    
}