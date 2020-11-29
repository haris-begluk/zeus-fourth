using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class OdrzanCasDetalji
    {
        public int Id { get; set; }

        [ForeignKey(nameof(OdjeljenjeStavkaId))]
        public int OdjeljenjeStavkaId { get; set; }

        public OdjeljenjeStavka OdjeljenjeStavka { get; set; }

        [ForeignKey(nameof(OdrzanCasId))]
        public int OdrzanCasId { get; set; }

        public OdrzanCas OdrzanCas { get; set; }

        public int Ocjena { get; set; }
        public string Napomena { get; set; }
        public bool OpravdanoOdsutan { get; set; }
        public bool Prisutan { get; set; }
    }
}