using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso : IAcceso
    {
        private static readonly string cadena =
            @"Data Source=DESKTOP-VG785IR;Initial Catalog=PracticaFinal;Integrated Security=True";
        SqlConnection connection;
        SqlCommand command;
        SqlTransaction transaction;

        public bool Escribir(string consulta, Hashtable parametros)
        {
            connection = new SqlConnection(cadena);
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            using (connection)
            {
                transaction = connection.BeginTransaction();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = consulta;
                command.Transaction = transaction;

                using (command)
                {
                    try
                    {
                        if (parametros != null)
                            foreach (string param in parametros.Keys)
                                command.Parameters.AddWithValue(param, parametros[param]);
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        return true;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        return false;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public DataTable Leer(string consulta)
        {
            connection = new SqlConnection(cadena);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            using (connection)
            {
                DataTable table = new DataTable();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = consulta;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                return table;
            }
        }
    }
}
