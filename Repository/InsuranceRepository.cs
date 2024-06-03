using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repository
{
    public class InsuranceRepository
    {
        readonly string strConnection = "Data Source=127.0.0.1; Initial Catalog=DBCar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
        SqlConnection connection;

        public InsuranceRepository()
        {
            connection = new SqlConnection(strConnection);
            connection.Open();
        }

        public int InsertInsurance(Insurance insurance)
        {
            int result = 0;
            try
            {
                result = (int)new SqlCommand()
                {
                    CommandText = Insurance.INSERT,
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection,
                    Parameters =
                    {
                        new SqlParameter("@Description", insurance.Description),
                    }
                }.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return result;
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}