using System;

namespace fnaf_demo
{
    internal class Camere
    {
        public int cameraAttuale = 2; 
        public bool statoinizio = true;
        public void RichiestaCamera(int camera)
        {
            if (camera >= 1 && camera <= 8)
            {
                cameraAttuale = camera;
            }
        }

        public string OttieniImmagine(Procione procione, Rana rana, Fenicottero fenicottero)
        {
            // STANZA 2: PALCO CENTRALE
            if (cameraAttuale == 2)
            {
                if (statoinizio)
                {
                    return "immagini/Palco_3Presenti_123.png";
                }
                if (fenicottero.stanzaAttuale == 2)
                {
                    return "immagini/Palco_off.jpg";
                }
                return "immagini/Palco_nessuno.jpg";
            }

            // STANZA 8: SALONE PRINCIPALE
            else if (cameraAttuale == 8)
            {
                if (procione.stanzaAttuale == 8 && rana.stanzaAttuale == 8)
                {
                    return "immagini/Salone_tutti.jpg";
                }
                if (procione.stanzaAttuale == 8)
                {
                    return "immagini/Salone_procione.jpg";
                }
               
                if (rana.stanzaAttuale == 8)
                {
                    return "immagini/Salone_rana.jpg";
                }
                return "immagini/Salone_nessuno.jpg";
            }

            // STANZA 1: AREA RISTORAZIONE
            else if (cameraAttuale == 1)
            {
                if (procione.stanzaAttuale == 1)
                {
                    return "immagini/Ristorazione_procione.jpg"; 
                }
                return "immagini/AreaRistorazione_nessuno.jpg";
            }

            // STANZA 3: CUCINA
            else if (cameraAttuale == 3)
            {
                if (rana.stanzaAttuale == 3)
                {
                    return "immagini/cucina_rana.jpg";
                }
                return "immagini/Cucina_nessuno.jpg";
            }

            // STANZA 4: COVO PIRATI
            else if (cameraAttuale == 4)
            {
                return "immagini/CovoPirati.jpg";
            }

            // STANZA 5: SGABUZZINO / RETROPALCO
            else if (cameraAttuale == 5)
            {
                if (fenicottero.stanzaAttuale == 5)
                {
                    return "immagini/sgabuzzino_fenicottero.jpg";
                }
                if (fenicottero.stanzaAttuale == 12)
                {
                    return "immagini/sgabuzzino_fenicottero_attivo.jpg";
                }
                return "immagini/Sgabuzzino.jpg";
            }

            // SALONE SX 
            else if (cameraAttuale == 6)
            {
                if (procione.stanzaAttuale == 6)
                {
                    return "immagini/Salone_sx_procione.jpg";
                }
                return "immagini/sgabuzzino_sx.jpg";
            }
            // SALONE SX
            else if (cameraAttuale == 7)
            {
                if (rana.stanzaAttuale == 7)
                {
                    return "immagini/salone_dx_ufficio_rana.jpg";
                }
                return "immagini/salone_dx_ufficio.jpg";
            }

            // Di default
            return "immagini/Sfondocam.jpg";
        }
    }
}