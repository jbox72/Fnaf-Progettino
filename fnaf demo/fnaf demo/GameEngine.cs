using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace fnaf_demo
{
    internal class GameEngine
    {
        public DispatcherTimer T;
        public Ufficio ufficio;
        public int contatoreTick = 0;
        public Fenicottero fenicottero_anim;
        public Rana rana_anim;
        public Procione procione_anim;
        public Camere camere;
        public event EventHandler Tick;


        public Image imgjumpscare;
        public Image jumpscareShake;

       

        // MediaPlayer dichiarati a livello di classe
        private MediaPlayer jumpsound = new MediaPlayer();
        private MediaPlayer jumpsound2 = new MediaPlayer();

        public GameEngine()
        {
            ufficio = new Ufficio(false, false, false, false, 100, 0.1f,false);
            camere = new Camere();
            this.fenicottero_anim = new Fenicottero();
            this.procione_anim = new Procione();
            this.rana_anim = new Rana();

            // PRE-CARICHIAMO I SUONI QUI (così sono pronti e azzerano qualsiasi ritardo)

            jumpsound.Open(new Uri("suoni/jumpscare.wav", UriKind.Relative));
            jumpsound2.Open(new Uri("suoni/jumpscare2.wav", UriKind.Relative));

            T = new DispatcherTimer();
            T.Interval = TimeSpan.FromMilliseconds(300);

            T.Tick += GestisciTick;
            T.Start();
        }
        private async void GestisciTick(object sender, EventArgs e)
        {

            contatoreTick++;

            if (procione_anim.stanzaAttuale == 11)
            {
                T.Stop();
                jumpsound.Position = TimeSpan.Zero;
                jumpsound.Play();

                await Task.Delay(350);

                jumpsound2.Position = TimeSpan.Zero;
                jumpsound2.Play();

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(30);
                int frameIndex = 0;
                Random shakeRnd = new Random();

                if (imgjumpscare != null)
                {
                    imgjumpscare.Visibility = Visibility.Visible;
                    imgjumpscare.Source = new BitmapImage(new Uri("immagini/jumpscare_procione.jpg", UriKind.Relative));

                    TranslateTransform tremore = new TranslateTransform(0, 0);
                    imgjumpscare.RenderTransform = tremore;

                    timer.Tick += (s, ev) => {

                        double intensita = 50;
                        tremore.X = (shakeRnd.NextDouble() * 2 - 1) * intensita;
                        tremore.Y = (shakeRnd.NextDouble() * 2 - 1) * intensita;

                        frameIndex++;
                        if (frameIndex >= 100)
                        {
                            timer.Stop();
                            tremore.X = 0;
                            tremore.Y = 0;
                        }
                    };
                    timer.Start();
                }
            }

            if (rana_anim.stanzaAttuale == 11)
            { 
                    T.Stop();
                    jumpsound.Position = TimeSpan.Zero;
                    jumpsound.Play();

                    await Task.Delay(350);

                    jumpsound2.Position = TimeSpan.Zero;
                    jumpsound2.Play();

                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(30);
                    int frameIndex = 0;
                    Random shakeRnd = new Random();

                    if (imgjumpscare != null)
                    {
                        imgjumpscare.Visibility = Visibility.Visible;
                        imgjumpscare.Source = new BitmapImage(new Uri("immagini/jumpscare_rana.jpg", UriKind.Relative));

                        TranslateTransform tremore = new TranslateTransform(0, 0);
                        imgjumpscare.RenderTransform = tremore;

                        timer.Tick += (s, ev) => {

                            double intensita = 50;
                            tremore.X = (shakeRnd.NextDouble() * 2 - 1) * intensita;
                            tremore.Y = (shakeRnd.NextDouble() * 2 - 1) * intensita;

                            frameIndex++;
                            if (frameIndex >= 100)
                            {
                                timer.Stop();
                                tremore.X = 0;
                                tremore.Y = 0;
                            }
                        };
                        timer.Start();
                    }
             }
            if (fenicottero_anim.stanzaAttuale == 14)
            {
                T.Stop();
                jumpsound.Position = TimeSpan.Zero;
                jumpsound.Play();

                await Task.Delay(350);

                jumpsound2.Position = TimeSpan.Zero;
                jumpsound2.Play();

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(30);
                int frameIndex = 0;
                Random shakeRnd = new Random();

                if (imgjumpscare != null)
                {
                    imgjumpscare.Visibility = Visibility.Visible;
                    imgjumpscare.Source = new BitmapImage(new Uri("immagini/jumpscare_fenicottero.jpg", UriKind.Relative));

                    TranslateTransform tremore = new TranslateTransform(0, 0);
                    imgjumpscare.RenderTransform = tremore;

                    timer.Tick += (s, ev) => {

                        double intensita = 50;
                        tremore.X = (shakeRnd.NextDouble() * 2 - 1) * intensita;
                        tremore.Y = (shakeRnd.NextDouble() * 2 - 1) * intensita;

                        frameIndex++;
                        if (frameIndex >= 100)
                        {
                            timer.Stop();
                            tremore.X = 0;
                            tremore.Y = 0;
                        }
                    };
                    timer.Start();
                }
            }

            if (fenicottero_anim.stanzaAttuale == 13)
            {
                T.Stop();
                jumpsound.Position = TimeSpan.Zero;
                jumpsound.Play();

                await Task.Delay(350);

                jumpsound2.Position = TimeSpan.Zero;
                jumpsound2.Play();

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(30);
                int frameIndex = 0;
                Random shakeRnd = new Random();

                if (imgjumpscare != null)
                {
                    imgjumpscare.Visibility = Visibility.Visible;
                    imgjumpscare.Source = new BitmapImage(new Uri("immagini/fenicotterowither_jumpscare.jpg", UriKind.Relative));

                    TranslateTransform tremore = new TranslateTransform(0, 0);
                    imgjumpscare.RenderTransform = tremore;

                    timer.Tick += (s, ev) => {

                        double intensita = 50;
                        tremore.X = (shakeRnd.NextDouble() * 2 - 1) * intensita;
                        tremore.Y = (shakeRnd.NextDouble() * 2 - 1) * intensita;

                        frameIndex++;
                        if (frameIndex >= 100)
                        {
                            timer.Stop();
                            tremore.X = 0;
                            tremore.Y = 0;
                        }
                    };
                    timer.Start();
                }
            }
            if (Ogni(25))
            {
                camere.statoinizio = false;
            }
            if (Ogni(10))
            {
                fenicottero_anim.Avanza();
            }
            if (Ogni(7))
            {
                rana_anim.Avanza();
            }
            if (Ogni(7))
            {
                procione_anim.Avanza();
            }
            if (Ogni(3))
            {
                ufficio.ConsumaBatteria();
            }
            if (Ogni(2))
            {
                ufficio.EvolviOrario();
            }

            if (Tick != null)
            {
                Tick(this, EventArgs.Empty);
            }
        }

        public bool Ogni(int numeroTick)
        {
            if (contatoreTick == 0)
            {
                return false;
            }

            if (contatoreTick % numeroTick == 0)
            {
                return true;
            }

            return false;
        }
    }
}