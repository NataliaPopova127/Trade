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
using System.Windows.Shapes;
using TradeClientApp.ViewModel;

namespace TradeClientApp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            this.DataContext = new AuthorizationViewModel();
        }

        private async void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AuthorizationViewModel).Password = password.Password;
           

            if (await (DataContext as AuthorizationViewModel).ValidateUserLoginAndPassword())
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
