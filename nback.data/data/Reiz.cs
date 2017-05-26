using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.data.data
{
    public enum Antwort
    {
        Wiederholung,
        Keine_Wiederholung
    }

    public class Reiz
    {
        public char Buchstabe { get; private set; }
        public int Anzahl { get; private set; }
        public int Index { get; private set; }

        public Reiz(char buchstabe, int anzahl, int index)
        {
            Buchstabe = buchstabe;
            Anzahl = anzahl;
            Index = index;
        }
    }
}
