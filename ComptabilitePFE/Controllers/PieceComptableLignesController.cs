using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ComptabilitePFE.Controllers
{
    public class PieceComptableLignesController : Controller
    {
        private I2S_Compta2Entities db = new I2S_Compta2Entities();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        // GET: PieceComptableLignes
        public ActionResult Index()
        {
            var pieceComptables = db.PieceComptable.ToList().Where(pc => pc.CodeSociete.Equals(Session["CodeSociete"].ToString())).ToList();
            return View(pieceComptables);
        }

        public ActionResult Create()
        {
            var ListJournaux = db.Journal.ToList().Where(jr => jr.CodeSociete.Equals(Session["CodeSociete"].ToString())).ToList();
            
            return View(ListJournaux);
        }

        [HttpPost]
        public String Create(List<LignePieceComptable> lignes, PieceComptable piece)
        {
            try
            {
              
                piece.CodeExercice = Session["CodeExercice"].ToString();
                piece.CodeSociete = Session["CodeSociete"].ToString();
                piece.NomUtilisateur = Session["NomUtilisateur"].ToString();
                piece.DateCreation = DateTime.Now;
                piece.HeureCreation = DateTime.Now;
                piece.LignePieceComptables = lignes;
                decimal total = 0;
                piece.LignePieceComptables.ToList().ForEach(lpc =>
                {
                    lpc.CodeSociete = Session["CodeSociete"].ToString();
                    lpc.CodeExercice = Session["CodeExercice"].ToString();
                    lpc.CodeJournal = piece.CodeJournal;
                    lpc.CodePiece = piece.CodePiece;
                    total = total + lpc.Debit;
                });
                piece.TotalPiece = total;
                db.PieceComptable.Add(piece);
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
    }
}