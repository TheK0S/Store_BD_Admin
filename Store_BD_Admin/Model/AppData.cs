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
        public static string connectionStrring = @"Data Source=DESKTOP-HHO6PH0; Initial Catalog=AdminPanel;Integrated Security=True; Encrypt=False";
        public static Users currentUser;

        public static async Task Add(Users user)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionStrring))
                {
                    await db.ExecuteAsync("INSERT INTO Users (Login, Password, RolesId) VALUES (@Login, @Password, @RolesId)", user);
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
                    return db.Query<OrderSplit>("SELECT ").ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Orders load exception", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
