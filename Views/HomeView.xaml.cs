using MySql.Data.MySqlClient;
using ParcInfo.ViewModels;
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

namespace ParcInfo.Views
{
    public partial class HomeView : UserControl
    {
        string connectionString = "Server=localhost;Database=parc_info_desktop;User ID=root;Password=;";
        public HomeView()
        {
            InitializeComponent();
            statistics();
            //displayAppareils();
        }

        private void statistics()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString)) 
            { 
                try
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM users";
                    string query1 = "SELECT COUNT(*) FROM equipements";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlCommand cmd1 = new MySqlCommand(query1, con);
                    blocEmploye.Number = ""+Convert.ToInt32(cmd.ExecuteScalar());
                    blocMateriel.Number = "" + Convert.ToInt32(cmd1.ExecuteScalar());
                    blocAssos.Number = "" + Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
