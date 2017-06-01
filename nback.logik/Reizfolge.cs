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
        private readonly IList<Reiz> _reizfolge_historie;

        public IEnumerable<Reiz> Reizfolge_historie { get { return _reizfolge_historie; } }

        public Reizfolge(Queue<Reiz> reizfolge)
        {
            _reizfolge = reizfolge;
            _reizfolge_historie = new List<Reiz>();
        }

        public void Nächsten_Reiz_bestimmen(Action<Reiz> nächster_Reiz, Action Reizfolge_leer)
        {
            if (_reizfolge.Any())
            {
                var reiz = _reizfolge.Dequeue();
                _reizfolge_historie.Add(reiz);
                nächster_Reiz(reiz);
            }
            else
                Reizfolge_leer();
        }
    }
}
