using CW_2_s28506.Model;

namespace CW_2_s28506;

class Program
{
    public static void Main(string[] args)
    {
        // Stworzenie kontenerów
        var liquidContainer = new LiquidContainer(500, 200, 100, 150, 1000, true);
        var gasContainer = new GasContainer(300, 200, 120, 150, 800);
        var refrigeratedContainer = new RefrigeratedContainer(400, 200, 110, 150, 900, "Fish", 3);
            
        // Załadowanie ładunku do kontenera
        liquidContainer.LoadContainer(100);
            
        // Stworzenie statku i załadowanie pojedynczego kontenera
        var ship1 = new ContainerShip(50, 5, 5);
        ship1.LoadContainer(liquidContainer);
            
        // Załadowanie listy kontenerów
        var containerList = new List<Container> { gasContainer, refrigeratedContainer };
        ship1.LoadContainer(containerList);
            
        // Usunięcie kontenera ze statku
        ship1.UnloadContainer(gasContainer.SerialNumber);
            
        // Rozładowanie kontenera
        liquidContainer.EmptyContainer();
            
        // Zastąpienie kontenera na statku innym kontenerem
        var newContainer = new LiquidContainer(600, 220, 130, 160, 1100, false);
        ship1.ReplaceContainer(refrigeratedContainer.SerialNumber, newContainer);
            
        // Przeniesienie kontenera między dwoma statkami
        var ship2 = new ContainerShip(45, 4, 4);
        ship1.TransferContainerTo(ship2, newContainer.SerialNumber);
            
        // Wypisanie informacji o kontenerze
        Console.WriteLine(liquidContainer);
        Console.WriteLine(gasContainer);
        Console.WriteLine(refrigeratedContainer);
        
        // Wypisanie informacji o statku i jego ładunku
        Console.WriteLine(ship1);
        Console.WriteLine(ship2);
    }
}