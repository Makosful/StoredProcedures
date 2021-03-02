using System;
using System.Data;
using System.Data.SqlClient;

namespace StoresProcedures
{
    public class Database
    {
        private const string ConnectionString =
            "Data Source=tcp:192.168.1.180,1433;" +
            "Initial Catalog=Company;" +
            "User ID=axl;" +
            "Password=GXM62etj;";

        private readonly SqlConnection _sqlConnection = new(ConnectionString);

        public void CreateDepartment(string name, int manager)
        {
            const string procedure = @"[dbo].[usp_CreateDepartment]";
            var cmd = new SqlCommand(procedure, _sqlConnection);
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DName",
                SqlDbType = SqlDbType.NVarChar,
                Value = name
            });
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@MgrSSN",
                SqlDbType = SqlDbType.Int,
                Value = manager
            });

            _sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                {
                    var dNumber = reader.GetInt32(0);

                    Console.WriteLine("{0}", dNumber);
                }
            else
                Console.WriteLine("No data found");

            _sqlConnection.Close();
        }

        public void DeleteDepartment(int dno)
        {
            const string procedure = @"[dbo].[usp_DeleteDepartment]";
            var cmd = new SqlCommand(procedure, _sqlConnection);
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DNumber",
                SqlDbType = SqlDbType.Int,
                Value = dno
            });

            _sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            using SqlDataReader reader = cmd.ExecuteReader();

            _sqlConnection.Close();
        }

        public void UpdateDepartmentManager(int dno, int ssn)
        {
            const string procedure = @"[dbo].[usp_UpdateDepartmentManager]";
            var cmd = new SqlCommand(procedure, _sqlConnection);
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DNumber",
                SqlDbType = SqlDbType.Int,
                Value = dno
            });
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DNumber",
                SqlDbType = SqlDbType.Int,
                Value = ssn
            });

            _sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                {
                    var num = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var mgrSsn = reader.GetInt32(3);
                    var date = reader.GetDateTime(4);

                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", num, name, mgrSsn, date);
                }
            else
                Console.WriteLine("No data found");

            _sqlConnection.Close();
        }

        public void UpdateDepartmentName(int dno, string dName)
        {
            const string procedure = @"[dbo].[usp_UpdateDepartmentName]";
            var cmd = new SqlCommand(procedure, _sqlConnection);
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DNumber",
                SqlDbType = SqlDbType.Int,
                Value = dno
            });
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DName",
                SqlDbType = SqlDbType.NVarChar,
                Value = dno
            });

            _sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                {
                    var num = reader.GetInt32(0);
                    var name = reader.GetString(1);

                    Console.WriteLine("{0}\t{1}", num, name);
                }
            else
                Console.WriteLine("No data found");

            _sqlConnection.Close();
        }

        public void GetDepartment(int dno)
        {
            const string procedure = @"[dbo].[usp_GetDepartment]";
            var cmd = new SqlCommand(procedure, _sqlConnection);
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DNumber",
                SqlDbType = SqlDbType.Int,
                Value = dno
            });

            _sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                {
                    var empCount = reader.GetInt32(0);

                    Console.WriteLine("{0}", empCount);
                }
            else
                Console.WriteLine("No data found");

            _sqlConnection.Close();
        }

        public void GetAllDepartments()
        {
            const string procedure = @"[dbo].[usp_GetAllDepartments]";
            var cmd = new SqlCommand(procedure, _sqlConnection);

            _sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                {
                    var empCount = reader.GetInt32(0);
                    var depNumber = reader.GetInt32(1);

                    Console.WriteLine("{0} \t {1}", empCount, depNumber);
                }
            else
                Console.WriteLine("No data found");

            _sqlConnection.Close();
        }
    }
}