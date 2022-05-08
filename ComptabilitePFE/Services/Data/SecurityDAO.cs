using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ComptabilitePFE;

namespace PFEComptabilite.Services.Data
{
    public class SecurityDAO
    {
        private I2S_Compta2Entities db = new I2S_Compta2Entities();
        public Boolean authResponse;
        internal string FindByUser(Utilisateur utilisateur)
        {
            Utilisateur utilisateurAuth = db.Utilisateur.FirstOrDefault(s => s.MotPasse == utilisateur.MotPasse && s.NomUtilisateur == utilisateur.NomUtilisateur);
            var result = "errorConnection";
            if (utilisateurAuth != null)
            {
                result = "authConnection";
            }
            else
            {
                utilisateurAuth = db.Utilisateur.FirstOrDefault(s => s.MotPasse == utilisateur.MotPasse);//&& s.NomUtilisateur == utilisateur.NomUtilisateur);
                if (utilisateurAuth != null)
                {
                    result = "errorConnectionNom";
                    return (result);
                }
                utilisateurAuth = db.Utilisateur.FirstOrDefault(s => s.NomUtilisateur == utilisateur.NomUtilisateur);
                if (utilisateurAuth != null)
                {
                    result = "errorConnectionMdp";
                    return (result);
                }

            }
            return (result);

        }
        internal ComptabilitePFE.Utilisateur FindByUserName(Utilisateur utilisateur)
        {
            Utilisateur utilisateurAuth = db.Utilisateur.Find(utilisateur.NomUtilisateur);
            return (utilisateurAuth);

        }
        internal ComptabilitePFE.Societe FindSocieteCodeByUserName(Utilisateur utilisateur)
        {
            Societe societe = db.Societe.FirstOrDefault(s=>s.CodeClient.Contains(utilisateur.CodeClient));
            return (societe);

        }


    }
}