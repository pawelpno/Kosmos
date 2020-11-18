using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
using MySql.Data.MySqlClient;

namespace Kosmos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            logowanie log = new logowanie();
            Main.NavigationService.Navigate(log);

        }

       

        


    }
}











/*MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
string zapytanie = "select * from zaklad.danelogowania";
MySqlDataAdapter adapter = new MySqlDataAdapter();
adapter.SelectCommand = new MySqlCommand(zapytanie, connection);
MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);


connection.Open();
DataTable dane = new DataTable();
adapter.Fill(dane);
dataGridView1.ItemsSource = dane.DefaultView;
adapter.Update(dane);
connection.Close();*/