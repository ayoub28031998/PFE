using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComptabilitePFE;

namespace ComptabilitePFE.Controllers
{
    public class PieceComptablesController : Controller
    {
        private I2S_Compta2Entities db = new I2S_Compta2Entities();

        // GET: PieceComptables
        public ActionResult Index()
        {
            return View(db.PieceComptable.ToList().Where(pc => pc.CodeSociete.Equals(Session["CodeSociete"].ToString())).ToList());
        }

        // GET: PieceComptables/Details/5
        public ActionResult Details(string id, string cs, string ce, string cj)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieceComptable pieceComptable = db.PieceComptable.ToList().SingleOrDefault(pc => pc.CodePiece.Equals(id) && pc.CodeSociete.Equals(cs) && pc.CodeExercice.Equals(ce) && pc.CodeJournal.Equals(cj));
            if (pieceComptable == null)
            {
                return HttpNotFound();
            }
            return View(pieceComptable);
        }

        // GET: PieceComptables/Create
        public ActionResult Create()
        {
            var ListJournals = new SelectList(db.Journal.ToList(), "CodeJournal", "Libelle");
            ViewData["ListJournals"] = ListJournals;
            PieceComptable pieceComptable = new PieceComptable();
            return View(pieceComptable);
        }

        // GET: PieceComptables/Edit/5
        public ActionResult Edit(string id, string cs, string ce, string cj)
        {
            PieceComptable pieceComptable = db.PieceComptable.Find(cs, id, cj, ce);
            var ListJournaux = db.Journal.ToList().Where(jr=>jr.CodeSociete.Equals(Session["CodeSociete"].ToString())).ToList();
            return View(new List<object> { pieceComptable, ListJournaux });
        }

        // POST: PieceComptables/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public String Edit(List<LignePieceComptable> lignes, PieceComptable piece)
        {
            try
            {
                var existingPiece = db.PieceComptable.Find(Session["CodeSociete"].ToString(), piece.CodePiece, piece.CodeJournal, Session["CodeExercice"].ToString());
                db.LignePieceComptable.RemoveRange(existingPiece.LignePieceComptables);
                db.SaveChanges();


                piece.CodeExercice = Session["CodeExercice"].ToString();
                piece.CodeSociete = Session["CodeSociete"].ToString();
                piece.NomUtilisateur = Session["NomUtilisateur"].ToString();
                piece.DateCreation = DateTime.Now;
                piece.HeureCreation = DateTime.Now;
                piece.LignePieceComptables.Clear();
                db.PieceComptable.AddOrUpdate(piece);

                lignes.ForEach(lpc =>
                {
                    lpc.CodeSociete = Session["CodeSociete"].ToString();
                    lpc.CodeExercice = Session["CodeExercice"].ToString();
                    lpc.CodeJournal = piece.CodeJournal;
                    lpc.CodePiece = piece.CodePiece;
                    db.LignePieceComptable.Add(lpc);
                });

                db.PieceComptable.AddOrUpdate(piece);
                db.SaveChanges();
                return "success";
            }
            catch (DbUpdateException)
            {
                return "lineexists";
            }
            catch
            {
                return "error";
            }
        }

        [HttpPost]
        public String Delete(string codePiece, string codeSociete, string codeExercice, string codeJournal)
        {
            try
            {
                PieceComptable pieceComptable = db.PieceComptable.Find(codeSociete, codePiece, codeJournal, codeExercice);
                db.LignePieceComptable.RemoveRange(pieceComptable.LignePieceComptables);
                db.PieceComptable.Remove(pieceComptable);
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
