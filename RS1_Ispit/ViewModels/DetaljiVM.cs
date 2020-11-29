using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class DetaljiVM
    {
        public int CasId { get; set; }
        public DateTime Datum { get; set; }
        public string SkolaOdjeljenjePredmet { get; set; }
        public string SadrzajCasa { get; set; }
        public List<UcenikRow> Ucenici { get; set; }
    }

    public class UcenikRow
    {
        public int Id { get; set; }
        public string Ucenik { get; set; }
        public int Ocjena { get; set; }
        public bool Prisutan { get; set; }
        public bool Opravdano { get; set; }
    }
}