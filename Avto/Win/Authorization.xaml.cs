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
using System.Data.Common;

namespace Avto
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Classes.ClassMessageBoxErrors errorsInfo;
        SqlConnection sqlConnection =
              new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string NameRole { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text))
            {
                errorsInfo.ShowEmptyFieldError("логин");
            }
            else if (string.IsNullOrEmpty(PasswordTb.Password))
            {
                errorsInfo.ShowEmptyFieldError("Пароль");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("SELECT PasswordUser, NameRole FROM dbo.ViewUser " +
                    $"WHERE [LoginUser]='{LoginTb.Text}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    if (dataReader[0].ToString() != PasswordTb.Password)
                    {
                        MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        PasswordTb.Focus();
                    }
                    else
                    {
                        Login = LoginTb.Text;
                        Password = PasswordTb.Password;
                        NameRole = dataReader[1].ToString();

                        switch (NameRole)
                        {
                            case "Administrator":
                                AdminWin adminWin = new AdminWin();
                                adminWin.Show();
                                Close();
                                break;
                            case "Manager":
                                AdminWin managerWin = new AdminWin();
                                managerWin.Show();
                                Close();
                                break;
                            case "User":
                                MainWin mainWin = new MainWin();
                                mainWin.Show();
                                Close();
                                break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
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
