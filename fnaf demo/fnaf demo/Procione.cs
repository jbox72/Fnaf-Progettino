using System;

namespace fnaf_demo
{
    internal class Procione
    {
        private static readonly Random rnd = new Random();
        public readonly int[] percorso = { 2, 1, 8, 6, 6, 9, 11 };
        public int indicePercorso;
        public int stanzaAttuale;
        public int aggressivita = 20;

        public Procione()
        {
            ResetAllInizio();
        }

        public void ResetAllInizio()
        {
            indicePercorso = 0;
            stanzaAttuale = percorso[indicePercorso];
        }

        public void Avanza()
        {
            if (indicePercorso >= percorso.Length - 1)
                return;

            if (rnd.Next(100) < aggressivita)
            {
                indicePercorso++;
                stanzaAttuale = percorso[indicePercorso];
            }
        }
    }
}