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
using System.Data.SqlClient;

namespace Avto.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        Classes.ClassDG classDG;
        public UserList()
        {
            InitializeComponent();
            classDG = new Classes.ClassDG(DgListUsers);
        }

        private void DgListUsers_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("SELECT * FROM dbo.ViewUser");
        }
    }
}
