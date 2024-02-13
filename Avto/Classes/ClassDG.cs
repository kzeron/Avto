using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows;

namespace Avto.Classes
{
    internal class ClassDG
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataGrid dg;
        DataTable dt;

        public ClassDG(DataGrid dg)
        {
            this.dg = dg;
        }
        public void LoadDB(string sqlCommand)
        {
            try 
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter(sqlCommand, sqlConnection);
                dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                dg.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
