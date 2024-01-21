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
    public partial class ModalAjouterPersonnel : Window
    {
        string connectionString = "Server=localhost;Database=parc_info_desktop;User ID=root;Password=;";
        public ModalAjouterPersonnel()
        {
            InitializeComponent();
            loadEquipements();
        }

        public string GenererMatricule()
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

        private void addPersonnel_Click(object sender, RoutedEventArgs e)
        {
            if (!nom.Text.Equals("") && !password.Text.Equals("") && !tel.Text.Equals("") && !email.Text.Equals("") && postes.SelectedItem != null && equipements.SelectedItem != null)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO users (Noms, Matricule, password, Email, Telephone, Poste, Equipement, Date_Embauche)" +
                        "VALUES (@nom, @mat, @pass, @email, @tel, @poste, @equip, @date)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        ComboBoxItem selectedItem = (ComboBoxItem)postes.SelectedItem;
                        string posteSelected = selectedItem.Content.ToString();

                        cmd.Parameters.AddWithValue("@nom", nom.Text);
                        cmd.Parameters.AddWithValue("@mat", GenererMatricule());
                        cmd.Parameters.AddWithValue("@pass", password.Text);
                        cmd.Parameters.AddWithValue("@email", email.Text);
                        cmd.Parameters.AddWithValue("@tel", tel.Text);
                        cmd.Parameters.AddWithValue("@poste", posteSelected);
                        cmd.Parameters.AddWithValue("@equip", equipements.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@date", date_embauche.SelectedDate.ToString());

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Personnel créé !");
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }

        private void loadEquipements()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM equipements";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                string nom = reader.GetString("nom");
                equipements.Items.Add(nom);
            }

            reader.Close();
            connection.Close();
        }
    }
}
