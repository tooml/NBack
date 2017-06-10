using Microsoft.VisualStudio.TestTools.UnitTesting;
using nback.data.data;
using nback.logik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.tests
{
    [TestClass]
    public class AnalystTests
    {
        [TestMethod]
        public void Ergebnis_berechnen_5_Reize_eine_Falsche_Antwort_Ergebnis_80Prozent()
        {
            Analyst analyst = new Analyst();
            
            var antworten = new Antworten();
            antworten.Antwort_registrieren(Antwort.Keine_Wiederholung);
            antworten.Antwort_registrieren(Antwort.Keine_Wiederholung);
            antworten.Antwort_registrieren(Antwort.Keine_Wiederholung);
            antworten.Antwort_registrieren(Antwort.Wiederholung);
            antworten.Antwort_registrieren(Antwort.Wiederholung);

            var reize = new Reiz[] { new Reiz('A', 5, 1), new Reiz('B', 5, 1),
                                     new Reiz('C', 5, 1), new Reiz('B', 5, 1), new Reiz('E', 5, 1) };
            var reizfolge = new Reizfolge(new Queue<Reiz>(reize));

            Ergebnis sut = null;
            var expected = 80;

            reizfolge.Nächsten_Reiz_bestimmen(_ => { }, () => { });
            reizfolge.Nächsten_Reiz_bestimmen(_ => { }, () => { });
            reizfolge.Nächsten_Reiz_bestimmen(_ => { }, () => { });
            reizfolge.Nächsten_Reiz_bestimmen(_ => { }, () => { });
            reizfolge.Nächsten_Reiz_bestimmen(_ => { }, () => { });
            reizfolge.Nächsten_Reiz_bestimmen(_ => { }, () => 
            {
                sut = analyst.Ergebnis_berechnen(reizfolge, antworten, 2);
            });

            Assert.AreEqual(expected, sut.Prozent);
        }
    }
}
