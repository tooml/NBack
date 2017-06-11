using Microsoft.VisualStudio.TestTools.UnitTesting;
using nback.data.data;
using nback.logik;
using nback.tests.comparer;
using nback.tests.mock;
using System.Collections.Generic;
using System.Linq;

namespace nback.tests
{
    [TestClass]
    public class ReizgeneratorTests
    {
        [TestMethod]
        public void Reizfolge_berechnen_5_Reize_eine_Wiederholung()
        {
            var reizgenerator = new Reizgenerator(new ZufallsgeneratorMock());
            var sut = reizgenerator.Reizfolge_berechnen(5, 2);

            var reize = new Reiz[] { new Reiz('A', 5, 1), new Reiz('B', 5, 2),
                                     new Reiz('A', 5, 3), new Reiz('D', 5, 4), new Reiz('E', 5, 5) };
            var expected = new Queue<Reiz>(reize);

            Assert.IsTrue(expected.SequenceEqual(sut.ToArray(), new ReizEqualityComparer()));
        }
    }
}
