using Microsoft.VisualStudio.TestTools.UnitTesting;
using nback.data.contracts;
using nback.data.data;
using nback.logik;
using nback.provider;
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
        private Reizgenerator _reiz_generator;
        private Reizfolge _reizfolge;
        private IZufallsgenerator _zufall;
        private IZufallsgenerator _zufall_mock;

        [TestInitialize]
        public void Init()
        {
            _zufall = new Zufallsgenerator();
            _zufall_mock = new ZufallsgeneratorMock();
            _reiz_generator = new Reizgenerator(_zufall_mock);        
        }

        [TestMethod]
        public void Reiz_Test_starten()
        {
            var sut_reizfolge = _reiz_generator.Reizfolge_berechnen(5, 2);
            var expected_reizfolge = new Reiz[] { new Reiz('A', 5, 1), new Reiz('B', 5, 2),
                                                  new Reiz('A', 5, 3), new Reiz('D', 5, 4), new Reiz('E', 5, 5) };


            Assert.IsTrue(expected_reizfolge.SequenceEqual(sut_reizfolge.ToArray(), new ReizEqualityComparer()));


            _reizfolge = new Reizfolge(sut_reizfolge);

            var sut_nächster_reiz = _reizfolge.Nächsten_Reiz_bestimmen();
            var expected_reiz = new Reiz('A', 5, 1);

            Assert.AreEqual(expected_reiz.Buchstabe, sut_nächster_reiz.Buchstabe);
            Assert.AreEqual(expected_reiz.Anzahl, sut_nächster_reiz.Anzahl);
            Assert.AreEqual(expected_reiz.Index, sut_nächster_reiz.Index);
        }

        [TestMethod]
        public void Anzahl_wiederholungen_berechnen()
        {
            var sut = _reiz_generator.Anzahl_wiederholungen_berechnen(15, 2);
            var expected = 3;

            Assert.AreEqual(expected, sut);
        }

        [TestMethod]
        public void Letzte_mögliche_Wiederholung()
        {
            var sut = _reiz_generator.Letzte_mögliche_Wiederholung(10, 2);
            var expected = 8;

            Assert.AreEqual(expected, sut);
        }

        [TestMethod]
        public void Wiederholungen_einfügen()
        {
            var buchstaben = new char[] { 'A', 'B', 'C', 'D', 'E' };
            var buchstaben_index = new int[] { 1 };

            var sut = _reiz_generator.Wiederholungen_einfügen(buchstaben, buchstaben_index, 2);
            var expected = new char[] { 'A', 'B', 'C', 'B', 'E' };

            CollectionAssert.AreEqual(expected, sut.ToArray());
        }

        [TestMethod]
        public void Reizfole_erstellen()
        {
            var buchstaben = new char[] { 'A', 'B' };

            var sut = _reiz_generator.Reizfole_erstellen(buchstaben);
            var expected = new Queue<Reiz>();

            expected.Enqueue(new Reiz('A', 2, 1));
            expected.Enqueue(new Reiz('B', 2, 2));

            Assert.AreEqual(expected.ElementAt(0).Buchstabe, sut.ElementAt(0).Buchstabe);
            Assert.AreEqual(expected.ElementAt(0).Anzahl, sut.ElementAt(0).Anzahl);
            Assert.AreEqual(expected.ElementAt(0).Index, sut.ElementAt(0).Index);
            Assert.AreEqual(expected.Count(), sut.Count());
        }

        [TestMethod]
        public void Indizes_für_Wiederholungen_erstellen()
        {
            var sut = _zufall.Indizes_für_Wiederholungen_erstellen(0, 10, 10);
            var expected = 10;

            Assert.AreEqual(expected, sut.Count());         
        }

        [TestMethod]
        public void Buchstaben_erstellen()
        {
            var sut = _zufall.Buchstabenliste_erstellen(10);
            var expected = 10;

            Assert.AreEqual(expected, sut.Count());
        }

        [TestCleanup]
        public void Clean_up()
        {
            _reiz_generator = null;
            _zufall = null;
            if (_reizfolge != null)
                _reizfolge = null;
        }
    }
}
