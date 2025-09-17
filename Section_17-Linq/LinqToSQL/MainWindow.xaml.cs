using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        LinqToSQLDataClassesDataContext DataContext;

        public MainWindow()
        {
            InitializeComponent();

            SqlConnInit();
            DataContext = new LinqToSQLDataClassesDataContext(sqlConnection);

            InsertUniversities();
        }

        private void SqlConnInit()
        {
            string baseConnectionString = ConfigurationManager.ConnectionStrings["LinqToSql.Properties.Settings.CSharpMasterClassConnectionString"].ConnectionString;
            string connectionPassword = Environment.GetEnvironmentVariable("TEST_LOGIN_APP_PASSWORD");

            var connectionStringBuilder = new SqlConnectionStringBuilder(baseConnectionString)
            {
                Password = connectionPassword
            };

            string fullConnectionString = connectionStringBuilder.ToString();

            sqlConnection = new SqlConnection(fullConnectionString);
        }

        public void InsertUniversities()
        {
            DataContext.ExecuteCommand("DELETE FROM University");

            University yale = new University();
            yale.Name = "Yale";
            DataContext.Universities.InsertOnSubmit(yale);

            University beijingTech = new University();
            beijingTech.Name = "Beijing Tech";
            DataContext.Universities.InsertOnSubmit(beijingTech);

            DataContext.SubmitChanges();

            MainDataGrid.ItemsSource = DataContext.Universities;
        }

        public void InsertStudent()
        {
            University yale = DataContext.Universities.First(un => un.Name.Equals("Yale"));
            University beijingTech = DataContext.Universities.First(un => un.Name.Equals("Beijing Tech"));
        }
    }
}
