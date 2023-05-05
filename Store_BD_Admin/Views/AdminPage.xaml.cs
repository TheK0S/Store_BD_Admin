using Store_BD_Admin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store_BD_Admin.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void back_btb_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserGrid.ItemsSource = AppData.db.Users.ToList();
            ProductGrid.ItemsSource = AppData.db.Products.ToList();
            UserGrid.CanUserAddRows = false;
            ProductGrid.CanUserAddRows = false;
            OrderGrid.CanUserAddRows = false;
        }

        private void TabControl_SelectedChanget(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems[0] == addActions)
            {
                update.Visibility = Visibility.Collapsed;
                delete.Visibility = Visibility.Collapsed;
            }
            else
            {
                update.Visibility = Visibility.Visible;
                delete.Visibility = Visibility.Visible;
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (userActions.IsSelected)
            {
                var CurrentUser = UserGrid.SelectedItem as Users;
                if (CurrentUser != null)
                {
                    AppData.db.Users.AddOrUpdate(CurrentUser);
                    AppData.db.SaveChanges();

                    UserGrid.ItemsSource = AppData.db.Users.ToList();
                    MessageBox.Show("Data is changed");
                }
                else if(productActions.IsSelected)
                {
                    var CurrentProduct = UserGrid.SelectedItem as Products;
                    AppData.db.Products.AddOrUpdate(CurrentProduct);
                    AppData.db.SaveChanges();

                    ProductGrid.ItemsSource = AppData.db.Products.ToList();
                    MessageBox.Show("Data is changed");
                }
            }
        }
    }
}
