﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private UseCaseHandler _usecasehandler;
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
            _usecasehandler = new UseCaseHandler(_reiz_generator, _reizfolge, new Antworten());     
        }

        [TestMethod]
        public void Reiz_Test_starten_UseCaseHandler()
        {
            Reiz sut = null;
            _usecasehandler.Nächster_Reiz += reiz => sut = reiz;
            _usecasehandler.Reiz_Test_starten(5, 2);

            var reiz_expected = new Reiz('A', 5, 1);

            Assert.AreEqual(reiz_expected.Buchstabe, sut.Buchstabe);
            Assert.AreEqual(reiz_expected.Index, sut.Index);
            Assert.AreEqual(reiz_expected.Anzahl, sut.Anzahl);
        }

        [TestMethod]
        public void Reiz_Test_starten()
        {
            var sut_reizfolge = _reiz_generator.Reizfolge_berechnen(5, 2);
            var expected_reizfolge = new Reiz[] { new Reiz('A', 5, 1), new Reiz('B', 5, 2),
                                                  new Reiz('A', 5, 3), new Reiz('D', 5, 4), new Reiz('E', 5, 5) };


            Assert.IsTrue(expected_reizfolge.SequenceEqual(sut_reizfolge.ToArray(), new ReizEqualityComparer()));


            _reizfolge = new Reizfolge(sut_reizfolge);
            Reiz sut_nächster_reiz = null;
            _reizfolge.Nächsten_Reiz_bestimmen(reiz => sut_nächster_reiz = reiz, () => { });
            var expected_reiz = new Reiz('A', 5, 1);

            Assert.AreEqual(expected_reiz.Buchstabe, sut_nächster_reiz.Buchstabe);
            Assert.AreEqual(expected_reiz.Anzahl, sut_nächster_reiz.Anzahl);
            Assert.AreEqual(expected_reiz.Index, sut_nächster_reiz.Index);
        }

        [TestCleanup]
        public void Clean_up()
        {
            _reiz_generator = null;
            _zufall = null;
            if (_reizfolge != null)
                _reizfolge = null;
            _usecasehandler = null;
        }
    }
}