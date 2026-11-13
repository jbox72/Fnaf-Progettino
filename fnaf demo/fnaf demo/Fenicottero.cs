using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fnaf_demo
{
    internal class Fenicottero
    {
        // parte dal palco, va nel salone, sta nel salone 2 volte, cam laterale e infine lato ufficio, ufficio
        //1 palco
        //2 palco
        //3 palc
        //5 sgabuzzino
        //5 sgabuzzino
        //5 sgabuzzino
        //12 ATTIVA
        private static readonly Random rnd = new Random();
            private readonly int[] percorso = { 2, 2, 2, 5, 5, 5, 12 ,13,14};
            private int indicePercorso;
            public int stanzaAttuale;
            public int aggressivita = 10;

            public Fenicottero()
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
            public void TestShock(bool shock)
        {
            if (stanzaAttuale == 12 && shock)
            {
                stanzaAttuale = percorso[2];
            }else if(stanzaAttuale != 12 && shock)
            {
                stanzaAttuale = percorso[8];
            }
        }
        }
    }