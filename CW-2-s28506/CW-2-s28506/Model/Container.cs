using CW_2_s28506.Utils;

namespace CW_2_s28506.Model;

public abstract class Container
{

    public int CargoWeight { get; set; }

    public int Height { get; }
    public int ContainerWeight { get; }
    public int Depth { get; }
    public string SerialNumber { get; }
    public int MaxCapacity { get; }

    protected Container(int cargoWeight, int height, int containerWeight, int depth, int maxCapacity,
        ref char typeLetter, ref int counter)
    {
        if (cargoWeight > maxCapacity)
            throw new OverfillException("Initial cargo weight exceeds maximum capacity!");
        CargoWeight = cargoWeight;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        MaxCapacity = maxCapacity;
        SerialNumber = $"KON-{typeLetter}-{++counter}";
    }

    public virtual void EmptyContainer()
    {
        CargoWeight = 0;
    }

    public virtual void LoadContainer(int weight)
    {
        if (CargoWeight + weight > MaxCapacity)
        {
            throw new OverfillException("Cargo weight exceeds maximum capacity!");
        }
        CargoWeight += weight;
    }

    public int GetTotalWeight()
    {
        return CargoWeight + ContainerWeight;
    }

    public override string ToString()
    {
        return $"Serial Number: {SerialNumber}, Cargo weight: {CargoWeight}, Height: {Height}, Container Weight: {ContainerWeight}, Depth: {Depth}, Max Capacity: {MaxCapacity}";
    }
}