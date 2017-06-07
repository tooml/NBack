using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nback.data.data;
using nback.data.contracts;
using nback.provider;

namespace nback.ui.tests
{
    public class Prüfstand
    {
        public void Ui_testen(Ui ui)
        {
            Cfg cfg = new Cfg("Hans", 10, 3, 2000);
            IStoppuhr stoppuhr = new Stoppuhr(2000, 20);
            var reize_list = new Reiz[] { new Reiz('A', 1, 10), new Reiz('B', 2, 10),
                                      new Reiz('C', 3, 10)};
            int reiz_zeiger = 0;

            stoppuhr.Intervall_abgelaufen += ui.Intervall_abgelaufen;
            stoppuhr.Stoppuhr_abgelaufen += ui.Reizdauer_abgelaufen;

            ui.Reiz_Test_starten += _ => {
                ui.Reiz_anzeigen(reize_list[reiz_zeiger]);
            };

            int wiederholung = 0;
            int reize = 0;

            ui.Antwort_gegben += antwort => {
                if (antwort == Antwort.Wiederholung)
                    wiederholung++;
                reize++;

                if (reize == 3)
                    ui.Ergebnis_anzeigen(new Ergebnis(wiederholung));
                else
                {
                    reiz_zeiger++;
                    ui.Reiz_anzeigen(reize_list[reiz_zeiger]);
                }
            };

            ui.Cfg_anzeigen(cfg, stoppuhr);
        }
    }
}
