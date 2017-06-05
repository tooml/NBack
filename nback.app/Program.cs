using nback.logik;
using nback.provider;
using nback.ui;
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

            //var analyst = new Analyst();
            //var reizgenerator = new Reizgenerator(new Zufallsgenerator());
            //var antworten = new Antworten();

            //var usecasehandler = new UseCaseHandler(reizgenerator, antworten, analyst);

            //ui.Reiz_Test_starten += start => usecasehandler.Reiz_Test_starten(start.Anzahl_Reize, start.N);
            //usecasehandler.Nächster_Reiz += ui.Reiz_anzeigen;
            //ui.Antwort_gegben += ant => usecasehandler.Protokollieren(ant, 2);
            //usecasehandler.Ergebnis_berechnet += ui.Ergebnis_anzeigen;

            //ui.Cfg_anzeigen(new data.data.Cfg("peter", 2, 30, 5), new Stoppuhr(3000, 2));

            Prüfstand prüfstand = new Prüfstand();
            prüfstand.Ui_testen(ui);
        }
    }
}
