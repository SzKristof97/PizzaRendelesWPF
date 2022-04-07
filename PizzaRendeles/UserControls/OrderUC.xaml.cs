using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace PizzaRendeles.UserControls
{
    /// <summary>
    /// Interaction logic for OrderUC.xaml
    /// </summary>
    public partial class OrderUC : UserControl
    {
        public OrderUC()
        {
            InitializeComponent();
        }

        private void Display()
        {
            Database.Database.DisplayAndSearch("SELECT ID,PizzaName,CustomerName,OrderDate,Finished,AdminID FROM `orders`", dataGrid);
        }

        private void LoadDb()
        {
            Debug.WriteLine("Displaying orders");
            Display();
        }

        private void dataGrid_Initialized(object sender, EventArgs e)
        {
            LoadDb();
        }
    }
}
