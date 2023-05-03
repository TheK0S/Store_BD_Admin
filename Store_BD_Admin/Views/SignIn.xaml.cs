using Store_BD_Admin.Model;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void signIn_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = AppData.db.Users.FirstOrDefault(u => u.Login == login.Text && u.Password == password.Text);
            if(currentUser != null)
            {
                if(currentUser.RolesId == 1)
                {

                }
                else if(currentUser.RolesId == 2)
                {

                }
            }
            else
            {
                MessageBox.Show("Нет пользователей с указанными данными");
            }
        }

        private void signUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUp());
        }
    }
}
