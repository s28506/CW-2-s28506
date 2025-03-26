using CW_2_s28506.Utils;

namespace CW_2_s28506.Model;

public class LiquidContainer : Container, IHazardNotifier
{
    private static int _counter;
    private static char _typeLetter = 'L';
    public bool IsCargoDangerous { get; }

    public LiquidContainer(int cargoWeight, int height, int containerWeight, int depth, int maxCapacity,
        bool isCargoDangerous) : base(cargoWeight, height, containerWeight, depth,
        maxCapacity, ref _typeLetter, ref _counter)
    {
        if ((isCargoDangerous && cargoWeight > maxCapacity * 0.5) || cargoWeight > maxCapacity * 0.9)
        {
            throw new OverfillException("Initial cargo weight exceeds maximum capacity!");
        }

        IsCargoDangerous = isCargoDangerous;
    }

    public override void LoadContainer(int weight)
    {
        if ((IsCargoDangerous && weight + ContainerWeight > MaxCapacity * 0.5) || weight + ContainerWeight > MaxCapacity * 0.9)
        {
            SendNotify("attempt of a dangerous situation");
        }
        else
        {
            base.LoadContainer(weight);
        }
    }

    public void SendNotify(string msg)
    {
        Console.WriteLine($"Liquid container {SerialNumber} is alerting a dangerous situation!\nDetails:{msg}");
    }

    public override string ToString()
    {
        return base.ToString() + $", Is Cargo Dangerous: {IsCargoDangerous}";
    }
}