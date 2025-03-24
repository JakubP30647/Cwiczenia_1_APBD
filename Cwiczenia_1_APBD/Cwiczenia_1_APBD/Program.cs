using System;
using System.Collections.Generic;

namespace Cwiczenia_1_APBD
{
    class Program
    {
        static List<Ship> ships = new List<Ship>();
        static List<Container> containers = new List<Container>();

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddContainer();
                        break;
                    case "2":
                        if (containers.Count > 0) LoadCargoToContainer();
                        break;
                    case "3":
                        if (ships.Count > 0 && containers.Count > 0) AddContainerToShip();
                        break;
                    case "4":
                        if (ships.Count > 0 && containers.Count > 0) AddAllContainersToShip();
                        break;
                    case "5":
                        if (ships.Count > 0) RemoveContainerFromShip();
                        break;
                    case "6":
                        if (ships.Count > 0) UnloadContainer();
                        break;
                    case "7":
                        if (ships.Count > 0) ReplaceContainerOnShip();
                        break;
                    case "8":
                        if (ships.Count > 0 && containers.Count > 0) TransferContainerBetweenShips();
                        break;
                    case "9":
                        if (containers.Count > 0) ShowContainerInfo();
                        break;
                    case "10":
                        if (ships.Count > 0) ShowShipInfo();
                        break;
                    case "11":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Możliwe akcje:");

            
            Console.WriteLine("1. Stwórz kontener");

            // Opcje dotyczące kontenerów wyświetlane tylko, jeśli są kontenery
            if (containers.Count > 0)
            {
                Console.WriteLine("2. Załaduj ładunek do kontenera");
                Console.WriteLine("3. Załaduj kontener na statek");
                Console.WriteLine("4. Załaduj wszystkie kontenery na statek");
                Console.WriteLine("5. Usuń kontener ze statku");
                Console.WriteLine("6. Rozładuj kontener");
                Console.WriteLine("7. Zastąp kontener na statku");
                Console.WriteLine("8. Przenieś kontener między statkami");
                Console.WriteLine("9. Wypisz informacje o kontenerze");
            }

            // Opcje dotyczące statków wyświetlane tylko, jeśli są statki
            if (ships.Count > 0)
            {
                Console.WriteLine("10. Wypisz informacje o statku");
            }

            // Opcja zakończenia programu
            Console.WriteLine("11. Wyjście");
            Console.Write("Wybór: ");
        }

        // 1. Stworzenie kontenera
        static void AddContainer()
        {
            Console.WriteLine("Wybierz typ kontenera:");
            Console.WriteLine("1. Kontener gazowy");
            Console.WriteLine("2. Kontener cieczy");
            Console.WriteLine("3. Kontener zamrażarki");
            int choice = int.Parse(Console.ReadLine());

            Container container = null;

            switch (choice)
            {
                case 1:
                    container = CreateGasContainer();
                    break;
                case 2:
                    container = CreateLiquidContainer();
                    break;
                case 3:
                    container = CreateFreezerContainer();
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    return;
            }

            containers.Add(container);
            Console.WriteLine("Kontener został stworzony!");
            Console.ReadLine();
        }

