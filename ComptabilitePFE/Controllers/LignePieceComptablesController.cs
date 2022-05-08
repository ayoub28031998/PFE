using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComptabilitePFE;

namespace ComptabilitePFE.Controllers
{
    public class LignePieceComptablesController : Controller
    {
        private I2S_Compta2Entities db = new I2S_Compta2Entities();

        // GET: LignePieceComptables
        public ActionResult Index()
        {
            var lignePieceComptable = db.LignePieceComptable.ToList().Where(lpc => lpc.CodeSociete.Equals(Session["CodeSociete"].ToString()));
            return View(lignePieceComptable.ToList());
        }

        // GET: LignePieceComptables/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LignePieceComptable lignePieceComptable = db.LignePieceComptable.Find(id);
            if (lignePieceComptable == null)
            {
                return HttpNotFound();
            }
            return View(lignePieceComptable);
        }

        // GET: LignePieceComptables/Create
        public ActionResult Create()
        {
            ViewBag.CodeSociete = new SelectList(db.PieceComptable, "CodeSociete", "LibelleEcriture");
            return View();
        }

        // POST: LignePieceComptables/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodeSociete,CodePiece,CodeJournal,CodeExercice,NumeroCompte,NumeroOrdre,Debit,Credit,Reference,DateReference,NumeroLettrage,NumeroRapprochement")] LignePieceComptable lignePieceComptable)
        {
            if (ModelState.IsValid)
            {
                db.LignePieceComptable.Add(lignePieceComptable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodeSociete = new SelectList(db.PieceComptable, "CodeSociete", "LibelleEcriture", lignePieceComptable.CodeSociete);
            return View(lignePieceComptable);
        }

        // GET: LignePieceComptables/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LignePieceComptable lignePieceComptable = db.LignePieceComptable.Find(id);
            if (lignePieceComptable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodeSociete = new SelectList(db.PieceComptable, "CodeSociete", "LibelleEcriture", lignePieceComptable.CodeSociete);
            return View(lignePieceComptable);
        }

        // POST: LignePieceComptables/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodeSociete,CodePiece,CodeJournal,CodeExercice,NumeroCompte,NumeroOrdre,Debit,Credit,Reference,DateReference,NumeroLettrage,NumeroRapprochement")] LignePieceComptable lignePieceComptable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lignePieceComptable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodeSociete = new SelectList(db.PieceComptable, "CodeSociete", "LibelleEcriture", lignePieceComptable.CodeSociete);
            return View(lignePieceComptable);
        }

        // GET: LignePieceComptables/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LignePieceComptable lignePieceComptable = db.LignePieceComptable.Find(id);
            if (lignePieceComptable == null)
            {
                return HttpNotFound();
            }
            return View(lignePieceComptable);
        }

        // POST: LignePieceComptables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LignePieceComptable lignePieceComptable = db.LignePieceComptable.Find(id);
            db.LignePieceComptable.Remove(lignePieceComptable);
            db.SaveChanges();
            return RedirectToAction("Index");
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
