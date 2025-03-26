using CW_2_s28506.Utils;

namespace CW_2_s28506.Model;

public class GasContainer(int cargoWeight, int height, int containerWeight, int depth, int maxCapacity)
    : Container(cargoWeight, height, containerWeight, depth, maxCapacity, ref _typeLetter, ref _counter), IHazardNotifier
{
    private static int _counter;
    private static char _typeLetter = 'G';
    
    public override void EmptyContainer()
    {
        CargoWeight = (int)(CargoWeight * 0.05);
    }

    public void SendNotify(string msg)
    {
        Console.WriteLine($"Gas container {SerialNumber} is alerting a dangerous situation!\nDetails:{msg}");
    }
}