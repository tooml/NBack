using nback.data.contracts;
using nback.data.data;
using nback.provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.logik
{
    public class Reizgenerator
    {
        private char[] _buchstaben = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private readonly IZufallsgenerator _zufall;

        public Reizgenerator(IZufallsgenerator zufall)
        {
            _zufall = zufall;
        }

        public Queue<Reiz> Reizfolge_berechnen(int anzahl, int n)
        {
            var buchstaben = Buchstabenliste_erstellen(anzahl);
            var nback_buchstabenlsite = NBack_Buchstabenliste_erstellen(buchstaben, anzahl, n);
            return Reizfole_erstellen(nback_buchstabenlsite);
        }

        private IEnumerable<char> Buchstabenliste_erstellen(int anzahl)
        {
            var buchstaben_indizes = _zufall.Zufallszahlen_generieren(0, _buchstaben.Count() - 1, anzahl);
            var buchstaben = Indizes_in_Buchstaben_wandeln(buchstaben_indizes);
            return buchstaben;
        }

        private IEnumerable<char> NBack_Buchstabenliste_erstellen(IEnumerable<char> buchstaben, int anzahl, int n)
        {
            var anz_wdh = Anzahl_wiederholungen_berechnen(anzahl, n);
            var letzte_mögliche_wdh = Letzte_mögliche_Wiederholung(anzahl, n);
            var austausch_index = _zufall.Zufallszahlen_generieren(0, letzte_mögliche_wdh, anzahl);
            return Wiederholungen_einfügen(buchstaben, austausch_index, n);
        }

        private IEnumerable<char> Indizes_in_Buchstaben_wandeln(IEnumerable<int> indizes)
        {
            return indizes.Select(index => _buchstaben.ElementAt(index));
        }

        private int Anzahl_wiederholungen_berechnen(int anzahl, int n)
        {
            return ((anzahl / n) / 2);
        }

        private int Letzte_mögliche_Wiederholung(int anzahl, int n)
        {
            return (anzahl - n);
        }

        private IEnumerable<char> Wiederholungen_einfügen(IEnumerable<char> buchstaben, IEnumerable<int> buchstaben_index, int n)
        {
            var buchstaben_arr = buchstaben.ToArray();

            for (int i = 0; i < buchstaben_index.Count(); i++)
            {
                var index = buchstaben_index.ElementAt(i);
                var buchstabe = buchstaben_arr[index];
                buchstaben_arr[index + n] = buchstabe;
            }

            return buchstaben_arr;
        }

        private Queue<Reiz> Reizfole_erstellen(IEnumerable<char> buchstaben)
        {
            var reiz_anzahl = buchstaben.Count();
            var reizfolge = buchstaben.Select((buchstabe, index) =>
                                        new Reiz(buchstabe, reiz_anzahl, index + 1));

            return new Queue<Reiz>(reizfolge);
        }
    }
}
