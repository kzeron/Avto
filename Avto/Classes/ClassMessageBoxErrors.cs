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
        public static void ShowEmptyFieldError(string fieldName)
        {
            MessageBox.Show($"Введите {fieldName}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void ShowEmptyFieldNotSwap()
        {
            MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowAuthorizationError()
        {
            MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void ShowSomesingWrong(Exception ex)
        {
            MessageBox.Show( ex.Message, "Уп-с, что-то пошло не так", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void AddSqlList()
        {
            MessageBox.Show("Добавление пользователя прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
