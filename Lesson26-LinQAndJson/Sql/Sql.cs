using Microsoft.Data.SqlClient;

namespace Lesson26_LinQAndJson
{
    public class Sql
    {
        readonly string Connection = "Data Source=127.0.0.1; Initial Catalog=DBPenalties; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
        readonly SqlConnection sqlConnection;
        readonly SqlCommand sqlCommand;

        public Sql()
        {
            sqlConnection = new(Connection);
            sqlCommand = new()
            {
                CommandText = "spInitializePenalty",
                CommandType = System.Data.CommandType.StoredProcedure,
                Connection = sqlConnection
            };
        }

        public void InsertPenalties(List<Penalty> lst)
        {
            sqlCommand.CommandText = ("spInsertPenalty");
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (var item in lst)
            {
                sqlCommand.Parameters.AddRange(

                new SqlParameter[]
                {
                    new SqlParameter("@CompanyName", item.CompanyName),
                    new SqlParameter("@CNPJ", item.Cnpj),
                    new SqlParameter("@DriverName", item.DriverName),
                    new SqlParameter("@CPF", item.Cpf),
                    new SqlParameter("@VigencyDate", item.VigencyDate)
                });

                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                sqlCommand.Parameters.Clear();
            }
        }

        internal bool IsEmpty()
        {
            bool isEmpty = true;

            sqlCommand.CommandText = ("spGetPenalty");
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@PenaltyID", 1);

            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            using SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader != null)
                isEmpty = false;

            sqlCommand.Parameters.Clear();
            sqlConnection.Close();

            return isEmpty;
        }
    }
}