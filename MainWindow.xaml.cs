using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace ParcInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isConnected = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!txtUsername.Text.Equals("") && !txtPassword.Password.Equals(""))
            {
                isConnected = ConnectUser(txtUsername.Text, txtPassword.Password);
                if (isConnected)
                {
                    this.Hide();
                    Home2 h = new Home2();
                    h.Show();
                }
                else
                {
                    MessageBox.Show("Identifiants incorrects.");
                }
            }
            else
            {
                MessageBox.Show("Entrer vos identifiants");
            }
        }

        public void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public bool ConnectUser(string matricule, string password)
        {
            string connectionString = "Server=localhost;Database=parc_info_desktop;User ID=root;Password=;";
            bool isConnected = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE matricule = @matricule AND password = @password";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@matricule", matricule);
                        command.Parameters.AddWithValue("@password", password);

                        int result = Convert.ToInt32(command.ExecuteScalar());
                        if (result == 1)
                        {
                            isConnected = true;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Gérer l'exception de connexion ici
                    Console.WriteLine("Erreur de connexion à la base de données : " + ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }

            return isConnected;
        }
    }
}