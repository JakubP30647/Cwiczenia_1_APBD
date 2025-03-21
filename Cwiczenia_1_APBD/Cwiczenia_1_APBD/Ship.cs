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
        double weightSum = 0;

        foreach (var con in this.hold)
        {
            weightSum += con.LoadMass + con.SelfMass;
        }

        weightSum += container.LoadMass + container.SelfMass;

        if (this.hold.Count + 1 < this.capacity && weightSum < this.maxWeight * 1000)
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


        if (this.hold.Count + containers.Count < this.capacity && weightSum < this.maxWeight * 1000)
        {
            hold.AddRange(containers);
        }
        else
        {
            Console.WriteLine("Failed to add containers, hold is too small or max weight of load in ship is too small");
        }
    }


    public override string ToString()
    {
        return
            $"{nameof(hold)}: {hold}, {nameof(capacity)}: {capacity}, {nameof(maxSpeed)}: {maxSpeed}, {nameof(maxWeight)}: {maxWeight}";
    }
}