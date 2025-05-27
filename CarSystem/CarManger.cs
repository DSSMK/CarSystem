using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarSystem
{
    public class CarManager : ICarOperations
    {
        public List<Car> Cars { get; private set; } = new List<Car>();

        public bool AddCar(Car car)
        {
            if (Cars.Count >= 6)
                return false;
            if (Cars.Any(c => c.Id == car.Id))
                return false;
            Cars.Add(car);
            return true;
        }

        public List<Car> ShowCars()
        {
            return Cars;
        }

        public Car SearchById(int id)
        {
            return Cars.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateCar(int id, Car newCar)
        {
            var car = SearchById(id);
            if (car != null)
            {
                car.Name = newCar.Name;
                car.Color = newCar.Color;
                car.Price = newCar.Price;
                car.Model = newCar.Model;
                return true;
            }
            return false;
        }

        public bool DeleteCar(int id)
        {
            var car = SearchById(id);
            if (car != null)
            {
                Cars.Remove(car);
                return true;
            }
            return false;
        }

        public void SaveCars(string filePath)
        {
            var lines = Cars.Select(c => $"{c.Id},{c.Name},{c.Color},{c.Price},{c.Model}");
            File.WriteAllLines(filePath, lines);
        }

        public void LoadCars(string filePath)
        {
            Cars.Clear();
            if (!File.Exists(filePath)) return;
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 5)
                {
                    Cars.Add(new Car
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Color = parts[2],
                        Price = decimal.Parse(parts[3]),
                        Model = parts[4]
                    });
                }
            }
        }
    }
}