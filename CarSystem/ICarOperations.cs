using System.Collections.Generic;

namespace CarSystem
{
    public interface ICarOperations
    {
        bool AddCar(Car car);
        List<Car> ShowCars();
        Car SearchById(int id);
        bool UpdateCar(int id, Car newCar);
        bool DeleteCar(int id);
        void SaveCars(string filePath);
        void LoadCars(string filePath);
    }
}








