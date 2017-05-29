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

        private void Sut_Nächster_Reiz(Reiz obj)
        {
            throw new NotImplementedException();
        }
    }
}
