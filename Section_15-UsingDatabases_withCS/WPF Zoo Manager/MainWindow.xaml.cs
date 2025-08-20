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

        private void ShowSelectedZooInTextBox()
        {
            try
            {
                string query = "SELECT * FROM Zoo WHERE Id = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);

                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);

                    inputText.Text = zooTable.Rows[0]["Location"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowSelectedAnimalInTextBox()
        {
            try
            {
                string query = "SELECT * FROM Animal WHERE Id = @AnimalId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@AnimalId", ListAnimals.SelectedValue);

                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);

                    inputText.Text = animalTable.Rows[0]["Name"].ToString();

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
            if (list.SelectedItem != null)
            {
                ShowAssociatedAnimals();
                ShowSelectedZooInTextBox();
            }
        }

        private void ListAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            if (list.SelectedItem != null)
            {
                ShowSelectedAnimalInTextBox();
            }
        }

        private void OnInputTextSelect(object sender, RoutedEventArgs e)
        {
            if (inputText.Text.Equals("Name of Zoo or Animal"))
                inputText.Text = string.Empty;
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

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{rowsAffected} entries were deleted.");
                    }
                    else
                    {
                        MessageBox.Show("Nothing changed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void OnAddZooButtonPress(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "INSERT INTO Zoo VALUES (@Location)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                using (sqlCommand)
                {
                    sqlCommand.Parameters.AddWithValue("@Location", inputText.Text);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{rowsAffected} entries were added.");
                    }
                    else
                    {
                        MessageBox.Show("Nothing changed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void OnAddAnimalToZooButtonPress(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "INSERT INTO ZooAnimal VALUES (@ZooId, @AnimalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                using (sqlCommand)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@AnimalId", ListAnimals.SelectedValue);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{rowsAffected} entries were added.");
                    }
                    else
                    {
                        MessageBox.Show("Nothing changed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAssociatedAnimals();
            }
        }

        private void OnRemoveAnimalToZooButtonPress(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM ZooAnimal WHERE ZooId = @ZooId AND AnimalId = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                using (sqlCommand)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@AnimalId", ListAssociatedAnimals.SelectedValue);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{rowsAffected} entries were deleted.");
                    }
                    else
                    {
                        MessageBox.Show("Nothing changed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAssociatedAnimals();
            }
        }

        private void OnDeleteAnimalButtonPress(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "DELETE FROM Animal WHERE Id = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                using (sqlCommand)
                {
                    sqlCommand.Parameters.AddWithValue("@AnimalId", ListAnimals.SelectedValue);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{rowsAffected} entries were deleted.");
                    }
                    else
                    {
                        MessageBox.Show("Nothing changed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAnimals();
            }
        }

        private void OnCreateAnimalButtonPress(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "INSERT INTO Animal VALUES (@Animal)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                using (sqlCommand)
                {
                    sqlCommand.Parameters.AddWithValue("@Animal", inputText.Text);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{rowsAffected} entries were added.");
                    }
                    else
                    {
                        MessageBox.Show("Nothing changed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAnimals();
            }
        }

        private void OnUpdateZooButtonPress(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "UPDATE Zoo SET Location = @Location WHERE Id = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                using (sqlCommand)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@Location", inputText.Text);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{rowsAffected} entries were added.");
                    }
                    else
                    {
                        MessageBox.Show("Nothing changed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void OnUpdateAnimalButtonPress(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "UPDATE Animal SET Name = @AnimalName WHERE Id = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                using (sqlCommand)
                {
                    sqlCommand.Parameters.AddWithValue("@AnimalId", ListAnimals.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@AnimalName", inputText.Text);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{rowsAffected} entries were added.");
                    }
                    else
                    {
                        MessageBox.Show("Nothing changed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAnimals();
            }
        }
    }
}
