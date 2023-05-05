       using Store_BD_Admin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            rolesId.ItemsSource = new string[] { "1", "2" };
        }

        private void back_btb_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserGrid.ItemsSource = AppData.db.Users.ToList();
            ProductGrid.ItemsSource = AppData.db.Products.ToList();
            OrderGrid.ItemsSource = AppData.GetOrders();

            UserGrid.CanUserAddRows = false;
            ProductGrid.CanUserAddRows = false;
            OrderGrid.CanUserAddRows = false;
        }

        private void TabControl_SelectedChanget(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems[0] == addActions || e.AddedItems[0] == orderActions)
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
                try
                {
                    var CurrentUser = UserGrid.SelectedItem as Users;

                    if (CurrentUser != null)
                    {
                        AppData.db.Users.AddOrUpdate(CurrentUser);
                        AppData.db.SaveChanges();

                        UserGrid.ItemsSource = AppData.db.Users.ToList();
                        MessageBox.Show("Data is changed");
                    }
                    else
                    {
                        MessageBox.Show("Не найден выбранный пользователь", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else if (productActions.IsSelected)
            {
                try
                {
                    var CurrentProduct = ProductGrid.SelectedItem as Products;
                    if (CurrentProduct != null)
                    {
                        AppData.db.Products.AddOrUpdate(CurrentProduct);
                        AppData.db.SaveChanges();

                        ProductGrid.ItemsSource = AppData.db.Products.ToList();
                        MessageBox.Show("Data is changed");
                    }
                    else
                    {
                        MessageBox.Show("Не найден выбранный продукт", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }            
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (userActions.IsSelected)
            {
                try
                {
                    var CurrentUser = UserGrid.SelectedItem as Users;

                    if (CurrentUser != null)
                    {
                        AppData.db.Users.Remove(CurrentUser);
                        AppData.db.SaveChanges();

                        UserGrid.ItemsSource = AppData.db.Users.ToList();
                        MessageBox.Show("User is deleted");
                    }
                    else
                    {
                        MessageBox.Show("Не найден выбранный пользователь", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else if (productActions.IsSelected)
            {
                try
                {
                    var CurrentProduct = ProductGrid.SelectedItem as Products;
                    if (CurrentProduct != null)
                    {
                        AppData.db.Products.Remove(CurrentProduct);
                        AppData.db.SaveChanges();

                        ProductGrid.ItemsSource = AppData.db.Products.ToList();
                        MessageBox.Show("Product is deleted");
                    }
                    else
                    {
                        MessageBox.Show("Не найден выбранный продукт", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void age_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(age.Text, @"^[0-9]+$"))
            {
                age.Text = "";
                MessageBox.Show("Поле \"Age\" принимает только цифры", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text != null && password.Text != null && firstName.Text != null && lastName.Text != null && age.Text != null)
            {
                AppData.AddClient(login.Text, password.Text, firstName.Text, lastName.Text, age.Text);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (loginUser.Text != null && passwordUser.Text != null && rolesId.SelectedItem != null)
            {
                AppData.AddUser(loginUser.Text, passwordUser.Text, rolesId.SelectedItem.ToString());
                UserGrid.ItemsSource = AppData.db.Users.ToList();
            }
        }

        private void add_product_btn_Click(object sender, RoutedEventArgs e)
        {
            if(productName.Text != null && productPrice.Text != null && productDescription.Text != null && productType.Text != null)
            {
                AppData.AddProduct(productName.Text, productPrice.Text, productDescription.Text, productType.Text);
                ProductGrid.ItemsSource= AppData.db.Products.ToList();
            }
        }

        private void productType_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(age.Text, @"^[0-9]+$"))
            {
                age.Text = "";
                MessageBox.Show("Поле \"Product type\" принимает только цифры", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void productPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(age.Text, @"^[0-9].+$"))
            {
                age.Text = "";
                MessageBox.Show("Поле \"Product type\" принимает только цифры", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
