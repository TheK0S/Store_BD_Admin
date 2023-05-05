using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Store_BD_Admin.Model
{
    internal class AppData
    {
        public static StoreDBEntities db = new StoreDBEntities();
        public static string connectionStrring = @"Data Source=DESKTOP-K60TA32\SQLEXPRESS; Initial Catalog=StoreDB;Integrated Security=True; Encrypt=False";
        public static Users currentUser;

        public static async Task AddUser(string login, string password, string rolesId)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionStrring))
                {
                    await db.ExecuteAsync($"INSERT INTO Users (Login, Password, RolesId) VALUES ('{login}', '{password}', {rolesId})");
                }
                MessageBox.Show("User is added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"User is not added",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static List<OrderSplit> GetOrders()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionStrring))
                {
                    string sqlCommand = @"SELECT Orders.Id, Orders.OrderPrice, Orders.OrderDate, Clients.FirstName+' '+Clients.LastName AS ClientName,
                                                 Products.Name AS ProductName, OrderLists.Amount, Orders.IsOrderComplited
                          FROM Orders, OrderLists, Clients, Products
                          WHERE OrderLists.OrderId = Orders.Id AND Clients.Id = Orders.ClientId AND Products.Id = OrderLists.ProductID";
                    return db.Query<OrderSplit>(sqlCommand).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Orders load exception", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public static void AddClient(string login, string password, string firstName, string lastName, string age)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionStrring))
                {
                    db.Execute($"INSERT INTO Clients VALUES ('{login}', '{password}', '{firstName}', '{lastName}', {age})");
                    MessageBox.Show("Client is added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void AddProduct(string name, string price, string description, string type)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionStrring))
                {
                    db.Execute($"INSERT INTO Products VALUES ('{name}', {price}, '{description}', {type})");
                    MessageBox.Show("Product is added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
