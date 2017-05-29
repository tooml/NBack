using nback.data.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.logik
{
    public class Antworten
    {
        private IList<Antwort> _antworten;
        public IList<Antwort> Antwortenliste { get { return _antworten; } }

        public Antworten()
        {
            _antworten = new List<Antwort>();
        }

        public void Antwort_registrieren(Antwort antwort)
        {
            _antworten.Add(antwort);
        }
    }
}
