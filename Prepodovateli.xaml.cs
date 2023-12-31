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
using Verstka;

namespace Verstka
{
    /// <summary>
    /// Логика взаимодействия для Tables.xaml
    /// </summary>
    public partial class Prepodovateli : Window
    {
        public ObservableCollection<object> prepod;
        XDocument doc;
        public Prepodovateli()
        {
            InitializeComponent();
            Boo();
        }

        private void Boo()
        {
            doc = XDocument.Load("C:\\Users\\ilkin\\source\\repos\\Verstka\\Prepodavateli.xml");
            var Books = (from x in doc.Element("Prepods").Elements("prepod")
                         orderby x.Element("id").Value
                         select new
                         {
                             Код__преподавателя = x.Element("id").Value,
                             Фамилия = x.Element("familiya").Value,
                             Имя = x.Element("name").Value,
                             Отчество = x.Element("otchestvo").Value,
                             Ученая__степень = x.Element("degree").Value,
                             Должность = x.Element("position").Value,
                             Стаж = x.Element("experience").Value
                         }).ToList();

            prepod = new ObservableCollection<object>(Books);

            dg.ItemsSource = prepod;
        }

        private void Prepod_Click(object sender, RoutedEventArgs e)
        {
            Prepodovateli prepodovateli = new Prepodovateli();
            prepodovateli.Show();
            Hide();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            var booksCount = (from x in doc.Element("Prepods").Elements("prepod")
                              where (string)x.Element("id") == text1.Text
                              select new
                              {
                                  Код__преподавателя = x.Element("id").Value,
                                  Фамилия = x.Element("familiya").Value,
                                  Имя = x.Element("name").Value,
                                  Отчество = x.Element("otchestvo").Value,
                                  Ученая__степень = x.Element("degree").Value,
                                  Должность = x.Element("position").Value,
                                  Стаж = x.Element("experience").Value
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
            doc = XDocument.Load("C:\\Users\\ilkin\\source\\repos\\Verstka\\Prepodavateli.xml");

            XElement root = doc.Element("Prepods");
            XElement newPrepodi = null;

            foreach (XElement x in root.Elements("prepod"))
            {
                if (x.Element("id").Value == textbox10.Text)
                {
                    String a = x.Element("familiya").Value;
                    String b = x.Element("name").Value;
                    String c = x.Element("otchestvo").Value;
                    String d = x.Element("degree").Value;
                    String r = x.Element("position").Value;

                    newPrepodi = new XElement("prepod",
                                  new XElement("id", textbox10.Text),
                                  new XElement("familiya", a),
                                  new XElement("name", b),
                                  new XElement("otchestvo", c),
                                  new XElement("degree", d),
                                  new XElement("position", r),
                                  new XElement("experience", textbox11.Text));

                    MessageBox.Show("Новые данные добавлены");
                    prepod.Add(new Prepod { Код__преподавателя = textbox10.Text, Фамилия = a, Имя = b, Отчество = c, Ученая__степень = d, Должность = r, Стаж = textbox11.Text });
                }
            }

            if (newPrepodi != null)
            {
                doc.Element("Prepods").Add(newPrepodi);
                doc.Save("C:\\Users\\ilkin\\source\\repos\\Verstka\\Prepodavateli.xml");
                Boo();
            }
        }

        private void but6_Click(object sender, RoutedEventArgs e)
        {
            doc.Element("Prepods").Add(new XElement("prepod",
                      new XElement("id", textbox12.Text),
                      new XElement("familiya", textbox13.Text),
                      new XElement("name", textbox14.Text),
                      new XElement("otchestvo", textbox15.Text),
                      new XElement("degree", textbox16.Text),
                      new XElement("position", textbox17.Text),
                      new XElement("experience", textbox18.Text)));

            MessageBox.Show("Новые данные добавлены");
            prepod.Add(new Prepod { Код__преподавателя = textbox12.Text, Фамилия = textbox13.Text, Имя = textbox14.Text, Отчество = textbox15.Text, Ученая__степень = textbox16.Text, Должность = textbox17.Text, Стаж = textbox18.Text });
            doc.Save("C:\\Users\\ilkin\\source\\repos\\Verstka\\Prepodavateli.xml");
            Boo();
        }
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Tables tables = new Tables();
            tables.Show();
            Hide();
        }
    }
    public class Prepod
    {
        public string Код__преподавателя { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Ученая__степень { get; set; }
        public string Должность { get; set; }
        public string Стаж { get; set; }



    }
}

