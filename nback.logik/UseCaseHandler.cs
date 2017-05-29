using nback.data.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.logik
{
    public class UseCaseHandler
    {
        private Reizgenerator _reizgenerator;
        private Reizfolge _reizfolge;
        private Antworten _antworten;       

        public UseCaseHandler(Reizgenerator reizgenerator, Reizfolge reizfolge, Antworten antworten)
        {
            _reizfolge = reizfolge;
            _antworten = antworten;
            _reizgenerator = reizgenerator;
        }

        public void Reiz_Test_starten(int anzahl, int n)
        {
            var reizfolge = _reizgenerator.Reizfolge_berechnen(anzahl, n);
            _reizfolge = new Reizfolge(reizfolge);
            _reizfolge.Nächsten_Reiz_bestimmen(reiz => Nächster_Reiz(reiz), () => { });
        }

        public void Protokollieren(Antwort antwort)
        {
            _antworten.Antwort_registrieren(antwort);
            _reizfolge.Nächsten_Reiz_bestimmen(reiz => Nächster_Reiz(reiz), () => { });
        }

        public event Action<Reiz> Nächster_Reiz;
        public event Action<Ergebnis> Ergebnis_berechnet;
    }
}
