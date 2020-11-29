using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class DodajCasVM
    {
        public int NastavnikId { get; set; }
        public string ImePrezime { get; set; }

        public DateTime Datum { get; set; }
        public string ListId { get; set; }
        public List<CombineRow> SkolaOdjeljenjePredmet { get; set; }
        public string SadrzajCasa { get; set; }
    }

    public class CombineRow
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}