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
    public class ProtokollierenTests
    {

        [TestMethod]
        public void Protokollieren_Ergebnis_berechnen()
        {
            var test_reizfolge = new Reiz[] { new Reiz('A', 5, 1), new Reiz('B', 5, 2),
                                          new Reiz('A', 5, 3), new Reiz('D', 5, 4), new Reiz('E', 5, 5) };
            var reizfolge = new Reizfolge(new Queue<Reiz>(test_reizfolge));

            var antworten = new Antworten();
            var usecasehandler = new UseCaseHandler(null, reizfolge, antworten, new Analyst());

            Ergebnis sut = null;
            usecasehandler.Ergebnis_berechnet += erg => sut = erg;

            usecasehandler.Nächster_Reiz += reiz => { };
            reizfolge.Nächsten_Reiz_bestimmen(_ => { }, () => { });
            usecasehandler.Protokollieren(Antwort.Keine_Wiederholung, 2);
            usecasehandler.Protokollieren(Antwort.Keine_Wiederholung, 2);
            usecasehandler.Protokollieren(Antwort.Wiederholung, 2);
            usecasehandler.Protokollieren(Antwort.Wiederholung, 2);
            usecasehandler.Protokollieren(Antwort.Keine_Wiederholung, 2);

            var ergebnis_expected = new Ergebnis(80);

            Assert.AreEqual(ergebnis_expected.Prozent, sut.Prozent);
        }

        [TestMethod]
        public void Protokollieren_nächster_Reiz_vorhanden()
        {
            var test_reizfolge = new Reiz[] { new Reiz('A', 5, 1), new Reiz('B', 5, 2),
                                          new Reiz('A', 5, 3), new Reiz('D', 5, 4), new Reiz('E', 5, 5) };

            var reizfolge = new Reizfolge(new Queue<Reiz>(test_reizfolge));
            var antworten = new Antworten();
            var usecasehandler = new UseCaseHandler(new Reizgenerator(new ZufallsgeneratorMock()), reizfolge, antworten, null);

            Reiz sut = null;
            usecasehandler.Nächster_Reiz += reiz => sut = reiz;
            usecasehandler.Protokollieren(Antwort.Wiederholung, 2);        
            var reiz_expected = new Reiz('A', 5, 1);

            Assert.AreEqual(reiz_expected.Buchstabe, sut.Buchstabe);
            Assert.AreEqual(reiz_expected.Index, sut.Index);
            Assert.AreEqual(reiz_expected.Anzahl, sut.Anzahl);
        }
    }
}
