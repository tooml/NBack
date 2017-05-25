using nback.data.data;
using nback.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.app
{
    public class Prüfstand
    {
        public void Ui_testen(Ui ui)
        {
            Cfg cfg = new Cfg() { Name = "Hans", Anzahl_Reize = 10, N = 3, Reizdauer = 2000 };
            
            ui.Reiz_Test_starten += () => {
                ui.Reiz_anzeigen(new Reiz() { Buchstabe = 'A', Index = 1, Anzahl = 10 });
                ui.Reiz_anzeigen(new Reiz() { Buchstabe = 'B', Index = 2, Anzahl = 10 });
                ui.Reiz_anzeigen(new Reiz() { Buchstabe = 'C', Index = 3, Anzahl = 10 });
            };

            int wiederholung = 0;
            int reize = 0;

            ui.Antwort_gegben += antwort => {
                if (antwort == Antwort.Wiederholung)
                    wiederholung++;
                reize++;

                if(reize == 3)
                    ui.Ergebnis_anzeigen(new Ergebnis() { Prozent = wiederholung });
            };

            ui.Cfg_anzeigen(cfg);
        }
    }
}
