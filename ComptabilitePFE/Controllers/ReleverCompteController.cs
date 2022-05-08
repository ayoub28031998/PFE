using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComptabilitePFE.Views
{
    public class ReleverCompteController : Controller
    {
        private I2S_Compta2Entities db = new I2S_Compta2Entities();
        // GET: RelevéCompte
        public ActionResult Index()
        {
            var ListJournaux = db.Journal.ToList().Where(jr => jr.CodeSociete.Equals(Session["CodeSociete"].ToString())).ToList();
            return View(ListJournaux);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListRelever()
        {

            var datedu = Request["dateDeb"];
            var dateFin = Request["dateFin"];
            var CodeJournal = Request["CodeJournal"];




            var releverCompte = (from lpc in db.LignePieceComptable

                                 join pc in db.PieceComptable on lpc.CodePiece equals pc.CodePiece

                                 into pcl

                                 from prod1 in pcl

                                 where prod1.CodeJournal == CodeJournal

                                 select prod1).ToList();





            List<PieceComptable> Relever = new List<PieceComptable>();

            foreach (var item in releverCompte)

            {

                Relever.Add(db.PieceComptable.Find(item.CodePiece));

            }

            ViewData["relever"] = Relever;
            return View(releverCompte);
        }
    }
}