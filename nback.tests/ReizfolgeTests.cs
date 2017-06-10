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
    public class ReizfolgeTests
    {
        [TestMethod]
        public void Nächsten_Reiz_bestimmen_5_Reize_gegeben()
        {
            var reize = new Reiz[] { new Reiz('A', 5, 1), new Reiz('B', 5, 1),
                                     new Reiz('C', 5, 1), new Reiz('B', 5, 1), new Reiz('E', 5, 1) };
            var sut = new Reizfolge(new Queue<Reiz>(reize));
            int sut_anzahl = 0;
            int expected_anzahl = 5;

            sut.Nächsten_Reiz_bestimmen(reiz => { sut_anzahl++; }, () => { });
            sut.Nächsten_Reiz_bestimmen(reiz => 
            {
                sut_anzahl++;
                Assert.AreEqual(reize[1].Buchstabe, reiz.Buchstabe);
                Assert.AreEqual(reize[1].Buchstabe, sut.Reizfolge_historie.ElementAt(1).Buchstabe);
            },
            () => { });
            sut.Nächsten_Reiz_bestimmen(reiz => { sut_anzahl++; }, () => { });
            sut.Nächsten_Reiz_bestimmen(reiz => { sut_anzahl++; }, () => { });
            sut.Nächsten_Reiz_bestimmen(reiz => { sut_anzahl++; }, () => { });
            sut.Nächsten_Reiz_bestimmen(reiz => { sut_anzahl++; }, () => 
            {
                Assert.AreEqual(expected_anzahl, sut_anzahl);
            });
        }
    }
}
