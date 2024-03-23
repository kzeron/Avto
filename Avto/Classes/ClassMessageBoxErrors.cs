using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace Avto.Classes
{
    internal class ClassMessageBoxErrors
    {
        public void ShowEmptyFieldError(string fieldName)
        {
            MessageBox.Show($"Введите {fieldName}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowAuthorizationError()
        {
            MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
