using System.Security.AccessControl;
using Cwiczenia_1_APBD;


public class Program
{
    public static void Main(string[] args)
    {
        // Container container = new Container(100, 5, 10, 10);
        // ContainerLiquid containerLiquidDANGER = new ContainerLiquid(100, 5, 10, 10, true);
        // ContainerLiquid containerLiquidNOTDANGER = new ContainerLiquid(100, 5, 10, 10, false);
        //
        // Console.WriteLine(container.SerialNumber);
        //
        //
        // containerLiquidDANGER.LoadIn(1000);
        // containerLiquidNOTDANGER.LoadIn(1000);
        //
        //
        // containerLiquidDANGER.LoadIn(490);
        // containerLiquidNOTDANGER.LoadIn(89);
        //
        // Console.WriteLine(containerLiquidDANGER.LoadMass);
        // Console.WriteLine(containerLiquidNOTDANGER.LoadMass);
        //
        //
        // ContainerGas containerGas = new ContainerGas(100, 5, 10, 10,1);
        //
        //
        // Console.WriteLine(containerGas.SerialNumber);
        //
        // containerGas.LoadIn(100);
        // Console.WriteLine("[PRZED]  "+containerGas.LoadMass);
        //
        // containerGas.LoadOut();
        // Console.WriteLine(containerGas.LoadMass);


        ContainerFreezer containerFreezer1 = new ContainerFreezer(1000, 5, 10, 10, Products.Bananas, 1);
        ContainerFreezer containerFreezer2 = new ContainerFreezer(1000, 5, 10, 10, Products.Bananas, 1);
        Ship ship = new Ship(2, 2, 3);
        
        ship.LoadContainer(containerFreezer1);
        ship.LoadContainer(containerFreezer2);
        Console.WriteLine(ship.hold);

        //
        // Console.WriteLine(containerFreezer1.SerialNumber);
        // Console.WriteLine(containerFreezer2.Products);
        //
        // List<Container> containers = new List<Container>();
        // containers.Add(containerLiquidDANGER);
        // containers.Add(containerLiquidNOTDANGER);
        // containers.Add(containerFreezer1);
        // containers.Add(containerFreezer2);
        //
        // Ship ship = new Ship(6, 10, 10);
        //
        //
        // Console.WriteLine(containerFreezer1);
        //
        // ship.LoadContainer(containers);
        // Console.WriteLine(containers[1]);
        // Console.WriteLine(ship.hold[1]);
        //
        // ship.LoadContainer(containers);
    }
}