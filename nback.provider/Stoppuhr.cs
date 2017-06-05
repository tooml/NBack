using nback.data.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nback.provider
{
    public class Stoppuhr : IStoppuhr
    {
        private int _zeit;
        private int _wiederholungen;
        private int _wiederholungen_zähler;
        private Timer _timer;

        public Stoppuhr(int zeit, int wiederholungen)
        {
            _zeit = zeit;
            _wiederholungen = wiederholungen;
        }

        public void Stoppuhr_starten()
        {
            _timer = new Timer(Intervall, null, 0, _zeit);
        }

        public void Stoppuhr_stoppen()
        {
            if (_timer != null)
                _timer.Dispose();
        }

        public void Intervall(object para)
        {
            _wiederholungen_zähler++;
            if(_wiederholungen_zähler == _wiederholungen)
            {
                _wiederholungen_zähler = 0;
                _timer.Dispose();
                Stoppuhr_abgelaufen();
            }
            else
            {
                Intervall_abgelaufen();
            }
        }

        public event Action Stoppuhr_abgelaufen;
        public event Action Intervall_abgelaufen;
    }
}
