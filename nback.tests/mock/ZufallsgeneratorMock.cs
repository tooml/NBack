using nback.data.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.tests.mock
{
    public class ZufallsgeneratorMock : IZufallsgenerator
    {
        private int _zeiger = -1;
        private int[][] _zufallszahlen_mock = new int[][] 
        {
            new int[] { 0, 1, 2, 3, 4 },
            new int[] { 0 }
        };

        public IEnumerable<int> Zufallszahlen_generieren(int min, int max, int anz)
        {
            _zeiger++;
            return _zufallszahlen_mock[_zeiger];
        }
    }
}
