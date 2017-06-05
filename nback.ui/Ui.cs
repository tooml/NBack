using nback.data.contracts;
using nback.data.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.ui
{
    public class Ui
    {
        private Cfg _cfg;
        private IStoppuhr _stoppuhr;

        public void Cfg_anzeigen(Cfg cfg, IStoppuhr stoppuhr)
        {
            _cfg = cfg;
            _stoppuhr = stoppuhr;

            Console.WriteLine($"Name des Probanden: {cfg.Name}");
            Console.WriteLine($"n: {cfg.N}");
            Console.WriteLine($"Reizdauer: {cfg.Reizdauer}");
            Console.WriteLine($"Anzahl der Reize: {cfg.Anzahl_Reize}");
            Bedienung_anzeigen();
        }

        private void Bedienung_anzeigen()
        {
            Console.WriteLine();
            Console.WriteLine("Enter dürcken für Start");
            Console.WriteLine("'w' für Widerholung, 'Space' für keine Wiederholung");
            Console.WriteLine();
            Console.ReadKey();
            Reiz_Test_starten(new Start(_cfg.Anzahl_Reize, _cfg.N));
        }

        public void Reiz_anzeigen(Reiz reiz)
        {
            Console.CursorLeft = 0;
            Console.Write($"Reiz {reiz.Index} / {reiz.Anzahl} : {reiz.Buchstabe} ....................");
            _stoppuhr.Stoppuhr_starten();
            Auf_Antwort_warten();
        }

        private void Auf_Antwort_warten()
        {
            var antwort = Console.ReadKey(true);

            _stoppuhr.Stoppuhr_stoppen();

            if (antwort.Key.Equals(ConsoleKey.W))
                Antwort_gegben(Antwort.Wiederholung);
            else
                Antwort_gegben(Antwort.Keine_Wiederholung);  
        }

        public void Intervall_abgelaufen()
        {
            Console.Write("\b");
            Console.Write(" ");
            Console.Write("\b");
        }

        public void Reizdauer_abgelaufen()
        {
            _stoppuhr.Stoppuhr_stoppen();
            Antwort_gegben(Antwort.Keine_Wiederholung);
        }

        public void Ergebnis_anzeigen(Ergebnis erg)
        {
            Console.WriteLine();
            Console.WriteLine($"Ergebnis: {erg.Prozent} %");
            Console.ReadKey();
        }

        public event Action<Start> Reiz_Test_starten;
        public event Action<Antwort> Antwort_gegben;
    }
}
