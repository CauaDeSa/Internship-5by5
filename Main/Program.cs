using Controller;
using Model;

namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new()
            {
                Id = 1,
                Name = "McLaren P1",
                Color = "Silver",
                Year = 2024
            };

            Console.WriteLine(new CarController().InsertCar(car) ? "Car inserted successfully" : "Failed to insert car!");
        }
    }
}