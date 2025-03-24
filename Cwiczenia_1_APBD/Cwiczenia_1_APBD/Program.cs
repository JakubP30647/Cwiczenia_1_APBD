using System;
using System.Collections.Generic;

namespace Cwiczenia_1_APBD
{
    class Program
    {
        static List<Ship> ships = new List<Ship>();
        static List<Container> containers = new List<Container>();

        public static void Main(string[] args)
        {
            while (true)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddShip();
                        break;
                    case "2":
                        if (ships.Count > 0) RemoveShip();
                        else Console.WriteLine("Nie ma żadnych kontenerowców do usunięcia.");
                        break;
                    case "3":
                        AddContainer();
                        break;
                    case "4":
                        if (containers.Count > 0) RemoveContainer();
                        else Console.WriteLine("Nie ma żadnych kontenerów do usunięcia.");
                        break;
                    case "5":
                        if (ships.Count > 0 && containers.Count > 0) AddContainerToShip();
                        else Console.WriteLine("Nie ma kontenerowców lub kontenerów do dodania.");
                        break;
                    case "6":
                        if (ships.Count > 0 && containers.Count > 0) RemoveContainerFromShip();
                        else Console.WriteLine("Nie ma kontenerowców lub kontenerów do usunięcia.");
                        break;
                    case "7":
                        ShowShips();
                        break;
                    case "8":
                        ShowContainers();
                        break;
                    case "9":
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
            Console.WriteLine("Lista kontenerowców:");
            if (ships.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ships[i]}");
                }
            }

            Console.WriteLine("\nLista kontenerów:");
            if (containers.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                for (int i = 0; i < containers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {containers[i]}");
                }
            }

            Console.WriteLine("\nMożliwe akcje:");
            Console.WriteLine("1. Dodaj kontenerowiec");

            if (ships.Count > 0)
            {
                Console.WriteLine("2. Usuń kontenerowiec");
            }

            Console.WriteLine("3. Dodaj kontener");

            if (containers.Count > 0)
            {
                Console.WriteLine("4. Usuń kontener");
                Console.WriteLine("5. Dodaj kontener do statku");
                Console.WriteLine("6. Usuń kontener ze statku");
            }

            Console.WriteLine("7. Wyświetl listę kontenerowców");
            Console.WriteLine("8. Wyświetl listę kontenerów");
            Console.WriteLine("9. Wyjdź");
            Console.Write("Wybór: ");
        }

        static void AddShip()
        {
            Console.WriteLine("Podaj nazwę statku:");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj maksymalną prędkość (km/h):");
            double speed = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj maksymalną liczbę kontenerów:");
            int capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj maksymalną wagę (kg):");
            double maxWeight = double.Parse(Console.ReadLine());

            Ship ship = new Ship(capacity, speed, maxWeight);
            ships.Add(ship);
            Console.WriteLine($"Statek {name} dodany!");
            Console.ReadLine();
        }

        static void RemoveShip()
        {
            Console.WriteLine("Wybierz numer statku do usunięcia:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i]}");
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < ships.Count)
            {
                ships.RemoveAt(index);
                Console.WriteLine("Statek został usunięty.");
            }
            else
            {
                Console.WriteLine("Niepoprawny numer statku.");
            }

            Console.ReadLine();
        }

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
                    container = new ContainerGas(maxMass, height, selfMass, deep, pressure);
                    break;

                case 2:
                    Console.WriteLine("Podaj maksymalną wagę ładunku (kg):");
                    maxMass = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj wysokość kontenera (m):");
                    height = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj wagę kontenera (kg):");
                    selfMass = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj głębokość kontenera (m):");
                    deep = double.Parse(Console.ReadLine());
                    Console.WriteLine("Czy kontener jest niebezpieczny? (true/false):");
                    bool isDangerous = bool.Parse(Console.ReadLine());
                    container = new ContainerLiquid(maxMass, height, selfMass, deep, isDangerous);
                    break;

                case 3:
                    Console.WriteLine("Podaj maksymalną wagę ładunku (kg):");
                    maxMass = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj wysokość kontenera (m):");
                    height = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj wagę kontenera (kg):");
                    selfMass = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj głębokość kontenera (m):");
                    deep = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj temperaturę (°C):");
                    double temperature = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj produkt (0 = Bananas, 1 = Chocolate, ...):");
                    int productIndex = int.Parse(Console.ReadLine());
                    Products product = (Products)productIndex;
                    container = new ContainerFreezer(maxMass, height, selfMass, deep, product, temperature);
                    break;

                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    return;
            }

            containers.Add(container);
            Console.WriteLine("Kontener został dodany!");
            Console.ReadLine();
        }

        static void RemoveContainer()
        {
            Console.WriteLine("Wybierz numer kontenera do usunięcia:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i]}");
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < containers.Count)
            {
                containers.RemoveAt(index);
                Console.WriteLine("Kontener został usunięty.");
            }
            else
            {
                Console.WriteLine("Niepoprawny numer kontenera.");
            }

            Console.ReadLine();
        }

        static void AddContainerToShip()
        {
            Console.WriteLine("Wybierz statek, do którego chcesz dodać kontener:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i]}");
            }

            int shipIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Wybierz kontener, który chcesz dodać:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i]}");
            }

            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            if (shipIndex >= 0 && shipIndex < ships.Count && containerIndex >= 0 && containerIndex < containers.Count)
            {
                ships[shipIndex].LoadContainer(containers[containerIndex]);
                Console.WriteLine("Kontener został dodany do statku.");
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

            Console.WriteLine("Wybierz kontener, który chcesz usunąć:");
            for (int i = 0; i < ships[shipIndex].hold.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[shipIndex].hold[i]}");
            }

            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            if (shipIndex >= 0 && shipIndex < ships.Count && containerIndex >= 0 &&
                containerIndex < ships[shipIndex].hold.Count)
            {
                ships[shipIndex].delContainer(ships[shipIndex].hold[containerIndex].SerialNumber);
                Console.WriteLine("Kontener został usunięty ze statku.");
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }

            Console.ReadLine();
        }

        static void ShowShips()
        {
            Console.WriteLine("Lista kontenerowców:");
            if (ships.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ships[i]}");
                }
            }

            Console.ReadLine();
        }

        static void ShowContainers()
        {
            Console.WriteLine("Lista kontenerów:");
            if (containers.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                for (int i = 0; i < containers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {containers[i]}");
                }
            }

            Console.ReadLine();
        }
    }
}