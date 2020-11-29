﻿using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdrzaniCasoviVM
    {
        public int NastavnikId { get; set; }
        public List<CasRows> Casovi { get; set; }
    } 
    public class CasRows
    {
        public int Id { get; set; }

        public DateTime Datum { get; set; }
        public string Skola { get; set; }
        public string SkolskaGodina { get; set; }
        public string Predmet { get; set; }

        public string OdsutniUcenici { get; set; }
    }

}