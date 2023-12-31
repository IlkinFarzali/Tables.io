using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Verstka
{
    /// <summary>
    /// Логика взаимодействия для Prepod.xaml
    /// </summary>
    public partial class Tables : Window
    {
        public Tables()
        {
            InitializeComponent();
        }

        private void Button_Prepod_Click(object sender, RoutedEventArgs e)
        {
            Prepodovateli prepodovateli = new Prepodovateli();
            prepodovateli.Show();
            Hide();
        }

        private void Button_Predmet_Click(object sender, RoutedEventArgs e)
        {
            Predmet predmet = new Predmet();
            predmet.Show();
            Hide();
        }

        private void Button_Nagr_Click(object sender, RoutedEventArgs e)
        {
            Nagruzka nagruzka = new Nagruzka();
            nagruzka.Show();
            Hide();
        }
    }
}
