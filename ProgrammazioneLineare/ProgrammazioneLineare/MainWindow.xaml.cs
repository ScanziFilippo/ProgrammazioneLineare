using BlurryControls.Controls;
using BlurryControls.DialogFactory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        List<double[]> punti = new List<double[]>();
        public MainWindow()
        {
            InitializeComponent();
            oggetti = new List<Oggetto>();
            /*oggetti.Add(new Oggetto() { Nome = "Ghiaccio", X = 1, Y = 2 , Limite_Massimo = 10});
            oggetti.Add(new Oggetto() { Nome = "Limone", X=5, Y = 3 , Limite_Massimo=7});
            oggetti.Add(new Oggetto() { Nome = "Acqua", X=1, Y=0,Limite_Massimo=10});*/
            oggetti.Add(new Oggetto() { Nome = "A", X = .72, Y = .23, Limite_Massimo = 13 });
            oggetti.Add(new Oggetto() { Nome = "B", X = 2, Y = .2, Limite_Massimo = 31 });
            oggetti.Add(new Oggetto() { Nome = "C", X = 12, Y = 3, Limite_Massimo = 230 });
            oggetti.Add(new Oggetto() { Nome = "D", X = .33, Y = .28, Limite_Massimo = 10 });

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
                x1 = k/x;
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
            finestraGrafico.ingrandisci(20);
            if (!graficoCaricato)
            {
                graficoCaricato = true;
            }
        }

        private void Finestra_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            calcolaPuntiIncrocio();
            calcolaPuntiAmmessi();
            calcolaZ();
        }

        private void calcolaZ()
        {
            String formula = Formula.Text;
            Match match = Regex.Match(formula, @"(?<x>-?\d+(\.\d+)?)x\s*\+\s*(?<y>-?\d+(\.\d+)?)y");

            if (match.Success)
            {
                double x = double.Parse(match.Groups["x"].Value, CultureInfo.InvariantCulture);
                double y = double.Parse(match.Groups["y"].Value, CultureInfo.InvariantCulture);
                double massimo = 0;
                double minimo = double.PositiveInfinity;
                double[] puntoMassimo = { 0, 0 };
                foreach(double[] p in punti)
                {
                    double z = (x * p[0]) + (y * p[1]);
                    //MessageBox.Show(p[0] + " " + p[1] + "\n fanno z "+ z);
                    if (Tipo.Text == "Massimizza")
                    {
                        if (z > massimo)
                        {
                            massimo = z;
                            puntoMassimo = p;
                        }
                    }
                    else
                    {
                        if (z < minimo)
                        {
                            minimo = z;
                            puntoMassimo = p;
                        }
                    }
                }
                //MessageBox.Show(x + " " + y);
                if (Tipo.Text == "Massimizza")
                    MessageBox.Show("Il valore ottimale per l'ottimizzazione è \nX: " + puntoMassimo[0] + " \nY: " + puntoMassimo[1] + "\nZ: " + massimo);
                else
                    MessageBox.Show("Il valore ottimale per l'ottimizzazione è \nX: " + puntoMassimo[0] + " \nY: " + puntoMassimo[1] + "\nZ: " + minimo);
                //Console.WriteLine($"x: {x}, y: {y}");
            }
            else
            {
                MessageBox.Show("Formula obiettivo sbagliata, digitare come questo esempio: 3.5x + 5y");
            }
        }

        private void calcolaPuntiAmmessi()
        {
            String rimossi = "Punti rimossi ";
            String feedback = "";
            foreach(double[] punto in punti.ToList())
            {
                double x = punto[0];
                double y = punto[1];
                if(x < 0 || y < 0)
                {
                    punti.Remove(punto);
                }
                foreach(Oggetto retta in oggetti)
                {
                    double yN = -((retta.X * x) - retta.Limite_Massimo) / retta.Y;
                    feedback += x + " " + y + " e " + x + " " + yN +"\n";
                    if (Tipo.Text == "Massimizza")
                    {
                        if (yN > 0 && yN <= y)
                        {
                            rimossi += x + " " + y;
                            punti.Remove(punto);
                        }
                    }
                    else
                    {
                        if (yN > 0 && yN >= y)
                        {
                            rimossi += x + " " + y;
                            punti.Remove(punto);
                        }
                    }
                }
                //MessageBox.Show(feedback);
                feedback = "";
            }
            foreach (double[] punto in punti.ToList())
            {
                double x = punto[0];
                double y = punto[1];
                if (y == 0)
                {
                    foreach (double[] p in punti.ToList())
                    {
                        if (Tipo.Text == "Massimizza")
                        {
                            if (p[1] == 0 && x > p[0])
                            {
                                punti.Remove(punto);
                            }
                        }
                        else{
                            if (p[1] == 0 && x < p[0])
                            {
                                punti.Remove(punto);
                            }
                        }
                    }
                }
            }
            String mostra = "Punti di incrocio validi:";
            /*punti = punti.Distinct().ToList<double[]>();
            punti.GroupBy(x => x).Select(d => d.First()).ToList();
            punti.Union(punti).ToList();
            punti.Cast<double>().Distinct();*/
            HashSet<double[]> set = new HashSet<double[]>(punti, new DoubleArrayComparer());
            punti = set.ToList();
            foreach (double[] p in punti)
            {
                mostra += "\n " + p[0] + ", " + p[1];
            }
            mostra += "\n\n " + punti.Count();
            //MessageBox.Show(rimossi);
            //MessageBox.Show(mostra);
        }

        private void calcolaPuntiIncrocio()
        {
            punti.Clear();
            for (int i = 0; i < oggetti.Count; i++)
            {
                if (oggetti[i].Y != 0)
                {
                    punti.Add(new double[] { 0, Math.Round(oggetti[i].Limite_Massimo / oggetti[i].Y, 3) });
                }
                if (oggetti[i].X != 0)
                {
                    punti.Add(new double[] { Math.Round(oggetti[i].Limite_Massimo / oggetti[i].X, 3), 0 });
                }
                for (int j = 0; j < oggetti.Count; j++)
                {
                    if(i!=j)
                    {
                        if (oggetti[j].Y != 0 && oggetti[j].X != 0) {
                            if (oggetti[i].Y != 0 && oggetti[i].X != 0){
                                double xSostituzione = -oggetti[i].Y / oggetti[i].X;
                                double kSostituzione = oggetti[i].Limite_Massimo / oggetti[i].X;
                                double y = (oggetti[j].Limite_Massimo - (kSostituzione * oggetti[j].X)) / (oggetti[j].Y + xSostituzione * oggetti[j].X);
                                double x = (oggetti[i].Limite_Massimo - (oggetti[i].Y*y)) / oggetti[i].X;
                                x = Math.Round(x, 3);
                                y = Math.Round(y, 3);
                                //if(x >= 0 && y >= 0)
                                    punti.Add(new double[] { x, y });
                            }
                            else if (oggetti[i].Y == 0)
                            {
                                double x = oggetti[i].Limite_Massimo / oggetti[i].X;
                                double y = (oggetti[j].Limite_Massimo - (oggetti[j].X*x))/ oggetti[j].Y;
                                x = Math.Round(x, 3);
                                y = Math.Round(y, 3);
                                //if(x >= 0 && y >= 0)
                                punti.Add(new double[] { x, y });
                            }
                            else if (oggetti[i].X == 0)
                            {
                                double y = oggetti[i].Limite_Massimo / oggetti[i].Y;
                                double x = (oggetti[j].Limite_Massimo - (oggetti[j].Y * y)) / oggetti[j].X;
                                x = Math.Round(x, 3);
                                y = Math.Round(y, 3);
                                //if(x >= 0 && y >= 0)
                                punti.Add(new double[] { x, y });
                            }
                        }
                        else if (oggetti[j].Y == 0)
                        {
                            double x = oggetti[j].Limite_Massimo / oggetti[j].X;
                            double y = (oggetti[i].Limite_Massimo - (oggetti[i].X * x)) / oggetti[i].Y;
                            x = Math.Round(x, 3);
                            y = Math.Round(y, 3);
                            //if(x >= 0 && y >= 0)
                            punti.Add(new double[] { x, y });
                        }
                        else if (oggetti[j].X == 0)
                        {
                            double y = oggetti[j].Limite_Massimo / oggetti[j].Y;
                            double x = (oggetti[i].Limite_Massimo - (oggetti[i].Y * y)) / oggetti[i].X;
                            x = Math.Round(x, 3);
                            y = Math.Round(y, 3);
                            //if(x >= 0 && y >= 0)
                            punti.Add(new double[] { x, y });
                        }
                    }
                }
            }
            String mostra = "Punti di incrocio:";
            foreach (double[] p in punti)
            {
                mostra += "\n " + p[0] + ", " + p[1];
            }
            //MessageBox.Show(mostra);
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
public class DoubleArrayComparer : IEqualityComparer<double[]>
{
    public bool Equals(double[] x, double[] y)
    {
        return x.SequenceEqual(y);
    }

    public int GetHashCode(double[] obj)
    {
        return obj[0].GetHashCode() ^ obj[1].GetHashCode();
    }
}