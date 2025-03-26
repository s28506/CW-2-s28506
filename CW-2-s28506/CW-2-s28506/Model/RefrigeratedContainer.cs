using CW_2_s28506.Utils;

namespace CW_2_s28506.Model;

public class RefrigeratedContainer : Container, IHazardNotifier
{
    private static int _counter;
    private static char _typeLetter = 'C';
    public static Dictionary<string, double> ProductsDictionary { get; } = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public double Temperature { get; set; }

    private string _product;

    public string Product
    {
        get => _product;
        set
        {
            if (!ProductsDictionary.ContainsKey(value))
            {
                throw new Exception($"Product does not belong to this list:\n{ProductsDictionary.Keys}");
            }

            if (Temperature < ProductsDictionary[value])
            {
                throw new Exception($"Container has too low temperature ({Temperature}) for product ({value})" +
                                    $" required minimum temperature ({ProductsDictionary[value]})!");
            }

            _product = value;
        }
    }


    public RefrigeratedContainer(int cargoWeight, int height, int containerWeight, int depth, int maxCapacity,
        string product, double temperature) :
        base(cargoWeight, height, containerWeight, depth, maxCapacity, ref _typeLetter, ref _counter)
    {
        Temperature = temperature;
        Product = product;
    }

    public void SendNotify(string msg)
    {
        Console.WriteLine($"Refrigerated container {SerialNumber} is alerting a dangerous situation!\nDetails:{msg}");
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Product: {Product}, Temperature: {Temperature}";
    }
}