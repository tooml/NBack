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

        public void Nächsten_Reiz_bestimmen(Action<Reiz> nächster_Reiz, Action Reizfolge_leer)
        {
            if (_reizfolge.Any())
                nächster_Reiz(_reizfolge.Dequeue());
            else
                Reizfolge_leer();
        }
    }
}