        static Container CreateGasContainer()
        {
            Console.WriteLine("Podaj maksymalną wagę ładunku (kg):");
            double maxMass = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wysokość kontenera (m):");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wagę kontenera (kg):");
            double selfMass = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj głębokość kontenera (m):");
            double deep = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj ciśnienie w atmosferach:");
            double pressure = double.Parse(Console.ReadLine());
            return new ContainerGas(maxMass, height, selfMass, deep, pressure);
        }

        static Container CreateLiquidContainer()
        {
            Console.WriteLine("Podaj maksymalną wagę ładunku (kg):");
            double maxMass = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wysokość kontenera (m):");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wagę kontenera (kg):");
            double selfMass = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj głębokość kontenera (m):");
            double deep = double.Parse(Console.ReadLine());
            Console.WriteLine("Czy kontener jest niebezpieczny? (true/false):");
            bool isDangerous = bool.Parse(Console.ReadLine());
            return new ContainerLiquid(maxMass, height, selfMass, deep, isDangerous);
        }

        static Container CreateFreezerContainer()
        {
            Console.WriteLine("Podaj maksymalną wagę ładunku (kg):");
            double maxMass = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wysokość kontenera (m):");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wagę kontenera (kg):");
            double selfMass = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj głębokość kontenera (m):");
            double deep = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj temperaturę (°C):");
            double temperature = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj produkt (0 = Bananas, 1 = Chocolate, ...):");
            int productIndex = int.Parse(Console.ReadLine());
            Products product = (Products)productIndex;
            return new ContainerFreezer(maxMass, height, selfMass, deep, product, temperature);
        }

        
        static void LoadCargoToContainer()
        {
            Console.WriteLine("Wybierz kontener do załadowania ładunku:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i]}");
            }
            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            if (containerIndex >= 0 && containerIndex < containers.Count)
            {
                Console.WriteLine("Załaduj ładunek do kontenera (np. masę ładunku):");
                double cargoMass = double.Parse(Console.ReadLine());
                containers[containerIndex].LoadIn(cargoMass);
                Console.WriteLine("Ładunek został załadowany do kontenera.");
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
            Console.ReadLine();
        }

        // 3. Załadowanie kontenera na statek
        static void AddContainerToShip()
        {
            Console.WriteLine("Wybierz statek:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i]}");
            }
            int shipIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Wybierz kontener do załadowania na statek:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i]}");
            }
            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            if (shipIndex >= 0 && shipIndex < ships.Count && containerIndex >= 0 && containerIndex < containers.Count)
            {
                ships[shipIndex].LoadContainer(containers[containerIndex]);
                Console.WriteLine("Kontener załadowany na statek.");
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
            Console.ReadLine();
        }

        // 4. Załadowanie wszystkich kontenerów na statek
        static void AddAllContainersToShip()
        {
            Console.WriteLine("Wybierz statek:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i]}");
            }
            int shipIndex = int.Parse(Console.ReadLine()) - 1;

            if (shipIndex >= 0 && shipIndex < ships.Count)
            {
                foreach (var container in containers)
                {
                    ships[shipIndex].LoadContainer(container);
                }
                Console.WriteLine("Wszystkie kontenery zostały załadowane na statek.");
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
            Console.ReadLine();
        }

        
        static void RemoveContainerFromShip()
        {
            Console.WriteLine("Wybierz statek, z którego chcesz usunąć kontener:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i]}");
            }
            int shipIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Wybierz kontener do usunięcia:");
            for (int i = 0; i < ships[shipIndex].hold.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[shipIndex].hold[i]}");
            }
            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            if (shipIndex >= 0 && shipIndex < ships.Count && containerIndex >= 0 && containerIndex < ships[shipIndex].hold.Count)
            {
                ships[shipIndex].DelContainer(ships[shipIndex].hold[containerIndex].SerialNumber);
                Console.WriteLine("Kontener został usunięty ze statku.");
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
            Console.ReadLine();
        }

        // 6. Rozładunek kontenera
        static void UnloadContainer()
        {
            Console.WriteLine("Wybierz statek, z którego chcesz rozładować kontener:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i]}");
            }
            int shipIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Wybierz kontener do rozładowania:");
            for (int i = 0; i < ships[shipIndex].hold.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[shipIndex].hold[i]}");
            }
            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            if (shipIndex >= 0 && shipIndex < ships.Count && containerIndex >= 0 && containerIndex < ships[shipIndex].hold.Count)
            {
                ships[shipIndex].hold[containerIndex].LoadOut();
                Console.WriteLine("Kontener został rozładowany.");
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
            Console.ReadLine();
        }

        // 7. Zastąpienie kontenera na statku
        static void ReplaceContainerOnShip()
        {
            Console.WriteLine("Wybierz statek, na którym chcesz zastąpić kontener:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i]}");
            }
            int shipIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Wybierz kontener do zastąpienia:");
            for (int i = 0; i < ships[shipIndex].hold.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[shipIndex].hold[i]}");
            }
            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Wybierz nowy kontener do załadowania na statek:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i]}");
            }
            int newContainerIndex = int.Parse(Console.ReadLine()) - 1;

            if (shipIndex >= 0 && shipIndex < ships.Count && containerIndex >= 0 && containerIndex < ships[shipIndex].hold.Count && newContainerIndex >= 0 && newContainerIndex < containers.Count)
            {
                ships[shipIndex].SwapContainers(ships[shipIndex].hold[containerIndex].SerialNumber, containers[newContainerIndex]);
                Console.WriteLine("Kontener został zastąpiony.");
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
            Console.ReadLine();
        }

        // 8. Przeniesienie kontenera między statkami
        static void TransferContainerBetweenShips()
        {
            Console.WriteLine("Wybierz kontener do przeniesienia:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i]}");
            }
            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            if (containerIndex >= 0 && containerIndex < containers.Count)
            {
                Console.WriteLine("Wybierz statek, z którego kontener ma zostać przeniesiony:");
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ships[i]}");
                }
                int sourceShipIndex = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("Wybierz statek, na który kontener ma zostać przeniesiony:");
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ships[i]}");
                }
                int destinationShipIndex = int.Parse(Console.ReadLine()) - 1;

                if (sourceShipIndex >= 0 && sourceShipIndex < ships.Count && destinationShipIndex >= 0 && destinationShipIndex < ships.Count)
                {
                    
                    Container containerToTransfer = ships[sourceShipIndex].hold[containerIndex];
                    ships[sourceShipIndex].hold.Remove(containerToTransfer);
                    ships[destinationShipIndex].LoadContainer(containerToTransfer);
                    
                    
                    Console.WriteLine("Kontener został przeniesiony między statkami.");
                }
                else
                {
                    Console.WriteLine("Niepoprawny wybór.");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
            Console.ReadLine();
        }

        // 9. Wypisanie informacji o kontenerze
        static void ShowContainerInfo()
        {
            Console.WriteLine("Wybierz kontener do wyświetlenia informacji:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i]}");
            }
            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            if (containerIndex >= 0 && containerIndex < containers.Count)
            {
                Console.WriteLine(containers[containerIndex]);
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
            Console.ReadLine();
        }

        // 10. Wypisanie informacji o statku
        static void ShowShipInfo()
        {
            Console.WriteLine("Wybierz statek do wyświetlenia informacji:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i]}");
            }
            int shipIndex = int.Parse(Console.ReadLine()) - 1;

            if (shipIndex >= 0 && shipIndex < ships.Count)
            {
                Console.WriteLine(ships[shipIndex]);
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
            Console.ReadLine();
        }
    }
}
