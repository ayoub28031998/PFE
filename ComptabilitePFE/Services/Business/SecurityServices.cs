using ComptabilitePFE;
using PFEComptabilite.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFEComptabilite.Services.Business
{
    public class SecurityServices
    {
        SecurityDAO daoServices = new SecurityDAO();

        public string Authenticate(Utilisateur utilisateur)
        {
            return daoServices.FindByUser(utilisateur);
        }
        public ComptabilitePFE.Utilisateur AuthenticateName(Utilisateur utilisateur)
        {
            return daoServices.FindByUserName(utilisateur);
        }
        public ComptabilitePFE.Societe SocieteCode(Utilisateur utilisateur)
        {
            return daoServices.FindSocieteCodeByUserName(utilisateur);
        }

    }
}