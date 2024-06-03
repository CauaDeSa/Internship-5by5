using Microsoft.Data.SqlClient;
using Model;

namespace Repository
{
    public class CarRepository
    {
        readonly string strConnection = "Data Source=127.0.0.1; Initial Catalog=DBCar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
        SqlConnection connection;

        public CarRepository() 
        {
            connection = new SqlConnection(strConnection);
            connection.Open();
        }

        public bool InsertCar(Car car)
        {
            try
            {
                new SqlCommand()
                {
                    CommandText = Car.INSERT,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection,
                    Parameters =
                    {
                        new SqlParameter("@Name", car.Name),
                        new SqlParameter("@Color", car.Color),
                        new SqlParameter("@Year", car.Year),
                        new SqlParameter("@InsuranceId", car.Insurance.Id)
                    }
                }.ExecuteNonQuery();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false; 
            }
            finally 
            { 
                connection.Close(); 
            }

            return true;
        }

        public List<Car> GetAllCars()
        {
            SqlDataReader data;
            List<Car> cars = new();

            try
            {
                data = new SqlCommand()
                {
                    CommandText = Car.GETALL,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection
                }.ExecuteReader();

                while (data.Read())
                    cars.Add(new Car()
                    {
                        Id = data.GetInt32(0),
                        Name = data.GetString(1),
                        Color = data.GetString(2),
                        Year = data.GetInt32(3)
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
            finally
            {
                connection.Close();
            }

            return cars;
        }

        public Car? GetCarById(int id)
        {
            SqlDataReader reader;
            Car? car = null;

            try
            {
                reader = new SqlCommand()
                {
                    CommandText = Car.GET,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection,
                    Parameters =
                    {
                        new SqlParameter("@Id", id)
                    }
                }.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            while (reader.Read())
                car = new Car()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Color = reader.GetString(2),
                    Year = reader.GetInt32(3)
                };


            return car;
        }

        public bool UpdateCar(Car car)
        {
            bool result = false;

            try
            {
                result = new SqlCommand()
                {
                    CommandText = Car.UPDATE,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection,
                    Parameters =
                    {
                        new SqlParameter("@Id", car.Id),
                        new SqlParameter("@Name", car.Name),
                        new SqlParameter("@Color", car.Color),
                        new SqlParameter("@Year", car.Year)
                    }
                }.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public bool DeleteCar(int id)
        {
            bool result = false;

            try
            {
                result = new SqlCommand()
                         {
                             CommandText = Car.DELETE,
                             CommandType = System.Data.CommandType.StoredProcedure,
                             Connection = connection,
                             Parameters =
                             {
                                 new SqlParameter("@Id", id)
                             }
                         }.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}