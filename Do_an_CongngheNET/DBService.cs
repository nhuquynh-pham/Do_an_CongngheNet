using System;
using System.Data;
using System.Data.SqlClient;

namespace Do_an_CongngheNET
{
    public class DBService
    {
        private readonly string _connectionString;

        public DBService()
        {
            _connectionString =
            @"Data Source=localhost;
              Initial Catalog=QLKTX;
              Integrated Security=True;
              TrustServerCertificate=True";
        }

        // SELECT
        public DataTable ExecuteQuery(
    string sql,
    params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn =
                   new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd =
                       new SqlCommand(sql, conn))
                {
                    if (parameters != null &&
                        parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter da =
                           new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }
        // INSERT UPDATE DELETE
        public int ExecuteNonQuery(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn =
                   new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd =
                       new SqlCommand(sql, conn))
                {
                    if (parameters != null &&
                        parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // COUNT SUM MAX...
        public object ExecuteScalar(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn =
                   new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd =
                       new SqlCommand(sql, conn))
                {
                    if (parameters != null &&
                        parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();

                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}