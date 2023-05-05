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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace BalatonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List <Adatok> adatLista = new List<Adatok>();
        public MainWindow()
        {
            InitializeComponent();

            StreamReader reader = new StreamReader("utca.txt");

            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                adatLista.Add(new Adatok(reader.ReadLine()));
            }
            reader.Close();

            adatGrid.ItemsSource = adatLista;

            adosavBox.Items.Add('A');
            adosavBox.Items.Add('B');
            adosavBox.Items.Add('C');
        }

        private void modifyBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = adatGrid.SelectedIndex;

            adatLista[index].adosav = Convert.ToChar(adosavBox.SelectedValue);

            adatGrid.Items.Refresh();

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                StreamWriter writer = new StreamWriter("modositottadatok.txt");

                    foreach (var item in adatLista)
                    {
                        writer.WriteLine(item.adoszam + " " + item.utcaNev + " " + item.hazszam + " " + item.adosav + " " + item.terulet);
                    }

                    writer.Close();

                MessageBox.Show("A mentés sikeresen megtörtént!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
