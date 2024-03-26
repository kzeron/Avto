﻿using Avto.AdoBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Avto.Win
{
    /// <summary>
    /// Логика взаимодействия для AddUserWin.xaml
    /// </summary>
    public partial class AddUserWin : Window
    {
        public AddUserWin()
        {
            InitializeComponent();
        }
        public static string IdRole { get; set; }
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        Classes.ClassCB classCB;

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new WinLists.WinListUsers().Show();
            Close();
        }

        private void CbRole_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadRole(CbRole);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                TbLogin.Focus();
            }
            else if (string.IsNullOrEmpty(TbPassword.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                TbPassword.Focus();
            }
            else if (CbRole.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Выберете роль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                CbRole.Focus();
            }
            else
            {
                IdRole = CbRole.SelectedValue.ToString();
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.[User] " +
                        "(Login, Password, IdRole) " +
                        "Values " +
                        "(@Login, " +
                        "@Password, " +
                        "@IdRole)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("Login", TbLogin.Text);
                    sqlCommand.Parameters.AddWithValue("Password", TbPassword.Text);
                    sqlCommand.Parameters.AddWithValue("IdRole", IdRole);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Добавление пользователя прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
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
    }
}
