using System;

namespace fnaf_demo
{
    // parte dal palco, va nel salone, sta nel salone 2 volte, cam laterale e infine lato ufficio, ufficio
    //1 palco        \2
    //2 salone       \8
    //3 salone (bis) \8
    //4 cam laterale \7
    //5 lato ufficio \10
    //6 ufficio      \11
    internal class Procione
    {
        private static readonly Random rnd = new Random();
        private readonly int[] percorso = { 2, 1, 8, 6, 6, 9, 11 };
        private int indicePercorso;
        public int stanzaAttuale;
        public int aggressivita = 20;

        public Procione()
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