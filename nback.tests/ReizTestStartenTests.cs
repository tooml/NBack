using Microsoft.VisualStudio.TestTools.UnitTesting;
using nback.data.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.tests
{
    [TestClass]
    public class ReizTestStartenTests
    {
        [TestMethod]
        public void Reiz_Test_starten()
        {
            char[] reizfolge = Reizfolge_berechnen(5, 2);
            var sut = Nächsten_Reiz_bestimmen();

            Assert.AreEqual('A', sut.Buchstabe);
            Assert.AreEqual(5, sut.Anzahl);
            Assert.AreEqual(1, sut.Index);
        }

        private char[] Reizfolge_berechnen(int anzahl, int n)
        {
            return new char[] { 'A', 'B', 'C', 'D' };
        }

        private Reiz Nächsten_Reiz_bestimmen()
        {
            return new Reiz('A', 5, 1);
        }
    }
}
