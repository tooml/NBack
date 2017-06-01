using nback.data.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.logik
{
    public class Analyst
    {
        public Ergebnis Ergebnis_berechnen(Reizfolge reizfolge, Antworten antworten, int n)
        {
            var richtige_Antworten = Richtige_Antwortenliste_generieren(reizfolge.Reizfolge_historie, n);
            var anzahl_korrekete_Antworten = Anazahl_der_korrekten_Antworten(richtige_Antworten, antworten.Antwortenliste);
            var gegebene_Antworten_anzahl = antworten.Antwortenliste.Count();
            var prozent = Prozentsatz_berechnen(gegebene_Antworten_anzahl, anzahl_korrekete_Antworten);

            return new Ergebnis(prozent);
        }

        private IEnumerable<Antwort> Richtige_Antwortenliste_generieren(IEnumerable<Reiz> reizfolge, int n)
        {
            IList<Antwort> richtige_antworten = new List<Antwort>();
            for (int i = 0; i < reizfolge.Count(); i++)
            {
                if (i < n)
                    richtige_antworten.Add(Antwort.Keine_Wiederholung);
                else
                    if (reizfolge.ElementAt(i).Buchstabe == reizfolge.ElementAt(i - n).Buchstabe)
                    richtige_antworten.Add(Antwort.Wiederholung);
                else
                    richtige_antworten.Add(Antwort.Keine_Wiederholung);
            }
            return richtige_antworten;
        }

        private int Anazahl_der_korrekten_Antworten(IEnumerable<Antwort> korrekte_ant, IEnumerable<Antwort> gegebene_ant)
        {
            var geleiche_antworten = 0;
            for (int i = 0; i < korrekte_ant.Count(); i++)
                if (korrekte_ant.ElementAt(i) == gegebene_ant.ElementAt(i))
                    geleiche_antworten++;

            return geleiche_antworten;
        }

        private int Prozentsatz_berechnen(int antworten_gesamt, int richtige_antworten)
        {
            return ((100 * richtige_antworten) / antworten_gesamt);
        }
    }
}
