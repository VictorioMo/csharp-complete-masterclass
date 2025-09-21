using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;


namespace CurrencyConverter_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Root ExchangeRoot { get; set; }
        public string AppId { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            GetAppId();
            GetValue();
        }

        public void GetAppId()
        {
            AppId = String.Empty;

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apikey.secret");

            if (File.Exists(path))
            {
                AppId = File.ReadAllText(path).Trim();
                MessageBox.Show("API key found!.",
                    "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("API key not found - make sure you have it in apikey.secret file.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                throw new Exception();
            }
            
        }

        private async void GetValue()
        {
            string url = "https://openexchangerates.org/api/latest.json?app_id=";
            string full_url = url + AppId;
            ExchangeRoot = await GetData<Root>(full_url);
            BindCurrency();
        }

        public static async Task<Root> GetData<T>(string url)
        {
            var exchangeRoot = new Root();

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        exchangeRoot = JsonConvert.DeserializeObject<Root>(responseString);

                        MessageBox.Show($"Timestamp: {exchangeRoot.Timestamp}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            return exchangeRoot;
        }

        #region Bind Currency and ComboBox
        private void BindCurrency()
        {
            DataTable dtCurrency = new DataTable();
            dtCurrency.Columns.Add("Text");
            dtCurrency.Columns.Add("Value");

            dtCurrency.Rows.Add("--SELECT--", 0);
            try
            {
                dtCurrency.Rows.Add("INR", ExchangeRoot.Rates.INR);
                dtCurrency.Rows.Add("USD", ExchangeRoot.Rates.USD);
                dtCurrency.Rows.Add("EUR", ExchangeRoot.Rates.EUR);
                dtCurrency.Rows.Add("SAR", ExchangeRoot.Rates.SAR);
                dtCurrency.Rows.Add("RON", ExchangeRoot.Rates.RON);
                dtCurrency.Rows.Add("MDL", ExchangeRoot.Rates.MDL);
                dtCurrency.Rows.Add("RUB", ExchangeRoot.Rates.RUB);
                dtCurrency.Rows.Add("GBP", ExchangeRoot.Rates.GBP);
                dtCurrency.Rows.Add("CNY", ExchangeRoot.Rates.CNY);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            // Create the variable as ConvertedValue with double datatype to store currency converted value
            double ConvertedValue;

            // Check if the amount textbox is Null or Blank
            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                // If amount textbox is Null or Blank it will show this message box
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                // After clicking on messagebox OK set focus on amount textbox
                txtCurrency.Focus();
                return;
            }
            // Else if currency From is not selected or select default text --SELECT--
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                // Show the message
                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                // Set focus on the From Combobox
                cmbFromCurrency.Focus();
                return;
            }
            // Else if currency To is not selected or select default text --SELECT--
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                //Show the message
                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //Set focus on the To Combobox
                cmbToCurrency.Focus();
                return;
            }

            // Check if From and To Combobox selected values are same
            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                // Amount textbox value set in ConvertedValue.
                // double.parse is used for converting the datatype String To Double.
                // Textbox text have string and ConvertedValue is double Datatype
                ConvertedValue = double.Parse(txtCurrency.Text);

                //Show the label converted currency and converted currency name and ToString("N3") is used to place 000 after the dot(.)
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
            else
            {
                //Calculation for currency converter is From Currency value multiply(*) 
                //With the amount textbox value and then that total divided(/) with To Currency value
                ConvertedValue = (double.Parse(cmbToCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / 
                                    double.Parse(cmbFromCurrency.SelectedValue.ToString());

                //Show the label converted currency and converted currency name.
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
        }
        

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtCurrency.Text = string.Empty;

            if (cmbFromCurrency.Items.Count > 0)
                cmbFromCurrency.SelectedIndex = 0;
            if (cmbToCurrency.Items.Count > 0)
                cmbToCurrency.SelectedIndex = 0;

            lblCurrency.Content = string.Empty;
            txtCurrency.Focus();
        }

        private void TextInputCheckNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+"); // Searches for any characters except numbers
            e.Handled = regex.IsMatch(e.Text);  // Will mark the event handled as true if other characters except numbers are found
        }

        private void txtCurrency_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        #endregion
    }
}
