using MySql.Data.MySqlClient;
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

namespace ParcInfo.Views
{
    
    public partial class ModalAjouterMateriel : Window
    {
        string connectionString = "Server=localhost;Database=parc_info_desktop;User ID=root;Password=;";
        public ModalAjouterMateriel()
        {
            InitializeComponent();
        }

        private void addMateriel_Click(object sender, RoutedEventArgs e)
        {
            if (!nom.Text.Equals("") && !marque.Text.Equals("") && !fabriquant.Text.Equals("") && !fournisseur.Text.Equals(""))
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO equipements (nom, marque, fabriquant, fournisseur, date_mise_en_service, date_hors_service, status)" +
                        "VALUES (@nom, @mar, @fab, @four, @date_service, @date_hors, @stat)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nom", nom.Text);
                        cmd.Parameters.AddWithValue("@mar", marque.Text);
                        cmd.Parameters.AddWithValue("@fab", fabriquant.Text);
                        cmd.Parameters.AddWithValue("@four", fournisseur.Text);
                        cmd.Parameters.AddWithValue("@date_service", date_Service.SelectedDate);
                        cmd.Parameters.AddWithValue("@date_hors", date_fin.SelectedDate);
                        cmd.Parameters.AddWithValue("@stat", status.SelectedValue);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Matériel ajouté !");
                        Hide();
                    }
                }
            } else 
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }
    }
}
