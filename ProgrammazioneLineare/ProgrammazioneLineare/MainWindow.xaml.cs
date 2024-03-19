using BlurryControls.Controls;
using BlurryControls.DialogFactory;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace ProgrammazioneLineare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        //private static object _syncLock = new object();
        List<Oggetto> oggetti;
        public MainWindow()
        {
            InitializeComponent();
            oggetti = new List<Oggetto>();
            oggetti.Add(new Oggetto() { Nome = "Ghiaccio", X = 1, Y = 2 , Limite_Massimo = 10});
            //BindingOperations.EnableCollectionSynchronization(oggetti, _syncLock);
            Tabella.ItemsSource= LoadCollectionData();
            Rette.Text = "ax + bx + c\nax + bx + c\nax + bx + c\nax + bx + c\nax + bx + c\n";
        }
        private List<Oggetto> LoadCollectionData()
        {
            return oggetti;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BlurryMessageBox.Show(this, "Contenuto contenutoso", "Titolo");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Tabella.Items.Add("Ciao");
            oggetti.Add(new Oggetto());
            Tabella.InvalidateVisual();
            Console.WriteLine(oggetti.Count);
        }
    }
    public class Oggetto
    {
        public string Nome { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Limite_Massimo { get; set; }
    }
}
