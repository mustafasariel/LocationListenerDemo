using CoreApp;
using System;
using Dapper;
using Z.Dapper.Plus;
using System.Data.SqlClient;

namespace DAL
{
    public class DataAccesLayer
    {
        string conStr = @"Server=msariel\SQLEXPRESS;Database=DapperDemo;Integrated security=true;";

        public void Add(Location location)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(conStr))
                {
                    sqlConnection.Open();
                    string strQuery = $"insert into Location(Lat,Lan,Description) values(@Lat,@Lan,@Description)";
                    sqlConnection.Execute(strQuery, location);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

           
        }
    }
}
