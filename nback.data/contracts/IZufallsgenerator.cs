using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.data.contracts
{
    public interface IZufallsgenerator
    {
        IEnumerable<char> Buchstabenliste_erstellen(int anz);
        IEnumerable<int> Indizes_für_Wiederholungen_erstellen(int min, int max, int anz);
    }
}
