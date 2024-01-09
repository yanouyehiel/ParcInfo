using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParcInfo.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public int totalEmploye = 0;
        private string connectionString = "Server=localhost;Database=parc_info_desktop;User ID=root;Password=;";
        public HomeViewModel() 
        {
            countEmployes();
        }
        private void countEmployes()
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) from users";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        int result = Convert.ToInt32(command.ExecuteScalar());
                        this.totalEmploye = result;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
