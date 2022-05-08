//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComptabilitePFE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public string CodeClient { get; set; }
        public string RaisonSociale { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string MatriculeFiscale { get; set; }
        public string NbSociete { get; set; }
        public System.DateTime DateCreation { get; set; }
        public string Observation { get; set; }

        public override string ToString()
        {
            return $"Un nouveau compte client a été crée.{Environment.NewLine}" +
                $"" +
                $"Code client: {CodeClient}.{Environment.NewLine}" +
                $"Raison Sociale: {RaisonSociale}.{Environment.NewLine}" +
                $"Contact: {Contact}.{Environment.NewLine}" +
                $"Email: {Email}.{Environment.NewLine}" +
                $"Adresse: {Adresse}.{Environment.NewLine}" +
                $"Tel1: {Tel1}.{Environment.NewLine}" +
                $"Tel2: {Tel2}.{Environment.NewLine}" +
                $"Matricule Fiscale: {MatriculeFiscale}.{Environment.NewLine}" +
                $"Nb Societe: {NbSociete}.{Environment.NewLine}" +
                $"Date création: {DateCreation.ToString("dd/MM/yyyy")}.{Environment.NewLine}" +
                $"Observation: {Observation}.";
        }
    }
}
