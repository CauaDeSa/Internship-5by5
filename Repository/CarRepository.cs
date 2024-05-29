using Model;

namespace Repository
{
    public class CarRepository
    {
        public CarRepository() { }

        public bool InsertCar(Car car)
        {
            return true;
        }

        public bool UpdateCar(Car car)
        {
            return true;
        }

        public bool DeleteCar(int id)
        {
            return true;
        }

        public List<Car> GetAllCars()
        {
            return new List<Car>();
        }

        public Car GetCarById(int id)
        {
            return new Car();
        }
    }
}