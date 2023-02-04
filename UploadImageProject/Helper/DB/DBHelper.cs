using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace UploadImageProject.Helper.DB
{
    static public class DBHelper
    {
        private static string ConnectionString { get; set; } = @"Data Source=95.216.193.252;Initial Catalog=ImageTestDB;user id=sa;Password =walan1@3;";



        public static List<SqlParameter> sqlParameters;

        public static SqlCommand command;
        //this methoud to get connection string from sql server
        public static SqlConnection getConnectionString()
        {
            return new SqlConnection(ConnectionString);

            //return new SqlConnection(ConnectionString);
        }

        // Set Connection String To [ConnectionString] Property
        public static void SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public static void AddSqlParameter(object Value, string ParameterName, SqlDbType type, ParameterDirection direction = ParameterDirection.Input, bool IsNallable = false)
        {
            SqlParameter companyidParameter = new SqlParameter();
            companyidParameter.Value = Value;
            companyidParameter.IsNullable = IsNallable;
            companyidParameter.ParameterName = ParameterName;
            companyidParameter.SqlDbType = type;
            companyidParameter.Direction = direction;
            sqlParameters.Add(companyidParameter);
        }

        //this methoud to make insert update delete and delete all in database in all program
        async public static Task<bool> excuteData(string spName)
        {
            using (SqlConnection connection = getConnectionString())
            {
                try
                {
                    command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    //Add Parameters To
                    // command.Parameters.AddRange(sqlParameters.ToArray());
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();

                }
            }

        }

        //this methoud to get any data in table or sp in database in all program
        public static DataTable getData(string spName)
        {
            DataTable tbl = new DataTable();
            SqlDataAdapter da;
            using (SqlConnection connection = getConnectionString())
            {
                try
                {
                    command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    //to excute methoud that contain parmaters
                    connection.Open();

                    da = new SqlDataAdapter(command);
                    da.Fill(tbl);
                    da.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tbl;
        }

        async public static Task<DataTable> getDatabyParmatersAsync(string spName)
        {
            return getDatabyParmaters(spName);
        }

        public static DataTable getDatabyParmaters(string spName)
        {
            DataTable tbl = new DataTable();
            SqlDataAdapter da;
            using (SqlConnection connection = getConnectionString())
            {
                try
                {
                    connection.Open();

                    command = new SqlCommand(spName, connection);

                    //to excute methoud that contain parmaters


                    if (sqlParameters != null)
                        command.Parameters.AddRange(sqlParameters.ToArray());
                    command.CommandType = CommandType.StoredProcedure;

                    da = new SqlDataAdapter(command);
                    da.Fill(tbl);
                    da.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tbl;
        }


        async public static Task<List<T>> ExecuteSPAsync<T>(string SPName)
        {
            return await Task.Run(() => (ExecuteSP<T>(SPName)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"> Class Type </typeparam>
        /// <param name="SPName"> Store procedure Name </param>
        /// <returns></returns>
        public static List<T> ExecuteSP<T>(string SPName)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (SqlConnection Connection = getConnectionString())
                {
                    // Open connection
                    Connection.Open();

                    // Create command from params / SP
                    SqlCommand cmd = new SqlCommand(SPName, Connection);

                    // Add parameters
                    if (sqlParameters != null)
                        cmd.Parameters.AddRange(sqlParameters.ToArray());
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Make datatable for conversion
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                    da.Dispose();

                    // Close connection
                    Connection.Close();
                }

                // Convert to list of T
                var retVal = ConvertToList<T>(dataTable);
                return retVal;
            }
            catch (SqlException e)
            {
                return new List<T>();
            }
        }

        /// <summary>
        /// Converts datatable to List<someType> if possible.
        /// </summary>
        public static List<T> ConvertToList<T>(DataTable dt)
        {
            try // Necesarry unfotunately.
            {
                var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();

                var properties = typeof(T).GetProperties();

                return dt.AsEnumerable().Select(row =>
                {
                    var objT = Activator.CreateInstance<T>();

                    foreach (var pro in properties)
                    {
                        if (columnNames.Contains(pro.Name))
                        {
                            if (row[pro.Name].GetType() == typeof(System.DBNull)) pro.SetValue(objT, null, null);
                            else pro.SetValue(objT, row[pro.Name], null);
                        }
                    }

                    return objT;
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to write data to list. Often this occurs due to type errors (DBNull, nullables), changes in SP's used or wrongly formatted SP output.");
                Console.WriteLine("ConvertToList Exception: " + e.ToString());
                return new List<T>();
            }
        }

        async public static Task<bool> CheckForInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = await myPing.SendPingAsync(host, timeout, buffer, pingOptions);
                return ((reply.Status == IPStatus.Success) ? true : false);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
