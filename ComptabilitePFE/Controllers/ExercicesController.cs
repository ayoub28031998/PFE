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
    public class ExercicesController : Controller
    {
        private I2S_Compta2Entities db = new I2S_Compta2Entities();

        // GET: Exercices
        public ActionResult Index()
        {
            return View(db.Exercice.ToList().Where(ex => ex.CodeSociete.Equals(Session["CodeSociete"].ToString())).ToList());
        }

        // GET: Exercices/Details/5
        public ActionResult Details(string id, string cs)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercice.Find(cs, id);
            if (exercice == null)
            {
                return HttpNotFound();
            }

            return View(exercice);
        }

        // GET: Exercices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exercices/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public String Create(Exercice exercice)
        {
            try
            {
                exercice.CodeSociete = Session["CodeSociete"].ToString();
                var existingExercice = db.Exercice.FirstOrDefault(ex => ex.CodeSociete.Equals(exercice.CodeSociete) && ex.CodeExercice.Equals(exercice.CodeExercice));
                if (existingExercice != null)
                    return "exists";
                db.Exercice.Add(exercice);
                db.SaveChanges();
                return "success";
            }
            catch
            {
                return "error";
            }
        }

        // GET: Exercices/Edit/5
        public ActionResult Edit(string id, string cs)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercice exercice = db.Exercice.Find(cs, id);
            if (exercice == null)
            {
                return HttpNotFound();
            }
            return View(exercice);
        }

        // POST: Exercices/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public String Edit(Exercice exercice)
        {
            try
            {
                exercice.CodeSociete = Session["CodeSociete"].ToString();
                db.Exercice.AddOrUpdate(exercice);
                db.SaveChanges();
                return "success";
            }
            catch
            {
                return "error";
            }
        }

        // POST: Exercices/Delete/5
        [HttpPost, ActionName("Delete")]
        public String Delete(string codeExercice, string codeSociete)
        {
            try
            {
                Exercice exercice = db.Exercice.Find(codeSociete, codeExercice);
                db.Exercice.Remove(exercice);
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