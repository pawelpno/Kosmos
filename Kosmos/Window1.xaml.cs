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
using System.Media;

namespace Kosmos
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"C:\Users\Pawel\Desktop\deathnote.wav";
            player.Play();


        }
        public string text;
        private void wejdzs(object sender, RoutedEventArgs e)
        {
           
            
            wejdz.Visibility = Visibility.Hidden;
            notatnik.Visibility = Visibility.Visible;
            saveButton.Visibility = Visibility.Visible;
            exitButton.Visibility = Visibility.Visible;
            notatnik.Text = text;
        }

        bool dzwiek;
        private void dzwieks(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            if (dzwiek == false)
            {
                player.Stop();
                obraz.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"C:\Users\Pawel\Desktop\speaker2.png"));
                dzwiek = !dzwiek;
            }
            else if(dzwiek == true)
            {
                player.SoundLocation = @"C:\Users\Pawel\Desktop\deathnote.wav";
                player.Play();
                obraz.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"C:\Users\Pawel\Desktop\speaker1.png"));
                dzwiek = !dzwiek;
            }    
            
        }
        public string zapytanie;
        public string id;
        private void save(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            //UPDATE `members` SET `contact_number` = '0759 253 542' WHERE `membership_number` = 1;
            //string zapytanie = "INSERT INTO zaklad.danelogowania (`notatka`) VALUES('" + notatnik.Text.ToString() + "')";
            string zapytanie = "UPDATE zaklad.danelogowania SET `notatka`='"+notatnik.Text+"' WHERE id='" + id + "'";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            komenda.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Pomyślnie zapisano");

        }
        private void exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
