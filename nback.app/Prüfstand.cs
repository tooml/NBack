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
            Cfg cfg = new Cfg("Hans", 10, 3, 2000 );
            
            ui.Reiz_Test_starten += _ => {
                ui.Reiz_anzeigen(new Reiz('A', 1, 10 ));
                ui.Reiz_anzeigen(new Reiz('B', 2, 10 ));
                ui.Reiz_anzeigen(new Reiz('C', 3, 10 ));
            };

            int wiederholung = 0;
            int reize = 0;

            ui.Antwort_gegben += antwort => {
                if (antwort == Antwort.Wiederholung)
                    wiederholung++;
                reize++;

                if(reize == 3)
                    ui.Ergebnis_anzeigen(new Ergebnis(wiederholung));
            };

            ui.Cfg_anzeigen(cfg);
        }
    }
}
