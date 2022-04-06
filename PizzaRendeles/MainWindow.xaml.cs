using PizzaRendeles.Forms;
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

namespace PizzaRendeles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Exit button Events
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {

            Environment.Exit(0);
        }

        private void exitBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            exitBtn.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void exitBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            exitBtn.Foreground = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Login button Events
        private void loginBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            loginBtn.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void loginBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            loginBtn.Foreground = new SolidColorBrush(Colors.White);
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameInput.Text;
            string password = userpasswordInput.Password;

            if (String.IsNullOrEmpty(username) || username.Length < 4)
            {
                usernameInput.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("The username cannot be empty\nor less then 4 character!", "Username Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            usernameInput.BorderBrush = new SolidColorBrush(Colors.White);

            if (String.IsNullOrEmpty(password) || password.Length < 8)
            {
                userpasswordInput.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("The password cannot be empty\nor less then 8 character!", "Username Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            userpasswordInput.BorderBrush = new SolidColorBrush(Colors.White);

            // Database here
            bool isValid = true;

            // Validation is correct
            if (isValid)
            {
                this.Visibility = Visibility.Hidden;

                new MainController(this).Show();
            }
        }

        #endregion

        #region Drag Events

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.GetPosition(this).Y <= 60)
                this.DragMove();
        }

        #endregion
    }
}
