using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ParcInfo.Views
{
    
    public partial class MaterielView : UserControl
    {
        string connectionString = "Server=localhost;Database=parc_info_desktop;User ID=root;Password=;";
        public MaterielView()
        {
            InitializeComponent();
            loadMateriel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModalAjouterMateriel m = new ModalAjouterMateriel();
            m.Show();
        }

        private void loadMateriel()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM equipements";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGrid.AutoGenerateColumns = false;

                    foreach (DataColumn column in dt.Columns)
                    {
                        DataGridTextColumn gridColumn = new DataGridTextColumn();
                        gridColumn.Header = column.ColumnName;
                        gridColumn.Binding = new Binding(column.ColumnName);
                        dataGrid.Columns.Add(gridColumn);
                    }

                    dataGrid.ItemsSource = dt.DefaultView;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            loadMateriel();
        }
    }
}
