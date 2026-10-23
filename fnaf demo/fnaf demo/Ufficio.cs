using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fnaf_demo
{
    internal class Ufficio
    {
        private bool luceSX = false;
        private bool luceDX = false;
        private bool portaSX = false;
        private bool portaDX = false;
        private float batteria = 100;
        private float consumoBatteria = 0.1f;

        private float orario = 0.0f;

        public Ufficio()
        {
        }

        public Ufficio(bool leceSX, bool leceDX, bool portaSX, bool portaDX, float batteria, float consumoBatteria)
        {
            this.luceSX = leceSX;
            this.luceDX = leceDX;
            this.portaSX = portaSX;
            this.portaDX = portaDX;
            this.batteria = batteria;
            this.consumoBatteria = consumoBatteria;
        }
        public float getOrario()
        {
            return orario;
        }
        public void EvolviOrario()
        {
            orario = orario + 0.01f;

        }

        public void ConsumaBatteria()
        {
            if (batteria > 0)
            {
                batteria = batteria - consumoBatteria;
                if (batteria < 0) batteria = 0;
            }
        }

        public float getBatteria()
        {
            return batteria;
        }

        public void apriPortaSX()
        {
            if (portaSX != false)
            {
                portaSX = false;
                consumoBatteria = consumoBatteria - 0.5f;
            }
        }

        public void chiudiPortaSX()
        {
            if (portaSX != true)
            {
                portaSX = true;
                consumoBatteria = consumoBatteria + 0.5f;
            }
        }

        public void apriPortaDX()
        {
            if (portaDX != false)
            {
                portaDX = false;
                consumoBatteria = consumoBatteria - 0.5f;
            }
        }

        public void chiudiPortaDX()
        {
            if (portaDX != true)
            {
                portaDX = true;
                consumoBatteria = consumoBatteria + 0.5f;
            }
        }

        public void accendiLeceSX()
        {
            if (luceSX != true)
            {
                luceSX = true;
                consumoBatteria = consumoBatteria + 0.2f;
            }
        }

        public void spegniLeceSX()
        {
            if (luceSX != false)
            {
                luceSX = false;
                consumoBatteria = consumoBatteria - 0.2f;
            }
        }

        public void accendiLeceDX()
        {
            if (luceDX != true)
            {
                luceDX = true;
                consumoBatteria = consumoBatteria + 0.2f;
            }
        }

        public void spegniLeceDX()
        {
            if (luceDX != false)
            {
                luceDX = false;
                consumoBatteria = consumoBatteria - 0.2f;
            }
        }
    }
}