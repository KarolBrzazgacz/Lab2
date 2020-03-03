using System;
using System.Data.Sql;
using System.Data.SqlClient;using Dapper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"";
            using var connection = new SqlConnection(connectionString);

            var sql = "SELECT * FROM Region";
            var regions = connection.Query<Region>(sql);

            var region = new Region()
            {
                RegionDescription = "dapper obiekt",
                RegionID = 101
            };

            var insertSql = "INSERT INTO Region(regionID, regionDesription) VALUES (@id, @desription)";
            var result = connection.Execute(insertSql,
               new { id = 103, desc = "dapper"}
                );
            var db = new DB();
            db.Insert(connection, region);
            db.Insert(connection, 0, " ");
            db.Delete(connection, 103);

            db.SelectOrder(connection, 100);



        }
    }
}
