﻿using BlurryControls.Controls;
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
        bool graficoCaricato = false;
        public MainWindow()
        {
            InitializeComponent();
            oggetti = new List<Oggetto>();
            oggetti.Add(new Oggetto() { Nome = "Ghiaccio", X = 1, Y = 2 , Limite_Massimo = 10});
            oggetti.Add(new Oggetto() { Nome = "Limone", X=5, Y = 3 , Limite_Massimo=7});
            oggetti.Add(new Oggetto() { Nome = "Acqua", X=1, Y=0,Limite_Massimo=10});
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

        private void aggiornaTestoRette()
        {
            String stringa = "Equazioni delle rette";
            for (int i = 0; i < oggetti.Count; i++)
            {
                stringa += "\n" + oggetti[i].X.ToString() + " x  +  " + oggetti[i].Y.ToString() + " y  >=  " + oggetti[i].Limite_Massimo.ToString();
            }
            Rette.Text = stringa;
        }
        private void mostraRetta(double x, double y, double k)
        {
            double x1;
            double x2;
            double y1;
            double y2;
            if (y == 0)
            {
                x1 = x;
                y1 = 1000;
                x2 = x1;
                y2 = -500;
            }
            else
            {
                x1 = -100;
                y1 = (k - (x1 * x)) / y;
                x2 = 800;
                y2 = (k - (x2 * x)) / y;
            }
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

        private void Tabella_KeyUp(object sender, KeyEventArgs e)
        {
            aggiornaTestoRette();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            finestraGrafico.Show();
            for (int i = 0; i < finestraGrafico.grafico.Children.Count; i += 1)
            {
                //Line lineat = ((Line)finestraGrafico.grafico.Children[i]);
                try
                {
                    if (((Line)finestraGrafico.grafico.Children[i]).Stroke == Brushes.Red)
                    {
                        finestraGrafico.grafico.Children.RemoveAt(i);
                    }
                }
                catch { }
            }
            if (!graficoCaricato)
            {
                for (int i = 0; i < 800; i += 1)
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
            }
            for(int i = 0; i < oggetti.Count; i += 1)
            {
                mostraRetta(oggetti[i].X, oggetti[i].Y, oggetti[i].Limite_Massimo);
            }
            if (!graficoCaricato)
            {
                finestraGrafico.ingrandisci(20);
                graficoCaricato = true;
            }
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
