using Model;
using Repository;

namespace Service
{
    public class CarService
    {
        private CarRepository _carRepository;

        public CarService() => _carRepository = new();

        public bool InsertCar(Car car) => _carRepository.InsertCar(car);

        public bool UpdateCar(Car car) => _carRepository.UpdateCar(car);

        public bool DeleteCar(int id) => _carRepository.DeleteCar(id);

        public List<Car> GetAllCars() => _carRepository.GetAllCars();

        public Car? GetCarById(int id) => _carRepository.GetCarById(id);
    }
}