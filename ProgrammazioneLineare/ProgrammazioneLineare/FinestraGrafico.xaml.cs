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

namespace ProgrammazioneLineare
{
    /// <summary>
    /// Logica di interazione per FinestraGrafico.xaml
    /// </summary>
    public partial class FinestraGrafico : Window
    {
        public FinestraGrafico()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ingrandisci(2);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rimpicciolisci(2);
        }
        public void rimpicciolisci(double fattore)
        {
            //double fattore = 2;
            double offsetX = 50;
            double offsetY = 250;
            for (int i = 0; i < grafico.Children.Count; i++)
            {
                try
                {
                    ((Line)grafico.Children[i]).X1 /= fattore;
                    ((Line)grafico.Children[i]).X1 += offsetX;
                    ((Line)grafico.Children[i]).Y1 /= fattore;
                    ((Line)grafico.Children[i]).Y1 += offsetY;
                    ((Line)grafico.Children[i]).X2 /= fattore;
                    ((Line)grafico.Children[i]).X2 += offsetX;
                    ((Line)grafico.Children[i]).Y2 /= fattore;
                    ((Line)grafico.Children[i]).Y2 += offsetY;
                }
                catch { }
            }
        }
        public void ingrandisci(double fattore)
        {
            //double fattore = 2;
            double offsetX = (100 * fattore) - 100;
            double offsetY = 500 * (fattore-1);
            for (int i = 0; i < grafico.Children.Count; i++)
            {
                try
                {
                    ((Line)grafico.Children[i]).X1 *= fattore;
                    ((Line)grafico.Children[i]).X1 -= offsetX;
                    ((Line)grafico.Children[i]).Y1 *= fattore;
                    ((Line)grafico.Children[i]).Y1 -= offsetY;
                    ((Line)grafico.Children[i]).X2 *= fattore;
                    ((Line)grafico.Children[i]).X2 -= offsetX;
                    ((Line)grafico.Children[i]).Y2 *= fattore;
                    ((Line)grafico.Children[i]).Y2 -= offsetY;
                }
                catch { }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            rimpicciolisci(20);
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
