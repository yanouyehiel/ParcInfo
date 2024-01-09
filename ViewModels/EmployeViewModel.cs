using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ParcInfo.ViewModels
{
    public class EmployeViewModel : ViewModelBase
    {
        private string connectionString = "Server=localhost;Database=parc_info_desktop;User ID=root;Password=;";
        public EmployeViewModel() 
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * from users";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        var dt = new DataTable();
                        var dataAdapter = new MySqlDataAdapter(command);
                        var dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);
                        var employesCollection = new ObservableCollection<EmployeModel>();

                        foreach (DataRow dr in dataSet.Tables[0].Rows)
                        {
                            employesCollection.Add(new EmployeModel
                            {
                                Noms = dr["noms"].ToString(),
                                Matricule = dr["matricule"].ToString(),
                                Telephone = dr["telephone"].ToString(),
                                Poste = dr["poste"].ToString(),
                                Email = dr["email"].ToString(),
                                DateEmbauche = dr["date_embauche"].ToString()
                            });
                        }
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
