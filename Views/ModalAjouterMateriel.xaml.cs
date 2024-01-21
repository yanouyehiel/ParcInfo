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
            loadTypeEquipements();
        }

        private void loadTypeEquipements()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM type_equipements";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                string nom = reader.GetString("intitule");
                types_materiel.Items.Add(nom);
            }

            reader.Close();
            connection.Close();
        }

        public string GenererNumSerie()
        {
            const string caracteresPermis = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder matricule = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 9; i++)
            {
                int index = random.Next(caracteresPermis.Length);
                matricule.Append(caracteresPermis[index]);
            }

            return matricule.ToString();
        }

        private void addMateriel_Click(object sender, RoutedEventArgs e)
        {
            if (!nom.Text.Equals("") && !marque.Text.Equals("") && !fabriquant.Text.Equals("") && !fournisseur.Text.Equals("") && types_materiel.SelectedItem != null && status.SelectedItem != null)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO equipements (numSerie, type_equipement, nom, marque, fabriquant, fournisseur, date_service, date_hors_service, status)" +
                        "VALUES (@num, @type, @nom, @mar, @fab, @four, @date_service, @date_hors, @stat)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        ComboBoxItem selectedItemStatus = (ComboBoxItem)status.SelectedItem;
                        string statusSelected = selectedItemStatus.Content.ToString();

                        cmd.Parameters.AddWithValue("@num", GenererNumSerie());
                        cmd.Parameters.AddWithValue("@type", types_materiel.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@nom", nom.Text);
                        cmd.Parameters.AddWithValue("@mar", marque.Text);
                        cmd.Parameters.AddWithValue("@fab", fabriquant.Text);
                        cmd.Parameters.AddWithValue("@four", fournisseur.Text);
                        cmd.Parameters.AddWithValue("@date_service", date_Service.SelectedDate.ToString());
                        cmd.Parameters.AddWithValue("@date_hors", date_fin.SelectedDate.ToString());
                        cmd.Parameters.AddWithValue("@stat", statusSelected);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Matériel ajouté !");
                        Close();
                    }
                }
            } 
            else 
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }
    }
}
