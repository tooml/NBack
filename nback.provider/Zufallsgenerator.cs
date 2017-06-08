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

        public Zufallsgenerator()
        {
            _rnd = new Random();
        }

        public IEnumerable<int> Zufallszahlen_generieren(int min, int max, int anz)
        {
            return Enumerable.Range(0, anz)
                .Select(_ => _rnd.Next(min, max));
        }
    }
}
