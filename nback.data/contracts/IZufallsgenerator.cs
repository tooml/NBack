using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.data.contracts
{
    public interface IZufallsgenerator
    {
        IEnumerable<int> Zufallszahlen_generieren(int min, int max, int anz);
    }
}
