using Microsoft.AspNetCore.Mvc;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;
using System;
using System.Linq;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class OdrzanaNastavaController : Controller
    {
        private readonly MojContext _context;

        public OdrzanaNastavaController(MojContext context)
        {
            _context = context;
        }

        // GET: OdrzanaNastavaController
        public ActionResult Index()
        {
            var model = _context.Nastavnik.Select(s => new IndexVM
            {
                NastavnikId = s.Id,
                ImePrezime = $"{s.Ime} {s.Prezime}",
                BrojOdrzanihCasova = _context.OdrzanCas.Where(w => w.NastavnikId.Equals(s.Id)).Count()
            }).ToList();
            return View(model);
        }

        public ActionResult Casovi(int id)
        {
            var model =
                new OdrzaniCasoviVM
                {
                    NastavnikId = id,
                    Casovi = _context.OdrzanCas.Where(w => w.NastavnikId.Equals(id))
                .Select(s => new CasRows
                {
                    Id = s.Id,
                    Datum = s.Datum,
                    Skola = s.Skola.Naziv,
                    SkolskaGodina = $"{s.Odjeljenje.SkolskaGodina.Naziv} {s.Odjeljenje.Oznaka}",
                    Predmet = s.Predmet.Naziv,
                    OdsutniUcenici = string.Join(",", _context.OdrzanCasDetalji
                    .Where(w => w.OdrzanCas.NastavnikId.Equals(s.Id) && w.OpravdanoOdsutan.Equals(true))
                    .Select(r => r.OdjeljenjeStavka.Ucenik.ImePrezime).ToList())
                }).ToList()
                };

            return View(model);
        }

        public ActionResult DodajCas(int id)
        {
            var model = new DodajCasVM
            {
                NastavnikId = id,
                ImePrezime = _context.Nastavnik.Select(s => new { s.Id, ImePrezime = $"{s.Ime} {s.Prezime}" }).FirstOrDefault(f => f.Id.Equals(id)).ImePrezime,
                Datum = DateTime.Now,
                SkolaOdjeljenjePredmet = _context.OdrzanCas.Select(s => new CombineRow
                {
                    Id = $"{ s.SkolaId},{s.OdjeljenjeId},{s.PredmetId}",
                    Text = $"{s.Skola.Naziv}/{s.Odjeljenje.Oznaka}/{s.Predmet.Naziv}"
                }).ToList()
            };

            return PartialView("DodajCasPartial", model);
        }

        [HttpPost]
        public ActionResult DodajCas(DodajCasVM obj)
        {
            var Ids = obj.ListId.Split(",");
            _context.OdrzanCas.Add(new OdrzanCas
            {
                NastavnikId = obj.NastavnikId,
                SkolaId = int.Parse(Ids[0]),
                OdjeljenjeId = int.Parse(Ids[1]),
                PredmetId = int.Parse(Ids[2]),
                Datum = obj.Datum,
                SadrzajCasa = obj.SadrzajCasa
            });

            _context.SaveChanges();
            return RedirectToAction(nameof(Casovi), new { id = obj.NastavnikId });
        }

        public ActionResult Detalji(int id)
        {
            var model = _context.OdrzanCas.Where(w => w.Id.Equals(id)).Select(s => new DetaljiVM
            {
                CasId = s.Id,
                Datum = s.Datum,
                SkolaOdjeljenjePredmet = $"{s.Skola.Naziv}/{s.Odjeljenje.Oznaka}/{s.Predmet.Naziv}",
                SadrzajCasa = s.SadrzajCasa,
                Ucenici = _context.OdrzanCasDetalji.Where(w => w.OdrzanCas.Id.Equals(id))
                .Select(r => new UcenikRow
                {
                    Ucenik = r.OdjeljenjeStavka.Ucenik.ImePrezime,
                    Ocjena = r.Ocjena,
                    Id = r.Id,
                    Opravdano = r.OpravdanoOdsutan,
                    Prisutan = r.Prisutan
                }).ToList()
            }).FirstOrDefault();

            return View(model);
        }

        public void Prisutan(int id)
        {
            var model = _context.OdrzanCasDetalji.FirstOrDefault(f => f.Id.Equals(id));
            model.Prisutan = !model.Prisutan;
            _context.SaveChanges();
        }

        public IActionResult Uredi(int id)
        {
            var model = _context.OdrzanCasDetalji.Where(w => w.Id.Equals(id)).Select(s => new UrediVM
            {
                UcenikId = id,
                Ucenik = s.OdjeljenjeStavka.Ucenik.ImePrezime,
                Ocjena = s.Ocjena,
                Prisutan = s.Prisutan,
                Napomena = s.Napomena,
                OpravdanoOdsutan = s.OpravdanoOdsutan
            }).FirstOrDefault();
            return PartialView("UrediPartial", model);
        }

        [HttpPost]
        public void Uredi(UrediVM obj)
        {
            var model = _context.OdrzanCasDetalji.FirstOrDefault(f => f.Id.Equals(obj.UcenikId));
            if (model.Prisutan)
            {
                model.Ocjena = obj.Ocjena;
            }
            else
            {
                model.Napomena = obj.Napomena;
                model.OpravdanoOdsutan = obj.OpravdanoOdsutan;
            }
            _context.SaveChanges();
        }

        public void Ocjena(int id, int bodovi)
        {
            var model = _context.OdrzanCasDetalji.FirstOrDefault(f => f.Id.Equals(id));
            model.Ocjena = bodovi;
            _context.SaveChanges();
        }
    }
}