using nback.data.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.provider
{
    public class Zufallsgenerator : IZufallsgenerator
    {
        private readonly Random _rnd;
        private char[] _buchstaben = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public Zufallsgenerator()
        {
            _rnd = new Random();
        }

        public IEnumerable<char> Buchstabenliste_erstellen(int anz)
        {
            var max = _buchstaben.Count();
            return Enumerable.Range(1, anz)
                .Select(num =>  _buchstaben.ElementAt(_rnd.Next(0, max)) );
        }

        public IEnumerable<int> Indizes_für_Wiederholungen_erstellen(int min, int max, int anz)
        {
            return Enumerable.Range(0, anz)
                .Select(_ => _rnd.Next(min, max));
        }
    }
}
