using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class OdrzanCas
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string SadrzajCasa { get; set; }

        [ForeignKey(nameof(PredmetId))]
        public int PredmetId { get; set; }

        public Predmet Predmet { get; set; }

        [ForeignKey(nameof(SkolaId))]
        public int SkolaId { get; set; }

        public Skola Skola { get; set; }

        [ForeignKey(nameof(NastavnikId))]
        public int NastavnikId { get; set; }

        public Nastavnik Nastavnik { get; set; }

        [ForeignKey(nameof(OdjeljenjeId))]
        public int OdjeljenjeId { get; set; }

        public Odjeljenje Odjeljenje { get; set; }
    }
}