﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nback.ui.tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Ui ui = new Ui();
            Prüfstand prüfstand = new Prüfstand();
            prüfstand.Ui_testen(ui);
        }
    }
}
