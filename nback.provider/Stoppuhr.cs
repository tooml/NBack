using nback.data.contracts;
using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace nback.provider
{
    public class Stoppuhr : IStoppuhr
    {
        private int _intervalle;
        private int _intervall_zähler = 0;
        private Timer _timer;

        public Stoppuhr(int zeit, int intervalle)
        {
            _intervalle = intervalle;
            var _intervall_zeit = Intervallzeit_berechnen(zeit, _intervalle);
            _timer = new Timer(_intervall_zeit);
            _timer.Elapsed += Intervall;
        }

        public void Stoppuhr_starten()
        {
            _intervall_zähler = 0;
            _timer.Start();
        }

        public void Stoppuhr_stoppen()
        {
            _timer.Stop();
            _intervall_zähler = 0;
        }

        private int Intervallzeit_berechnen(int zeit, int intervalle)
        {
            return (zeit / intervalle);
        }

        public void Intervall(object sender, ElapsedEventArgs e)
        {
            _intervall_zähler++;
            if(_intervall_zähler == _intervalle)
            {
                _intervall_zähler = 0;
                _timer.Stop();
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
