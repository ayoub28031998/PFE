using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComptabilitePFE;
using System.Data.Entity.Migrations;

namespace ComptabilitePFE.Controllers
{
    public class JournalsController : Controller
    {
        private I2S_Compta2Entities db = new I2S_Compta2Entities();


        // GET: Journals
        public ActionResult Index()
        {
            return View(db.Journal.ToList().Where(jr => jr.CodeSociete.Equals(Session["CodeSociete"].ToString())).ToList());
        }

        // GET: Journals/Details/5
        public ActionResult Details(string id, string cs)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal journal = db.Journal.Find(cs, id);
            if (journal == null)
            {
                return HttpNotFound();
            }

            return View(journal);
        }

        // GET: Journals/Create
        public ActionResult Create()
        {
            var ListComptes = db.PlanComptable.ToList().Where(pc => pc.CodeSociete.Equals(Session["CodeSociete"].ToString())).ToList();
            return View(ListComptes);
        }

        // POST: Journals/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public String Create(Journal journal)
        {
            try
            {
                if (String.IsNullOrEmpty(journal.NumeroCompte))
                    journal.NumeroCompte = String.Empty;
                journal.CodeSociete = Session["CodeSociete"].ToString();
                var existingJournal = db.Journal.Find(journal.CodeSociete, journal.CodeJournal);
                if (existingJournal != null)
                    return "exists";
                db.Journal.AddOrUpdate(journal);
                db.SaveChanges();
                return "success";
            }
            catch
            {
                return "error";
            }
        }

        public ActionResult Edit(string id, string cs)
        {
            var ListComptes = db.PlanComptable.ToList().Where(pc => pc.CodeSociete.Equals(Session["CodeSociete"].ToString())).ToList();
            Journal journal = db.Journal.Find(cs, id);
            return View(new List<object> { journal, ListComptes });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public String Edit(Journal journal)
        {
            try
            {
                if (String.IsNullOrEmpty(journal.NumeroCompte))
                    journal.NumeroCompte = String.Empty;
                journal.CodeSociete = Session["CodeSociete"].ToString();
                db.Journal.AddOrUpdate(journal);
                db.SaveChanges();
                return "success";
            }
            catch
            {
                return "error";
            }
        }

        // POST: Journals/Delete/5
        [HttpPost]
        public String Delete(string codeJournal, string codeSociete)
        {
            try
            {
                Journal journal = db.Journal.Find(codeSociete, codeJournal);
                db.Journal.Remove(journal);
                db.SaveChanges();
                return "success";
            }
            catch
            {
                return "error";
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
