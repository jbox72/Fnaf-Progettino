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

namespace fnaf_demo
{
    public partial class Menu : Window
    {
        int aggProcione = 5;
        int aggRana = 5;
        int aggFenicottero = 5;

        public Menu()
        {
            InitializeComponent();
            AggiornaTesti();
        }

        private void AggiornaTesti()
        {
            ProcioneValore_text.Text = aggProcione.ToString();
            RanaValore_text.Text = aggRana.ToString();
            FenicotteroValore_text.Text = aggFenicottero.ToString();
        }

        private void LivelloFacile_Click(object sender, RoutedEventArgs e)
        {
            aggProcione = 15;
            aggRana = 0;
            aggFenicottero = 0;
            AggiornaTesti();
        }

        private void LivelloNormale_Click(object sender, RoutedEventArgs e)
        {
            aggProcione = 15;
            aggRana = 20;
            aggFenicottero = 15;
            AggiornaTesti();
        }

        private void LivelloDifficile_Click(object sender, RoutedEventArgs e)
        {
            aggProcione = 30;
            aggRana = 25;
            aggFenicottero = 20;
            AggiornaTesti();
        }

        private void LivelloCaos_Click(object sender, RoutedEventArgs e)
        {
            aggProcione = 40;
            aggRana = 40;
            aggFenicottero = 30;
            AggiornaTesti();
        }

        private void ProcioneMeno_Click(object sender, RoutedEventArgs e)
        { 
                aggProcione--;
                AggiornaTesti();
            
        }

        private void ProcionePiu_Click(object sender, RoutedEventArgs e)
        {

                aggProcione++;
                AggiornaTesti();
            
        }

        private void RanaMeno_Click(object sender, RoutedEventArgs e)
        {

                aggRana--;
                AggiornaTesti();
            
        }

        private void RanaPiu_Click(object sender, RoutedEventArgs e)
        {

                aggRana++;
                AggiornaTesti();
            
        }

        private void FenicotteroMeno_Click(object sender, RoutedEventArgs e)
        {

                aggFenicottero--;
                AggiornaTesti();
        
        }

        private void FenicotteroPiu_Click(object sender, RoutedEventArgs e)
        {

                aggFenicottero++;
                AggiornaTesti();

        }

        private void Avvia_Click(object sender, RoutedEventArgs e)
        {
            MainWindow finestraGioco = new MainWindow(aggProcione, aggRana, aggFenicottero);
            this.Hide();
            finestraGioco.ShowDialog();
            this.Show();
        }
    }
}