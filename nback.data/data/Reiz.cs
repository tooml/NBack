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
        public char Buchstabe { get; set; }
        public int Anzahl { get; set; }
        public int Index { get; set; }
    }
}
