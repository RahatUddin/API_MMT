using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MMTShop.Models
{
    public class DataAccessLayer
    {
        SqlConnection sqlConnection;

        public DataAccessLayer() 
        {
            IConfigurationRoot configuration = GetConfiguration();
            sqlConnection = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("dbConnection").Value);
        }

        IConfigurationRoot GetConfiguration() 
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public DataTable GetData(string storedProcedure, string parameter)
        {
            using (SqlConnection con = sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlParameter param;
                    SqlDataAdapter adapter;

                    con.Open();
                    SqlCommand command = new SqlCommand(storedProcedure, con);
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameter.Length != 0)
                    {
                        param = new SqlParameter("@Parameter", parameter);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);
                    }

                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds, storedProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return ds.Tables[0];
            }
        }
        public void SetData(string storedProcedure, string parameter)
        {
            using (SqlConnection con = sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlParameter param;

                    con.Open();
                    SqlCommand command = new SqlCommand(storedProcedure, con);
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameter.Length != 0)
                    {
                        param = new SqlParameter("@Parameter", parameter);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);
                    }

                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        public int SetDataWithReturn(string storedProcedure, string parameter) 
        {
            using (SqlConnection con = sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlParameter param;

                    con.Open();
                    SqlCommand command = new SqlCommand(storedProcedure, con);
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameter.Length != 0)
                    {
                        param = new SqlParameter("@Parameter", parameter);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        command.Parameters.Add(param);
                    }

                    int returnValue = Convert.ToInt32(command.ExecuteScalar());
                    return returnValue;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }
}
