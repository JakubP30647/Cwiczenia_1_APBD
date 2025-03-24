using System.Runtime.CompilerServices;

namespace Cwiczenia_1_APBD;

public class Ship
{
    public List<Container> hold;
    public int capacity;
    public double maxSpeed;
    public double maxWeight;


    public Ship(int capacity, double maxSpeed, double maxWeight)
    {
        this.hold = new List<Container>();
        this.capacity = capacity;
        this.maxSpeed = maxSpeed;
        this.maxWeight = maxWeight;
    }


    public void LoadContainer(Container container)
    {
        Console.WriteLine(this.hold.Count);
        double weightSum = 0;

        foreach (var con in this.hold)
        {
            weightSum += con.LoadMass + con.SelfMass;
        }

        weightSum += container.LoadMass + container.SelfMass;

        if (this.hold.Count + 1 <= this.capacity && weightSum <= this.maxWeight * 1000)
        {
            hold.Add(container);
        }
        else
        {
            Console.WriteLine("Failed to load container, hold is full or max weight of load in ship is too small");
        }
    }

    public void LoadContainer(List<Container> containers)
    {
        double weightSum = 0;

        foreach (var con in this.hold)
        {
            weightSum += con.LoadMass + con.SelfMass;
        }

        foreach (var con in containers)
        {
            weightSum += con.LoadMass + con.SelfMass;
        }


        if (this.hold.Count + containers.Count < this.capacity && weightSum <= this.maxWeight * 1000)
        {
            hold.AddRange(containers);
        }
        else
        {
            Console.WriteLine("Failed to add containers, hold is too small or max weight of load in ship is too small");
        }
    }

    public void DelContainer(String serialNumber)
    {
        foreach (var con in this.hold)
        {
            if (con.SerialNumber == serialNumber)
            {
                hold.Remove(con);
                Console.WriteLine("Container: " + serialNumber + " has been deleted");
                return;
            }
        }

        Console.WriteLine("Container: " + serialNumber + " is not in the hold");
    }

    public static void ContainersMove(Ship shipFrom, Ship shipTarget, String serialNumber)
    {
        Container exchanegC = null;
        foreach (var con in shipFrom.hold.ToList())
        {
            if (con.SerialNumber == serialNumber)
            {
                exchanegC = con;
                shipFrom.hold.Remove(con);
            }
        }


        if (exchanegC != null &&
            shipTarget.maxWeight * 1000 >= shipTarget.ShipLoadMass() + exchanegC.SelfMass + exchanegC.LoadMass)
        {
            shipFrom.hold.Add(exchanegC);
        }
        else
        {
            Console.WriteLine("Container: " + serialNumber +
                              "is not in the hold or max weight of load in ship is too small");
        }
    }


    public void SwapContainers(String serialNumber, Container addContainer)
    {
        foreach (var con in this.hold)
        {
            if (con.SerialNumber == serialNumber && this.maxWeight * 1000 >= this.ShipLoadMass() -
                (con.SelfMass + con.LoadMass) + addContainer.LoadMass + addContainer.SelfMass)
            {
                hold.Remove(con);
                hold.Add(addContainer);
                return;
            }
        }

        Console.WriteLine("Container: " + serialNumber +
                          " is not in the hold or max weight of load in ship is too small");
    }

    public double ShipLoadMass()
    {
        double mass = 0;

        foreach (var con in this.hold)
        {
            mass += con.LoadMass + con.SelfMass;
        }

        return mass;
    }


    public override string ToString()
    {
        return $"Ship: capacity: {capacity}, maxSpeed: {maxSpeed} mil, maxWeight: {maxWeight} kg, hold: {string.Join(",", hold)}";
    }

}