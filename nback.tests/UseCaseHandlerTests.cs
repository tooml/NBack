using Microsoft.VisualStudio.TestTools.UnitTesting;
using nback.data.data;
using nback.logik;
using nback.tests.mock;

namespace nback.tests
{
    [TestClass]
    public class UseCaseHandlerTests
    {
        [TestMethod]
        public void Reiz_Test_starten_erster_Reiz()
        {
            var usecasehandler = new UseCaseHandler(new Reizgenerator(new ZufallsgeneratorMock()), new Antworten(), new Analyst());

            Reiz sut = null;
            usecasehandler.Nächster_Reiz += reiz => sut = reiz;
            usecasehandler.Reiz_Test_starten(5, 2);

            var reiz_expected = new Reiz('A', 5, 1);

            Assert.AreEqual(reiz_expected.Buchstabe, sut.Buchstabe);
            Assert.AreEqual(reiz_expected.Index, sut.Index);
            Assert.AreEqual(reiz_expected.Anzahl, sut.Anzahl);
        }

        [TestMethod]
        public void Protokollieren_Ergebnis_berechnen()
        {
            var antworten = new Antworten();
            var usecasehandler = new UseCaseHandler(new Reizgenerator(new ZufallsgeneratorMock()),
                                                                            antworten, new Analyst());

            Ergebnis sut = null;
            usecasehandler.Ergebnis_berechnet += erg => sut = erg;

            usecasehandler.Nächster_Reiz += reiz => { };
            usecasehandler.Reiz_Test_starten(5, 2);

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
            var antworten = new Antworten();
            var usecasehandler = new UseCaseHandler(new Reizgenerator(new ZufallsgeneratorMock()), antworten, null);

            Reiz sut = null;

            usecasehandler.Nächster_Reiz += reiz => sut = reiz;
            usecasehandler.Reiz_Test_starten(5, 2);
            usecasehandler.Protokollieren(Antwort.Wiederholung, 2);

            var reiz_expected = new Reiz('B', 5, 2);

            Assert.AreEqual(reiz_expected.Buchstabe, sut.Buchstabe);
            Assert.AreEqual(reiz_expected.Index, sut.Index);
            Assert.AreEqual(reiz_expected.Anzahl, sut.Anzahl);
        }
    }
}
