
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using PFEComptabilite.Services.Business;
using PFEComptabilite;
using System.Text;
using System.Runtime.Remoting.Contexts;
using ComptabilitePFE;
using ComptabilitePFE.Utilities;
using System.Configuration;

namespace PFEComptabilite.Controllers
{

    public class AuthentificationController : Controller
    {
        private I2S_Compta2Entities db = new I2S_Compta2Entities();

        // GET: /Authentification/Index
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            if (Session["CodeSociete"] != null)
            {
                return RedirectToAction("Index", "Home", new { returnUrl = "" });
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public String Index(Utilisateur utilisateur)
        {
            string success = "";
            SecurityServices securityservices = new SecurityServices();
            success = securityservices.Authenticate(utilisateur);
            Utilisateur utilisateurAuth = new Utilisateur();
            Societe Societe = new Societe();
            if (success == "authConnection")
            {
                utilisateurAuth = securityservices.AuthenticateName(utilisateur);

                Session["NomUtilisateur"] = utilisateurAuth.NomUtilisateur;
                Session["CodeClient"] = utilisateurAuth.CodeClient;
            }
            else
            {
                if (success == "errorConnectionMdp")
                    return "passwordError";

                else
                    return "usernameError";
            }
            return "success";
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Authentification", new { returnUrl = "" });
        }

        public ActionResult Register()
        {
            return View();
        }

        public JsonResult GetExercicesBySociete(String codeSociete)
        {
            var exercices = db.Exercice.Where(ex => ex.CodeSociete.Equals(codeSociete)).Select(ex => ex.CodeExercice);
            return Json(exercices, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult SelectSocieteEtExercice()
        {
            var societes = db.Societe.ToList().Where(soc => soc.CodeClient.Equals(Session["CodeClient"].ToString())).ToList();
            return PartialView(societes);
        }

        [HttpPost]
        public String RegisterUser(Client client)
        {
            try
            {
                var existingUser = db.Client.FirstOrDefault(cl => cl.CodeClient.Equals(client.CodeClient));
                if (existingUser != null)
                    return "exists";
                db.Client.Add(client);
                db.SaveChanges();
                Utilities.SendMail(ConfigurationManager.AppSettings["EmailDestinationAddress"], "Création d'un compte client", client.ToString());
                return "success";
            }
            catch
            {
                return "error";
            }
        }

        [HttpPost]
        public JsonResult AddSociete(Societe societe)
        {
            try
            {
                societe.CodeClient = Session["CodeClient"].ToString();
                var existingSociete = db.Societe.ToList().Where(soc => soc.CodeSociete.Equals(societe.CodeSociete) && soc.CodeClient.Equals(societe.CodeClient)).ToList();
                if (existingSociete.Count != 0)
                {
                    return Json("exists");
                }
                else
                {
                    db.Societe.Add(societe);
                    db.SaveChanges();
                    return Json(societe);
                }
            }
            catch
            {
                return Json("error");
            }
        }

        [HttpPost]
        public JsonResult AddExercice(Exercice exercice)
        {
            try
            {
                var existingExercice = db.Exercice.ToList().Where(ex => ex.CodeSociete.Equals(exercice.CodeSociete) && ex.CodeExercice.Equals(exercice.CodeExercice)).Count();
                if (existingExercice != 0)
                {
                    return Json("exists");
                }
                else
                {
                    db.Exercice.Add(exercice);
                    db.SaveChanges();
                    return Json(new { exercice.CodeExercice });
                }
            }
            catch
            {
                return Json("error");
            }
        }

        public ActionResult AuthenticateUser(String codeExercice, String codeSociete)
        {
            if(!String.IsNullOrEmpty(codeExercice) && !String.IsNullOrEmpty(codeSociete))
            {
                Session["CodeExercice"] = codeExercice;
                Session["CodeSociete"] = codeSociete;
                return RedirectToAction("index","home");
            }
            return View("index");
        }
    }
}