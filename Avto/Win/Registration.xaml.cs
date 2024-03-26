using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data.Sql;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Avto.Win
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public static string IdRole {  get; set; }
        SqlConnection _sqlconnection = 
            new SqlConnection(App.ConnectionString());
        SqlCommand _sqlCommand;
        public Registration()
        {
            InitializeComponent();
        }

        private void BackAuth_MouseLeftButtonDown
            (object sender, MouseButtonEventArgs e)
        {
            MainWindow auth = new MainWindow();
            auth.Show();
            Close();
        }

        private void Registratioon_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(LoginTb.Text))
            {
                Classes.ClassMessageBoxErrors
                    .ShowEmptyFieldError("Логин");
            }
            else if(string.IsNullOrEmpty(PasswordTb.Password))
            {
                Classes.ClassMessageBoxErrors
                    .ShowEmptyFieldError ("Пароль");
            }
            else if(PasswordTb.Password != RepeatPasswordTb.Password)
            {
                Classes.ClassMessageBoxErrors
                    .ShowEmptyFieldNotSwap();
            }
            else
            {
                try
                {
                    _sqlconnection.Open();
                    _sqlCommand = new SqlCommand("INSERT INTO dbo.[User] " +
                        "(LoginUser, " +
                        "PasswordUser, " +
                        "IdRole, " +
                        "IdBalance, " +
                        "IdTariff, IdServices) " +
                        "Values " +
                        "(@LoginUser, " +
                        "@PasswordUser, " +
                        "@IdRole, " +
                        "@IdBalance, " +
                        "@IdTariff, " +
                        "@IdServices)", _sqlconnection);
                    _sqlCommand.Parameters.AddWithValue("LoginUser", LoginTb.Text);
                    _sqlCommand.Parameters.AddWithValue ("PasswordUser", PasswordTb.Password);
                    _sqlCommand.Parameters.AddWithValue("IdRole", 1);
                    _sqlCommand.Parameters.AddWithValue("IdBalance", 1);
                    _sqlCommand.Parameters.AddWithValue("IdTariff", 1);
                    _sqlCommand.Parameters.AddWithValue("IdServices", 1);
                    _sqlCommand.ExecuteNonQuery();
                    Classes.ClassMessageBoxErrors.AddSqlList();
                }
                catch(Exception ex)
                {
                    Classes.ClassMessageBoxErrors
                        .ShowSomesingWrong(ex);
                }
                finally
                {
                    _sqlconnection.Close();
                };
            }
        }
    }
}
