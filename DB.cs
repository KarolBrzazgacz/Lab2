using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp1
{
    class DB
    {
        public void SelectOrder(IDbConnection connection, int id)
        {
            var sql = "SELECT * FROM Orders O JOIN [ORDER Details] ON o.OrderID = OD.OrderID WHERE O.OrderID = @id";

            var resultOrder = default(Order);


            var result = connection.Query<Order, OrderDetails, Order>(sql, (order, orderDetails) =>
            {
                resultOrder ??= order;
                if(resultOrder == null)
                {
                    resultOrder = order;
                }
                resultOrder.Details.Add(orderDetails);
                return resultOrder;
            }, 
            new { id }, splitOn: "OrderID");

        }
        public void Select(IDbConnection connection)
        {
            var sql1 = "SELECT * FROM Region";
            var regions = connection.Query(sql1);
            foreach (var item in regions)
            {
                Console.WriteLine($" {item.RegionID}: {item.RegionDescription}");
            };
        }
        public int Insert(SqlConnection connection, Region region)
        {
            var insertSql = "INSERT INTO Region(regionID, regionDescription) VALUES (@id, @desription)";
                return connection.Execute(insertSql, region);

        }
        public int Insert (SqlConnection connection, int id, string description)
        {
            var insertSql = "INSERT INTO Region(regionID, regionDescription) VALUES (@id, @desription)";
            return connection.Execute(insertSql, 
                new { id = 0, desc = ""});
        }
        public int Delete (SqlConnection connection, int id)
        {
            var sql = "DELETE FROM Region WHERE regionID = @id";
            return connection.Execute(sql, id);
        }
    }
}
