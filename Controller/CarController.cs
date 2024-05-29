using Model;
using Service;

namespace Controller
{
    public class CarController
    {
        private CarService _carService;

        public CarController() => _carService = new();

        public bool InsertCar(Car car) => _carService.InsertCar(car);

        public bool UpdateCar(Car car) => _carService.UpdateCar(car);

        public bool DeleteCar(int id) => _carService.DeleteCar(id);

        public List<Car> GetAllCars() => _carService.GetAllCars();

        public Car GetCarById(int id) => _carService.GetCarById(id);
    }
}