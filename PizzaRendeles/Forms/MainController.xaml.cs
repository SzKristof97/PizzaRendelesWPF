using PizzaRendeles.UserControls;
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

namespace PizzaRendeles.Forms
{
    /// <summary>
    /// Interaction logic for MainController.xaml
    /// </summary>
    public partial class MainController : Window
    {
        private MainWindow Core;
        private string ucContent;

        public string UCContent {
            get
            {
                return ucContent;
            }
            set
            {
                ucContent = value;
                OnContentChanged(value);
            }
        }

        public MainController(MainWindow core)
        {
            this.Core = core;
            InitializeComponent();
        }

        #region exit button Events

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Core.Visibility = Visibility.Visible;
            this.Close();
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

        #region Mouse Enter / Leave

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e == null || e.Source == null) return;

            Button button = (Button)e.Source;
            if (button == null) return;

            button.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e == null || e.Source == null) return;

            Button button = (Button)e.Source;
            if (button == null) return;

            button.Foreground = new SolidColorBrush(Colors.White);
        }

        #endregion

        #region Content Change Events

        private void OnContentChanged(string value)
        {
            switch (value)
            {
                case "orders": { contentManager.Content = new OrderUC(); break; }
                case "users": { contentManager.Content = new UsersUC(); break; }
                default: { break; }
            }
        }

        #endregion

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            UCContent = "orders";
        }

        private void usersBtn_Click(object sender, RoutedEventArgs e)
        {
            UCContent = "users";
        }
    }
}
