using System;

namespace CarSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarOperations manager = new CarManager();
            string filePath = "cars.txt";
            manager.LoadCars(filePath);

            while (true)
            {
                Console.WriteLine("\n==== Car System Menu ====");
                Console.WriteLine("1. Add Car");
                Console.WriteLine("2. Show Cars");
                Console.WriteLine("3. Search Car by ID");
                Console.WriteLine("4. Update Car");
                Console.WriteLine("5. Delete Car");
                Console.WriteLine("6. Save Cars");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (manager.ShowCars().Count >= 6)
                        {
                            Console.WriteLine("You can't add more than 6 cars.");
                            break;
                        }

                        Car newCar = new Car();
                        Console.Write("Enter ID: ");
                        int id;
                        if (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("Invalid ID!");
                            break;
                        }
                        if (manager.SearchById(id) != null)
                        {
                            Console.WriteLine("Car with this ID already exists!");
                            break;
                        }
                        newCar.Id = id;
                        Console.Write("Enter Name: ");
                        newCar.Name = Console.ReadLine();
                        Console.Write("Enter Color: ");
                        newCar.Color = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        decimal price;
                        if (!decimal.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine("Invalid Price!");
                            break;
                        }
                        newCar.Price = price;
                        Console.Write("Enter Model: ");
                        newCar.Model = Console.ReadLine();

                        if (manager.AddCar(newCar))
                            Console.WriteLine("Car added successfully.");
                        else
                            Console.WriteLine("Failed to add car.");
                        break;

                    case "2":
                        Console.WriteLine("\n--- Cars List ---");
                        foreach (var car in manager.ShowCars())
                        {
                            Console.WriteLine(car);
                        }
                        break;

                    case "3":
                        Console.Write("Enter ID to search: ");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            var car = manager.SearchById(id);
                            if (car != null)
                                Console.WriteLine(car);
                            else
                                Console.WriteLine("Car not found!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID!");
                        }
                        break;

                    case "4":
                        Console.Write("Enter ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            var car = manager.SearchById(id);
                            if (car == null)
                            {
                                Console.WriteLine("Car not found!");
                                break;
                            }
                            Car updatedCar = new Car { Id = id };
                            Console.Write("Enter New Name: ");
                            updatedCar.Name = Console.ReadLine();
                            Console.Write("Enter New Color: ");
                            updatedCar.Color = Console.ReadLine();
                            Console.Write("Enter New Price: ");
                            if (!decimal.TryParse(Console.ReadLine(), out price))
                            {
                                Console.WriteLine("Invalid Price!");
                                break;
                            }
                            updatedCar.Price = price;
                            Console.Write("Enter New Model: ");
                            updatedCar.Model = Console.ReadLine();

                            if (manager.UpdateCar(id, updatedCar))
                                Console.WriteLine("Car updated successfully.");
                            else
                                Console.WriteLine("Update failed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID!");
                        }
                        break;

                    case "5":
                        Console.Write("Enter ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            if (manager.DeleteCar(id))
                                Console.WriteLine("Car deleted successfully.");
                            else
                                Console.WriteLine("Car not found!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID!");
                        }
                        break;

                    case "6":
                        manager.SaveCars(filePath);
                        Console.WriteLine("Cars saved successfully.");
                        break;

                    case "7":
                        manager.SaveCars(filePath);
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}