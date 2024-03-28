using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Avto.Classes
{
    internal class ClassCB
    {
        SqlConnection sqlConnection =
             new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter;
        DataSet dataSet;

        public void LoadRole(ComboBox cbRole)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT Idrole, " +
                    "NameRole FROM dbo.[Role] Order by IdRole ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Role]");
                cbRole.ItemsSource = dataSet.Tables["[Role]"].DefaultView;
                cbRole.DisplayMemberPath = dataSet.Tables["[Role]"].Columns["NameRole"].ToString();
                cbRole.SelectedValue = dataSet.Tables["[Role]"].Columns["NameRole"].ToString();
            }
            catch (Exception ex) 
            {
                ClassMessageBoxErrors.ShowSomesingWrong(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
