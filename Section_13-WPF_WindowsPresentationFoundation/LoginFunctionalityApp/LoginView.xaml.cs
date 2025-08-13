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

namespace LoginFunctionalityApp
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            string enteredPassword = PasswordBox.Password;

            string? envPw = Environment.GetEnvironmentVariable("TEST_LOGIN_APP_PASSWORD");

            if (envPw != null)
            {
                if (enteredPassword == envPw)
                {
                    MessageBox.Show("Entered correct password.");
                }
                else
                {
                    MessageBox.Show("Entered wrong password.");
                }
            }
            else
            {
                MessageBox.Show("Environment variable not found.");
            }
        }

        private void OnPasswordChange(object sender, RoutedEventArgs e)
        {
            LoginButton.IsEnabled = !string.IsNullOrEmpty(PasswordBox.Password);
        }
    }
}
