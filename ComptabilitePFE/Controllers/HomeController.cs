using System;
using System.Web.Mvc;

namespace PFEComptabilite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(String codeSociete, String codeExercice)
        {
            if (Session["CodeSociete"] == null)
            {
                return RedirectToAction("Index", "Authentification", new { returnUrl = "" });
            }
            return View();
        }
    }
}