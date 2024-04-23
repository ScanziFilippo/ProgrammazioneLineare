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
        List<Retta> rette;
        FinestraGrafico finestraGrafico = new FinestraGrafico();
        public MainWindow()
        {
            InitializeComponent();
            rette = new List<Retta>();
            rette.Add(new Retta() { X = 1, Y = 2 , K = 10});
        }
        private List<Retta> LoadCollectionData()
        {
            return rette;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BlurryMessageBox.Show(this, "Contenuto contenutoso", "Titolo");
        }
        private void mostraRetta(double x, double y, double k)
        {
            double x1 = -100;
            double y1 = (k - (x1 * x)) / y;
            double x2 = 800;
            double y2 = (k - (x2 * x))/y;
            Line linea = new Line();
            linea.X1 = x1 + 100;
            linea.Y1 = -(y1 - 500);
            linea.X2 = x2 + 100;
            linea.Y2 = -(y2 - 500);
            linea.Stroke = Brushes.Red;
            linea.StrokeThickness = .5;
            Console.WriteLine(linea.X1 + "\n");
            Console.WriteLine(linea.X2 + "\n");
            Console.WriteLine(linea.Y1 + "\n");
            Console.WriteLine(linea.Y2+ "\n");
            finestraGrafico.grafico.Children.Add(linea);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            finestraGrafico.Show();
            for(int i = 0; i < 800; i += 1)
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
            for (int i = 0; i < 600; i += 1)
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
            for(int i = 0; i < rette.Count; i += 1)
            {
                mostraRetta(rette[i].X, rette[i].Y, rette[i].K);
            }
            //mostraRetta(1,2,10);
            finestraGrafico.ingrandisci(20);
        }

        private void Finestra_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
    public class Retta
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double K { get; set; }
    }
}
