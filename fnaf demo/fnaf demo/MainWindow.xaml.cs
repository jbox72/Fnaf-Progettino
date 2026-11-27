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
using System.Windows.Threading;

namespace fnaf_demo
{
    public partial class MainWindow : Window
    {
        GameEngine gameEngine;

        public MainWindow() : this(20, 15, 10) { }

        public MainWindow(int aggProcione, int aggRana, int aggFenicottero)
        {
            InitializeComponent();

            gameEngine = new GameEngine(aggProcione, aggRana, aggFenicottero);

            gameEngine.Tick += Tick_gioco;
            gameEngine.imgjumpscare = imgjumpscare;
            gameEngine.AnimatronicsMoved += GameEngine_AnimatronicsMoved;
            gameEngine.FineGioco += GameEngine_FineGioco;
        }
        private DispatcherTimer flashTimer;

        private void AvviaFlashBlackout()
        {
            if (flashTimer != null) return;

            flashTimer = new DispatcherTimer();
            flashTimer.Interval = TimeSpan.FromMilliseconds(10);
            int contatore = 0;

            flashTimer.Tick += (s, e) =>
            {
                overlayBlack.Visibility = (overlayBlack.Visibility == Visibility.Visible)
                    ? Visibility.Collapsed
                    : Visibility.Visible;

                contatore++;
                if (contatore >= 100)
                {
                    flashTimer.Stop();
                    flashTimer = null;
                    overlayBlack.Visibility = Visibility.Collapsed;
                    gameEngine.killProcione();

                }
            };

            flashTimer.Start();
        }
        private void GameEngine_FineGioco(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GameEngine_AnimatronicsMoved(object sender, int stanzaPrecedente, int stanzaSuccessiva)
        {
            if (sender is Procione)
            {
                AggiornaLuceSX();
            }

            if (sender is Rana)
            {
                AggiornaLuceDX();
            }
        }

        private void AggiornaLuceDX()
        {
            if (gameEngine.ufficio.luceDX == false)
            {
                LuceDX_img.Visibility = Visibility.Collapsed;
                return;
            }

            LuceDX_img.Visibility = Visibility.Visible;

            if (gameEngine.rana_anim.stanzaAttuale == 10)
            {
                LuceDX_img.Source = new BitmapImage(new Uri("/immagini/UfficioLuceDX.jpg", UriKind.Relative));
            }
            else
            {
                LuceDX_img.Source = new BitmapImage(new Uri("/immagini/LuceDX_nessuno.jpg", UriKind.Relative));
            }
        }

        private void AggiornaLuceSX()
        {
            if (gameEngine.ufficio.luceSX == false)
            {
                LuceSX_img.Visibility = Visibility.Collapsed;
                return;
            }

            LuceSX_img.Visibility = Visibility.Visible;

            if (gameEngine.procione_anim.stanzaAttuale == 9)
            {
                LuceSX_img.Source = new BitmapImage(new Uri("/immagini/UfficioLuceSX.jpg", UriKind.Relative));
            }
            else
            {
                LuceSX_img.Source = new BitmapImage(new Uri("/immagini/LuceSX_nessuno.jpg", UriKind.Relative));
            }
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
            if (gameEngine.VerificaBatteria())
            {
                AvviaFlashBlackout();
                gameEngine.BlackoutFine();
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

        private void Porta_DX_clck(object sender, RoutedEventArgs e)
        {
            if (gameEngine.ufficio.portaDX == false)
            {
                gameEngine.ufficio.chiudiPortaDX();
                portaDX_img.Visibility = Visibility.Visible;
            }
            else
            {
                gameEngine.ufficio.apriPortaDX();
                portaDX_img.Visibility = Visibility.Collapsed;
            }
        }

        private void PortaSX_clck(object sender, RoutedEventArgs e)
        {
            if (gameEngine.ufficio.portaSX == false)
            {
                gameEngine.ufficio.chiudiPortaSX();
                portaSX_img.Visibility = Visibility.Visible;
            }
            else
            {
                portaSX_img.Visibility = Visibility.Collapsed;
                gameEngine.ufficio.apriPortaSX();
            }
        }

        private void LuceDX_Clck(object sender, RoutedEventArgs e)
        {
            if (gameEngine.ufficio.luceDX == false)
            {
                gameEngine.ufficio.accendiLeceDX();
            }
            else
            {
                gameEngine.ufficio.spegniLeceDX();
            }

            AggiornaLuceDX();
        }

        private void LuceSX_Clck(object sender, RoutedEventArgs e)
        {
            if (gameEngine.ufficio.luceSX == false)
            {
                gameEngine.ufficio.accendiLeceSX();
            }
            else
            {
                gameEngine.ufficio.spegniLeceSX();
            }

            AggiornaLuceSX();
        }
    }
}