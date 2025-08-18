using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Data.SqlClient;
using System.Data;

namespace WPF_Zoo_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            // Auto-generated
            InitializeComponent();

            // Dev code init
            SqlConnInit();
            ShowZoos();
            ShowAnimals();
        }

        private void SqlConnInit()
        {
            string baseConnectionString = ConfigurationManager.ConnectionStrings["WPF_Zoo_Manager.Properties.Settings.CSharpMasterClassConnectionString"].ConnectionString;
            string connectionPassword = Environment.GetEnvironmentVariable("TEST_LOGIN_APP_PASSWORD");

            var connectionStringBuilder = new SqlConnectionStringBuilder(baseConnectionString)
            {
                Password = connectionPassword
            };

            string fullConnectionString = connectionStringBuilder.ToString();

            sqlConnection = new SqlConnection(fullConnectionString);
        }

        private void ShowZoos()
        {
            try
            {
                string query = "SELECT * FROM Zoo";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);

                    ListZoos.DisplayMemberPath = "Location";
                    ListZoos.SelectedValuePath = "Id";
                    ListZoos.ItemsSource = zooTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ShowAnimals()
        {
            try
            {
                string query = "SELECT * FROM Animal";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);

                    ListAnimals.DisplayMemberPath = "Name";
                    ListAnimals.SelectedValuePath = "Id";
                    ListAnimals.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowAssociatedAnimals()
        {
            try
            {
                string query = "SELECT * FROM Animal a INNER JOIN ZooAnimal za ON a.Id = za.AnimalId WHERE za.ZooId = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);

                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);

                    ListAssociatedAnimals.DisplayMemberPath = "Name";
                    ListAssociatedAnimals.SelectedValuePath = "Id";
                    ListAssociatedAnimals.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ListZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            if (list.SelectedItem != null) ShowAssociatedAnimals();
        }

        private void OnDeleteZooButtonPress(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM Zoo WHERE Id = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                using (sqlCommand)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{rowsAffected} entries were deleted.");
                    }
                    else
                    {
                        MessageBox.Show("Nothing changed.");
                    }
                }
                //ListZoos.UnselectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                ShowZoos();
            }
        }
    }
}
