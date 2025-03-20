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


        ContainerFreezer containerFreezer1 = new ContainerFreezer(100, 5, 10, 10, Products.Bananas);
        ContainerFreezer containerFreezer2 = new ContainerFreezer(100, 5, 10, 10, Products.Bananas);
        
        Console.WriteLine(containerFreezer1.serialNumber);
        Console.WriteLine(containerFreezer2.products);
        
        List<Container> containers = new List<Container>();
        containers.Add(containerLiquidDANGER);
        containers.Add(containerLiquidNOTDANGER);
        containers.Add(containerFreezer1);
        containers.Add(containerFreezer2);

        Ship ship = new Ship(6, 10, 10);
        
        
        Console.WriteLine(containerFreezer1);
        
        ship.loadContainer(containers);
        Console.WriteLine(containers[1]);
        Console.WriteLine(ship.hold[1]);
        
        
        
    }
    
}