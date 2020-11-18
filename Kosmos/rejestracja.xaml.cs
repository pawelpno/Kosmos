using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logika interakcji dla klasy rejestracja.xaml
    /// </summary>
    public partial class rejestracja : Page
    {
        public rejestracja()
        {
            InitializeComponent();
        }
        
        private void loginButton(object sender, RoutedEventArgs e)
        {
            logowanie log = new logowanie();

            this.NavigationService.Navigate(log);
            
        }



        private void rejestracjaButton(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            if (string.IsNullOrEmpty(loginImput.Text) || string.IsNullOrEmpty(hasloImput.Password.ToString()))
            {
                MessageBox.Show("Błędne dane nowego konta!");
                connection.Close();
            }
            else if(hasloImput.Password.ToString() != hasloImput2.Password.ToString())
            {
                MessageBox.Show("Podane hasła się różnią!");
                connection.Close();
            }
            else
            {
                potwierdzenie pot = new potwierdzenie();
                pot.info.Content = "Czy na pewno chcesz założyć konto " + Environment.NewLine + loginImput.Text + "?";
                pot.ShowDialog();
                if (pot.sprawdzenie == 1)
                {
                    string zapytanie = "INSERT INTO zaklad.danelogowania (`login`, `haslo`) VALUES('" + loginImput.Text.ToString() + "','" + hasloImput.Password.ToString() + "')";
                    MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                    komenda.ExecuteNonQuery();
                    MessageBox.Show("Konto " + loginImput.Text + " założone pomyślnie");
                    connection.Close();

                }
                else if (pot.sprawdzenie == 2)
                {
                    MessageBox.Show("Brak zgody na założenie konta To nieźle");

                }

            }

        }

    }
}
