using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.data.contracts
{
    public interface IStoppuhr
    {
        void Stoppuhr_starten();
        void Stoppuhr_stoppen();
        event Action Stoppuhr_abgelaufen;
        event Action Intervall_abgelaufen;
    }
}
