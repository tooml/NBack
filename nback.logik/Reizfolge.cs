using nback.data.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.logik
{
    public class Reizfolge
    {
        private readonly Queue<Reiz> _reizfolge;

        public Reizfolge(Queue<Reiz> reizfolge)
        {
            _reizfolge = reizfolge;
        }

        public Reiz Nächsten_Reiz_bestimmen()
        {
            return (_reizfolge.Any()) ? _reizfolge.Dequeue() : null;
        }
    }
}
