using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComptabilitePFE;

namespace ComptabilitePFE.Controllers
{
    public class PlanComptablesController : Controller
    {
        private I2S_Compta2Entities db = new I2S_Compta2Entities();

        // GET: PlanComptables
        public ActionResult Index()
        {
            return View(db.PlanComptable.ToList().Where(pc => pc.CodeSociete.Equals(Session["CodeSociete"].ToString())).ToList());
        }

        // GET: PlanComptables/Details/?id=5&ns=5
        public ActionResult Details(string id, string cs)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanComptable planComptable = db.PlanComptable.Find(cs, id);
            if (planComptable == null)
            {
                return HttpNotFound();
            }
            return View(planComptable);
        }

        // GET: PlanComptables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanComptables/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public String Create(PlanComptable planComptable)
        {
            try
            {
                if (Session["CodeSociete"] == null)
                {
                    return "errorr";
                }

                planComptable.CodeSociete = Session["CodeSociete"].ToString();
                var existingPlanComptable = db.PlanComptable.Find(planComptable.CodeSociete, planComptable.NumeroCompte);
                if (existingPlanComptable != null)
                {
                    return "exists";
                }
                db.PlanComptable.Add(planComptable);
                db.SaveChanges();
                return "success";

            }
            catch
            {
                return "error";
            }
        }

        // GET: PlanComptables/Edit/5/4
        public ActionResult Edit(string id, string cs)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanComptable planComptable = db.PlanComptable.Find(cs, id);
            if (planComptable == null)
            {
                return HttpNotFound();
            }
            return View(planComptable);
        }


        // POST: PlanComptables/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public String Edit(PlanComptable planComptable)
        {
            try
            {
                planComptable.CodeSociete = Session["CodeSociete"].ToString();
                db.PlanComptable.AddOrUpdate(planComptable);
                db.SaveChanges();
                return "success";
            }
            catch
            {
                return "error";
            }
        }

        [HttpPost]
        public String Delete(string numeroCompte, string codeSociete)
        {
            try
            {
                PlanComptable planComptable = db.PlanComptable.Find(codeSociete, numeroCompte);
                db.PlanComptable.Remove(planComptable);
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
