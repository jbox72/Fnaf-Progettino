using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fnaf_demo
{
    internal class Rana
    {
        private static readonly Random rnd = new Random();
        private readonly int[] percorso = { 2, 3,8, 8, 7, 10, 11 };
        private int indicePercorso;
        public int stanzaAttuale;
        public int aggressivita = 15;

        public Rana()
        {
            indicePercorso = 0;
            stanzaAttuale = percorso[indicePercorso]; // 2 = palco
        }

        public void Avanza()
        {
            if (indicePercorso >= percorso.Length - 1)
                return;

            if (rnd.Next(100) < aggressivita) // 20% di possibilità se aggressivita = 20\
            {
                indicePercorso++;
                stanzaAttuale = percorso[indicePercorso];
            }
        }
    }
}