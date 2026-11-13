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

namespace fnaf_demo
{
    public partial class MainWindow : Window
    {
        GameEngine gameEngine = new GameEngine();
        // Windows1 w = new Windows1();
        // w.showdialog()
        public MainWindow()
        {
            InitializeComponent();
            
            gameEngine.Tick += Tick_gioco;
            gameEngine.imgjumpscare = imgjumpscare;

        }

        private void Tick_gioco(object sender, EventArgs e)
        {
            float Ba = gameEngine.ufficio.getBatteria();
            int iBa = (int)Ba;
            float Or = gameEngine.ufficio.getOrario();
            int iOR = (int)Or;

            Batteria_text.Text = iBa.ToString() + "%";
            Orario.Text = iOR.ToString() + ":00";


          
            if (CameraMenuGrid.Visibility == Visibility.Visible)
            {
                AggiornaVistaCamera();
            }

            if (iBa <= 0)
            {
                Batteria_text.Text = "0%";
                MessageBox.Show("Hai perso! La batteria è finita!");
                Application.Current.Shutdown();
            }
        }
        private void AggiornaVistaCamera()
        {
            string percorsoImmagine = gameEngine.camere.OttieniImmagine(gameEngine.procione_anim, gameEngine.rana_anim, gameEngine.fenicottero_anim);
            imgCamera.Source = new BitmapImage(new Uri(percorsoImmagine, UriKind.Relative));
        }

        private void Camere_click(object sender, RoutedEventArgs e)
        {
            if (CameraMenuGrid.Visibility == Visibility.Visible)
            {
                CameraMenuGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                CameraMenuGrid.Visibility = Visibility.Visible;
                AggiornaVistaCamera(); 
            }
        }

        private void Palco(object sender, RoutedEventArgs e)
        {
            gameEngine.camere.RichiestaCamera(2);
            AggiornaVistaCamera();
        }

        private void Saloneclc(object sender, RoutedEventArgs e)
        {
            gameEngine.camere.RichiestaCamera(8);
            AggiornaVistaCamera();
        }

        private void CucinaKlic(object sender, RoutedEventArgs e)
        {
            gameEngine.camere.RichiestaCamera(3);
            AggiornaVistaCamera();
        }

        private void RistorazioneKlc(object sender, RoutedEventArgs e)
        {
            gameEngine.camere.RichiestaCamera(1);
            AggiornaVistaCamera();
        }

        private void PiratiKlc(object sender, RoutedEventArgs e)
        {
            gameEngine.camere.RichiestaCamera(4);
            AggiornaVistaCamera();
        }

        private void RetroKlc(object sender, RoutedEventArgs e)
        {
            gameEngine.camere.RichiestaCamera(5);
            AggiornaVistaCamera();
        }

        private void Servizio_sx(object sender, RoutedEventArgs e)
        {
            gameEngine.camere.RichiestaCamera(6);
            AggiornaVistaCamera();
        }

        private void Salone_dx(object sender, RoutedEventArgs e)
        {
            gameEngine.camere.RichiestaCamera(7);
            AggiornaVistaCamera();
        }

        private void Shock_clck(object sender, RoutedEventArgs e)
        {
            gameEngine.fenicottero_anim.TestShock(true);
            gameEngine.ufficio.shock = false;
        }
    }
}