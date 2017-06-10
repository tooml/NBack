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
    public class AntwortenTests
    {
        [TestMethod]
        public void Fünf_Antworten_werden_gegeben()
        {
            var sut = new Antworten();
            sut.Antwort_registrieren(Antwort.Keine_Wiederholung);
            sut.Antwort_registrieren(Antwort.Keine_Wiederholung);
            sut.Antwort_registrieren(Antwort.Wiederholung);
            sut.Antwort_registrieren(Antwort.Keine_Wiederholung);
            sut.Antwort_registrieren(Antwort.Keine_Wiederholung);

            Assert.AreEqual(5, sut.Antwortenliste.Count());
            Assert.AreEqual(Antwort.Keine_Wiederholung, sut.Antwortenliste.ElementAt(0));
            Assert.AreEqual(Antwort.Wiederholung, sut.Antwortenliste.ElementAt(2));
        }
    }
}
