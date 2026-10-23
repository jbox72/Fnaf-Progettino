using System;
using System.Windows.Threading;

namespace fnaf_demo
{
    internal class GameEngine
    {
        public DispatcherTimer T;
        public Ufficio ufficio;
        public int contatoreTick = 0;

        public event EventHandler Tick;

        public GameEngine()
        {
            ufficio = new Ufficio(false, false, false, false, 2, 0.1f);

            T = new DispatcherTimer();
            T.Interval = TimeSpan.FromMilliseconds(300);

            T.Tick += GestisciTick;
            T.Start();
        }

        private void GestisciTick(object sender, EventArgs e)
        {
            contatoreTick++;

            if (Ogni(2))
            {
                ufficio.ConsumaBatteria();
            }
            if (Ogni(1))
            {
                ufficio.EvolviOrario();
            }
            if (ufficio.getBatteria() <= 0)
            {
                
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