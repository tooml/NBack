using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.data.data
{
    public class Cfg
    {
        public string Name { get; private set; }
        public int N { get; private set; }
        public int Reizdauer { get; private set; }
        public int Anzahl_Reize { get; private set; }

        public Cfg(string name, int n, int reizdauer, int anzahl_reize)
        {
            Name = name;
            N = n;
            Reizdauer = reizdauer;
            Anzahl_Reize = anzahl_reize;
        }
    }
}
