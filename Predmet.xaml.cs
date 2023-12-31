using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace Verstka
{
    /// <summary>
    /// Логика взаимодействия для Tables.xaml
    /// </summary>
    public partial class Predmet : Window
    {
        public ObservableCollection<object> predmet;
        XDocument doc;
        public Predmet()
        {
            InitializeComponent();
            Boo();
        }

        private void Boo()
        {
            doc = XDocument.Load("C:\\Users\\ilkin\\source\\repos\\Verstka\\Predmets.xml");
            var Books = (from x in doc.Element("Predmets").Elements("Predmet")
                         orderby x.Element("idp").Value
                         select new
                         {
                             Код__предмета = x.Element("idp").Value,
                             Название = x.Element("pred").Value,
                             Количество__часов = x.Element("time").Value
                         }).ToList();

            predmet = new ObservableCollection<object>(Books);

            dg.ItemsSource = predmet;
        }


        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void but6_Click(object sender, RoutedEventArgs e)
        {
            var booksCount = (from x in doc.Element("Predmets").Elements("Predmet")
                              where (string)x.Element("idp") == text1.Text
                              select new
                              {
                                  Код__предмета = x.Element("idp").Value,
                                  Название = x.Element("pred").Value,
                                  Количество__часов = x.Element("time").Value                               
                              }).ToList();

            Boo();
            dg.ItemsSource = booksCount;
        }

        private void but5_Click(object sender, RoutedEventArgs e)
        {
            Boo();
        }

        private void but4_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("C:\\Users\\ilkin\\source\\repos\\Verstka\\Predmets.xml");

            XElement root = doc.Element("Predmets");
            XElement newPredmeti = null;

            foreach (XElement x in root.Elements("Predmet"))
            {
                if (x.Element("idp").Value == textbox10.Text)
                {
                    String a = x.Element("pred").Value;
                    String b = x.Element("time").Value;

                    newPredmeti = new XElement("Predmet",
                                  new XElement("idp", textbox10.Text),
                                  new XElement("pred", a),
                                  new XElement("time", textbox11.Text));                                

                    MessageBox.Show("Новые данные добавлены");
                    predmet.Add(new Predmets { Код__предмета = textbox10.Text, Название = a, Количество__часов = textbox11.Text });
                }
            }

            if (newPredmeti != null)
            {
                doc.Element("Predmets").Add(newPredmeti);
                doc.Save("C:\\Users\\ilkin\\source\\repos\\Verstka\\Predmets.xml");
                Boo();
            }
        }

        private void but7_Click(object sender, RoutedEventArgs e)
        {
            doc.Element("Predmets").Add(new XElement("Predmet",
                      new XElement("idp", textbox12.Text),
                      new XElement("pred", textbox13.Text),
                      new XElement("time", textbox14.Text)));                     

            MessageBox.Show("Новые данные добавлены");
            predmet.Add(new Predmets { Код__предмета = textbox12.Text, Название = textbox13.Text, Количество__часов = textbox14.Text });
            doc.Save("C:\\Users\\ilkin\\source\\repos\\Verstka\\Predmets.xml");
            Boo();
        }
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Tables tables = new Tables();
            tables.Show();
            Hide();
        }
    }
    public class Predmets
    {
        public string Код__предмета { get; set; }
        public string Название { get; set; }
        public string Количество__часов { get; set; }



    }
}
