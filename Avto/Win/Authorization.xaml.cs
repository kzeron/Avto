using Avto.Win;
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
using System.Data;
using System.Data.SqlClient;

namespace Avto
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand command;
        SqlDataReader reader;

        public static string Login {  get; set; }
        public static string Password { get; set; }
        public static string NameRole { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            MainWin main = new MainWin();
            main.Show();
            this.Close();
        }

        private void ResetPassowrdText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new ResetPassowordWin().Show();
            Close();
        }

        private void RegistrationText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
