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

namespace Avto.Win
{
    /// <summary>
    /// Логика взаимодействия для ResetPassowordWin.xaml
    /// </summary>
    public partial class ResetPassowordWin : Window
    {
        public ResetPassowordWin()
        {
            InitializeComponent();
        }

        private void BackAuth_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow auth = new MainWindow();
            auth.Show();
            Close();
        }

        private void ResetBt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
