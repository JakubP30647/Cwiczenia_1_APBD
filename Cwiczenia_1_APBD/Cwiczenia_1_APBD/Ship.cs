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


    public void loadContainer(Container container)
    {
        if (this.hold.Count + 1 < this.capacity)
        {
            hold.Add(container);
        }
        else
        {
            Console.WriteLine("Failed to load container, hold is full");
        }
        
    }
    
    public void loadContainer(List<Container> containers)
    {
        if (this.hold.Count + containers.Count < this.capacity)
        {
            hold.AddRange(containers);
        }
        else
        {
            Console.WriteLine("Failed to add containers, hold is too small");
        }
        
    }


    public override string ToString()
    {
        return
            $"{nameof(hold)}: {hold}, {nameof(capacity)}: {capacity}, {nameof(maxSpeed)}: {maxSpeed}, {nameof(maxWeight)}: {maxWeight}";
    }
}