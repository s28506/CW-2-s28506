namespace CW_2_s28506.Model;

public class ContainerShip(int maxSpeed, int maxContainersAmount, int maxContainersWeight)
{
    public List<Container> ContainerList { get; } = [];
    public int MaxSpeed { get; } = maxSpeed;
    public int MaxContainersAmount { get; } = maxContainersAmount;
    public int MaxContainersWeight { get; } = maxContainersWeight * 1000;

    public ContainerShip(int maxSpeed, int maxContainersAmount, int maxContainersWeight, List<Container> list) : this(
        maxSpeed, maxContainersAmount, maxContainersWeight)
    {
        LoadContainer(list);
    }

    public ContainerShip(int maxSpeed, int maxContainersAmount, int maxContainersWeight, Container container) : this(
        maxSpeed, maxContainersAmount, maxContainersWeight)
    {
        LoadContainer(container);
    }

    public void LoadContainer(Container container)
    {
        if (ContainerList.Count == MaxContainersAmount)
        {
            throw new Exception("No more free space on the ship");
        }

        if (CalculateTotalContainersWeight(ContainerList) + container.GetTotalWeight() > MaxContainersWeight)
        {
            throw new Exception("Too heavy cargo on the ship");
        }

        ContainerList.Add(container);
    }

    public void LoadContainer(List<Container> containers)
    {
        if (ContainerList.Count + containers.Count > MaxContainersAmount)
        {
            throw new Exception("No more free space on the ship");
        }

        if (CalculateTotalContainersWeight(ContainerList) + CalculateTotalContainersWeight(containers) >
            MaxContainersWeight)
        {
            throw new Exception("Too heavy cargo on the ship");
        }

        ContainerList.AddRange(containers);
    }

    public void UnloadContainer(string containerSerialNumber)
    {
        var container = GetContainer(containerSerialNumber);
        if (container != null)
        {
            ContainerList.Remove(container);
        }
        else
        {
            throw new Exception("Container not found.");
        }
    }

    public void ReplaceContainer(string containerSerialNumber, Container newContainer)
    {
        var container = GetContainer(containerSerialNumber);
        if (container != null)
        {
            ContainerList.Remove(container);
            LoadContainer(newContainer);
        }
        else
        {
            throw new Exception("Container not found.");
        }
    }

    public void TransferContainerTo(ContainerShip ship, string containerSerialNumber)
    {
        var container = GetContainer(containerSerialNumber);
        if (container != null)
        {
            UnloadContainer(container.SerialNumber);
            ship.LoadContainer(container);
        }
        else
        {
            throw new Exception("Container not found.");
        }
    }

    private Container? GetContainer(string containerSerialNumber)
    {
        return ContainerList.FirstOrDefault(container => container.SerialNumber.Equals(containerSerialNumber));
    }

    private int CalculateTotalContainersWeight(List<Container> containers)
    {
        var sum = containers.Sum(container => container.GetTotalWeight());
        return sum;
    }

    public override string ToString()
    {
        return $"Max speed: {MaxSpeed}, Max Container Amount: {MaxContainersAmount}, Max Containers Weight: {MaxContainersWeight}, Contains:\n[{string.Join(",\n",ContainerList)}]";
    }
}