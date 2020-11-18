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
    /// Logika interakcji dla klasy logowanie.xaml
    /// </summary>
    public partial class logowanie : Page
    {
        public logowanie()
        {
            InitializeComponent();
        }

        public string nazwaKonta;
        public string notatka;
        public string idString;



        private void loginButton(object sender, RoutedEventArgs e)
        {


            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            string zapytanie = "SELECT `id`,`login`,`haslo`,`notatka` FROM zaklad.danelogowania";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader myReader = komenda.ExecuteReader();

            string komunikat = string.Empty;
            string nazwaKonta = string.Empty;

            while (myReader.Read())
            {
                int o = 0;
                int i = 1;
                int z = 2;
                int x = 3;
                string loginAdmin = myReader.GetString(i);
                string hasloAdmin = myReader.GetString(z);
                if (loginAdmin == loginImput.Text && hasloAdmin == hasloImput.Password.ToString())
                {
                    komunikat = "Zalogowano pomyślnie!";
                    nazwaKonta = loginAdmin;
                    notatka = myReader.GetString(x);
                    idString = myReader.GetString(o);
                }
                o += 3;
                i += 3;
                z += 3;
                x += 3;
            }

            
            myReader.Close();
            if (komunikat != string.Empty)
            {
                MessageBox.Show("Zalogowano pomyślnie");
                connection.Close();
                Window1 win = new Window1();
                win.Show();
                win.witaj.Content = "Witaj " + nazwaKonta;
                win.text = notatka;
                win.id = idString;

            }
            else if (komunikat == string.Empty)
            {
                MessageBox.Show("Błędne dane");
                connection.Close();
            }



        }
        


        private void rejestracjaButton(object sender, RoutedEventArgs e)
        {
            rejestracja reg = new rejestracja();
           
            this.NavigationService.Navigate(reg);
            
        }

    }
}
