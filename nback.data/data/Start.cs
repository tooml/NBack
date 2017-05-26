using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.data.data
{
    public class Start
    {
        public int Anzahl_Reize { get; private set; }
        public int N { get; private set; }

        public Start(int anzahl_reize, int n)
        {
            Anzahl_Reize = anzahl_reize;
            N = n;
        }
    }
}
