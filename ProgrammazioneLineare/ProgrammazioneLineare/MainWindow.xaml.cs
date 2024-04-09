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
        FinestraGrafico finestraGrafico = new FinestraGrafico();
        public MainWindow()
        {
            InitializeComponent();
            oggetti = new List<Oggetto>();
            oggetti.Add(new Oggetto() { Nome = "Ghiaccio", X = 1, Y = 2 , Limite_Massimo = 10});
            //BindingOperations.EnableCollectionSynchronization(oggetti, _syncLock);
            Tabella.ItemsSource= LoadCollectionData();
            Rette.FontSize= 15;
            Rette.Text = "Equazioni delle rette";
            aggiornaTestoRette();
        //Rette.Text = "Equazioni delle rette\nax + bx + c\nax + bx + c\nax + bx + c\nax + bx + c\n";
        //Rette.Visibility = Visibility.Collapsed;
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

        private void Tabella_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            aggiornaTestoRette();
        }

        private void aggiornaTestoRette()
        {
            String stringa = "Equazioni delle rette";
            for (int i = 0; i < oggetti.Count; i++)
            {
                stringa += "\n" + oggetti[i].X.ToString() + " x  +  " + oggetti[i].Y.ToString() + " y  =  " + oggetti[i].Limite_Massimo.ToString();
            }
            Rette.Text = stringa;
        }
        private void mostraRetta(int x, int y, int k)
        {
            
        }

        private void Tabella_KeyUp(object sender, KeyEventArgs e)
        {
            aggiornaTestoRette();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            finestraGrafico.Show();
            for(int i = 0; i < 800; i += 20)
            {
                Line linea = new Line();
                linea.X1 = i;
                linea.Y1 = 0;
                linea.X2 = i;
                linea.Y2 = 600;
                linea.Stroke = Brushes.Gray;
                linea.StrokeThickness = .5;
                finestraGrafico.grafico.Children.Add(linea);
            }
            for (int i = 0; i < 600; i += 20)
            {
                Line linea = new Line();
                linea.X1 = 0;
                linea.Y1 = i;
                linea.X2 = 800;
                linea.Y2 = i;
                linea.Stroke = Brushes.Gray;
                linea.StrokeThickness = .5;
                finestraGrafico.grafico.Children.Add(linea);
            }
            mostraRetta(0,0,0);
        }

        private void Finestra_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
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
