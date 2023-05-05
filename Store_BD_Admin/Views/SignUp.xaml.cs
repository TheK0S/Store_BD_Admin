using Store_BD_Admin.Model;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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
            if(login.Text != null && password.Text != null && firstName.Text != null && lastName.Text != null && age.Text != null)
            {
                AppData.AddClient(login.Text, password.Text, firstName.Text, lastName.Text, age.Text);
            }
        }
    }
}
