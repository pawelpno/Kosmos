using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kosmos
{
    /// <summary>
    /// Logika interakcji dla klasy potwierdzenie.xaml
    /// </summary>
    public partial class potwierdzenie : Window
    {
        public potwierdzenie()
        {
            InitializeComponent();
            logowanie log = new logowanie();
            info.Content="Czy na pewno chcesz założyć konto "+Environment.NewLine+ log.loginImput.Text+"?";
        }

        public int sprawdzenie = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sprawdzenie = 1;
            var window = Window.GetWindow(this);
            window.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sprawdzenie = 2;
            var window = Window.GetWindow(this);
            window.Close();

        }
    }
}
