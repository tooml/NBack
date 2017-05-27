using nback.data.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.tests
{
    public class ZufallsgeneratorMock : IZufallsgenerator
    {
        public IEnumerable<char> Buchstabenliste_erstellen(int anz)
        {
            return new char[] { 'A', 'B', 'C', 'D', 'E' };
        }

        public IEnumerable<int> Indizes_für_Wiederholungen_erstellen(int min, int max, int anz)
        {
            return new int[] { 0 };
        }
    }
}
