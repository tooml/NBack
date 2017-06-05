using nback.logik;
using nback.provider;
using nback.ui;
using nback.data.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.app
{
    class Program
    {
        static void Main(string[] args)
        {
            Ui ui = new Ui();
            //Cfg cfg = new Cfg("peter", 1, 3000, 10);
            //Stoppuhr stoppuhr = new Stoppuhr(cfg.Reizdauer, 20);

            //var analyst = new Analyst();
            //var reizgenerator = new Reizgenerator(new Zufallsgenerator());
            //var antworten = new Antworten();

            //var usecasehandler = new UseCaseHandler(reizgenerator, antworten, analyst);

            //stoppuhr.Intervall_abgelaufen += ui.Intervall_abgelaufen;
            //stoppuhr.Stoppuhr_abgelaufen += ui.Reizdauer_abgelaufen;

            //ui.Reiz_Test_starten += start => usecasehandler.Reiz_Test_starten(start.Anzahl_Reize, start.N);
            //usecasehandler.Nächster_Reiz += ui.Reiz_anzeigen;
            //ui.Antwort_gegben += ant => usecasehandler.Protokollieren(ant, cfg.N);
            //usecasehandler.Ergebnis_berechnet += ui.Ergebnis_anzeigen;

            //ui.Cfg_anzeigen(cfg, stoppuhr);

            Prüfstand prüfstand = new Prüfstand();
            prüfstand.Ui_testen(ui);
        }
    }
}
