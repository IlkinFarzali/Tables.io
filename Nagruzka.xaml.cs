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
    public partial class Nagruzka : Window
    {
        public ObservableCollection<object> nagr;
        XDocument doc;
        public Nagruzka()
        {
            InitializeComponent();
            Boo();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Boo()
        {
            doc = XDocument.Load("C:\\Users\\ilkin\\source\\repos\\Verstka\\Nagruzka.xml");
            var Books = (from x in doc.Element("Nagruzka").Elements("Nagr")
                         orderby x.Element("id").Value
                         select new
                         {
                             Код__преподавателя = x.Element("id").Value,
                             Код__предмета = x.Element("idp").Value,
                             Номер__группы = x.Element("gruppa").Value
                         }).ToList();

            nagr = new ObservableCollection<object>(Books);

            dg.ItemsSource = nagr;
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            var booksCount = (from x in doc.Element("Nagruzka").Elements("Nagr")
                              where (string)x.Element("id") == text1.Text
                              select new
                              {
                                  Код__преподавателя = x.Element("id").Value,
                                  Код__предмета = x.Element("idp").Value,
                                  Номер__группы = x.Element("gruppa").Value
                              }).ToList();

            Boo();
            dg.ItemsSource = booksCount;
        }

        private void but2_Click(object sender, RoutedEventArgs e)
        {
            Boo();
        }

        private void but3_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("C:\\Users\\ilkin\\source\\repos\\Verstka\\Nagruzka.xml");

            XElement root = doc.Element("Nagruzka");
            XElement newNagruzki = null;

            foreach (XElement x in root.Elements("Nagr"))
            {
                if (x.Element("id").Value == textbox10.Text)
                {
                    String a = x.Element("idp").Value;
                    String b = x.Element("gruppa").Value;                   

                    newNagruzki = new XElement("Nagr",
                                  new XElement("id", textbox10.Text),
                                  new XElement("idp", a),
                                  new XElement("gruppa", textbox11.Text));                                  

                    MessageBox.Show("Новые данные добавлены");
                    nagr.Add(new Nagr { Код__преподавателя = textbox10.Text, Код__предмета = a, Номер__группы = textbox11.Text });
                }
            }

            if (newNagruzki != null)
            {
                doc.Element("Nagruzka").Add(newNagruzki);
                doc.Save("C:\\Users\\ilkin\\source\\repos\\Verstka\\Nagruzka.xml");
                Boo();
            }
        }

        private void but6_Click(object sender, RoutedEventArgs e)
        {
            doc.Element("Nagruzka").Add(new XElement("Nagr",
                      new XElement("id", textbox12.Text),
                      new XElement("idp", textbox13.Text),
                      new XElement("gruppa", textbox14.Text)));

            MessageBox.Show("Новые данные добавлены");
            nagr.Add(new Nagr { Код__преподавателя = textbox12.Text, Код__предмета = textbox13.Text, Номер__группы = textbox14.Text });
            doc.Save("C:\\Users\\ilkin\\source\\repos\\Verstka\\Nagruzka.xml");
            Boo();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Tables tables = new Tables();
            tables.Show();
            Hide();
        }
    }
    public class Nagr
    {
        public string Код__преподавателя { get; set; }
        public string Код__предмета { get; set; }
        public string Номер__группы { get; set; }



    }
}
