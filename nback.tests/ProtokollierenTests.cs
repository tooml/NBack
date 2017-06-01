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
        private object richtige;

        [TestMethod]
        public void Protokollieren_Ergebnis_berechnen()
        {
            var test_reizfolge = new Reiz[] { new Reiz('A', 5, 1), new Reiz('B', 5, 2),
                                          new Reiz('A', 5, 3), new Reiz('D', 5, 4), new Reiz('E', 5, 5) };
            var reizfolge = new Reizfolge(new Queue<Reiz>(test_reizfolge));

            var antworten = new Antworten();
            var usecasehandler = new UseCaseHandler(null, reizfolge, antworten);

            usecasehandler.Nächster_Reiz += reiz => { };
            reizfolge.Nächsten_Reiz_bestimmen(_ => { }, () => { });
            usecasehandler.Protokollieren(Antwort.Keine_Wiederholung);
            usecasehandler.Protokollieren(Antwort.Keine_Wiederholung);
            usecasehandler.Protokollieren(Antwort.Wiederholung);
            usecasehandler.Protokollieren(Antwort.Wiederholung);
            usecasehandler.Protokollieren(Antwort.Keine_Wiederholung);

            Ergebnis sut = Ergebnis_berechnen(reizfolge, antworten, 2);
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
            var usecasehandler = new UseCaseHandler(new Reizgenerator(new ZufallsgeneratorMock()), reizfolge, antworten);

            Reiz sut = null;
            usecasehandler.Nächster_Reiz += reiz => sut = reiz;
            usecasehandler.Protokollieren(Antwort.Wiederholung);        
            var reiz_expected = new Reiz('A', 5, 1);

            Assert.AreEqual(reiz_expected.Buchstabe, sut.Buchstabe);
            Assert.AreEqual(reiz_expected.Index, sut.Index);
            Assert.AreEqual(reiz_expected.Anzahl, sut.Anzahl);
        }

        [TestMethod]
        public void Protokollieren_Wiederholungen_erkennen()
        {
            var reizfolge = new Reiz[] { new Reiz('A', 5, 1), new Reiz('B', 5, 2),
                                        new Reiz('A', 5, 3), new Reiz('D', 5, 4), new Reiz('E', 5, 5) };

            var sut = Richtige_Antwortenliste_generieren(reizfolge.ToList(), 2);
            var expected_antworten = new Antwort[] { Antwort.Keine_Wiederholung, Antwort.Keine_Wiederholung,
                                                     Antwort.Wiederholung, Antwort.Keine_Wiederholung,
                                                     Antwort.Keine_Wiederholung };

            CollectionAssert.AreEqual(expected_antworten, sut.ToArray());
        }

        [TestMethod]
        public void Protokollieren_Wiederholungen_auswerten()
        {
            var richtige = new Antwort[] { Antwort.Wiederholung, Antwort.Keine_Wiederholung,
                                                     Antwort.Wiederholung, Antwort.Wiederholung };
            var gegeben = new Antwort[] { Antwort.Keine_Wiederholung, Antwort.Keine_Wiederholung,
                                                     Antwort.Wiederholung, Antwort.Keine_Wiederholung };

            var sut = Anazahl_der_korrekten_Antworten(richtige, gegeben);
            var expected = 2;

            Assert.AreEqual(expected, sut);
        }

        [TestMethod]
        public void Protokollieren_Prozentsatz_berechnen()
        {
            var sut = Prozentsatz_berechnen(15, 7);
            var expected = 46;

            Assert.AreEqual(expected, sut);
        }

        public Ergebnis Ergebnis_berechnen(Reizfolge reizfolge, Antworten antworten, int n)
        {
            var richtige_Antworten = Richtige_Antwortenliste_generieren(reizfolge.Reizfolge_historie, n);
            var anzahl_korrekete_Antworten = Anazahl_der_korrekten_Antworten(richtige_Antworten, antworten.Antwortenliste);
            var gegebene_Antworten_anzahl = antworten.Antwortenliste.Count();
            var prozent = Prozentsatz_berechnen(gegebene_Antworten_anzahl,anzahl_korrekete_Antworten);

            return new Ergebnis(prozent);
        }

        public IEnumerable<Antwort> Richtige_Antwortenliste_generieren(IEnumerable<Reiz> reizfolge, int n)
        {
            IList<Antwort> richtige_antworten = new List<Antwort>();
            for(int i = 0; i < reizfolge.Count(); i++)
            {
                if (i < n)
                    richtige_antworten.Add(Antwort.Keine_Wiederholung);
                else
                    if (reizfolge.ElementAt(i).Buchstabe == reizfolge.ElementAt(i - 2).Buchstabe)
                        richtige_antworten.Add(Antwort.Wiederholung);
                    else
                        richtige_antworten.Add(Antwort.Keine_Wiederholung);
            }
            return richtige_antworten;
        }

        public int Anazahl_der_korrekten_Antworten(IEnumerable<Antwort> korrekte_ant, IEnumerable<Antwort> gegebene_ant)
        {
            var geleiche_antworten = 0;
            for (int i = 0; i < korrekte_ant.Count(); i++)
                if (korrekte_ant.ElementAt(i) == gegebene_ant.ElementAt(i))
                    geleiche_antworten++;

            return geleiche_antworten;
        }

        public int Prozentsatz_berechnen(int antworten_gesamt, int richtige_antworten)
        {
            return ((100 * richtige_antworten) / antworten_gesamt);
        }
    }
}
