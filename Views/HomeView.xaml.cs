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
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private List<MaterielViewModel> displayAppareils()
        {
            List<MaterielViewModel> appareils = new List<MaterielViewModel>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT nom, date_mise_en_service FROM equipements ORDER BY date_mise_en_service DESC LIMIT 3";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // Récupérer les données de chaque appareil et les stocker dans un objet Appareil
                        string nomAppareil = reader.GetString(1);
                        string dateService = reader.GetString(5);

                        MaterielViewModel appareil = new MaterielViewModel
                        {
                            Nom = nomAppareil,
                            DateMiseService = dateService
                        };

                        appareils.Add(appareil);
                    }

                    reader.Close();

                    //recentsSave.ItemsSource = appareils;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return appareils;
        }
    }
}
