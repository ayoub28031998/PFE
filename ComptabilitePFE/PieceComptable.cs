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
    
    public partial class PieceComptable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PieceComptable()
        {
            this.LignePieceComptables = new HashSet<LignePieceComptable>();
        }
    
        public string CodeSociete { get; set; }
        public string CodePiece { get; set; }
        public string CodeJournal { get; set; }
        public string CodeExercice { get; set; }
        public System.DateTime DateEcriture { get; set; }
        public decimal TotalPiece { get; set; }
        public string LibelleEcriture { get; set; }
        public string NomUtilisateur { get; set; }
        public System.DateTime DateCreation { get; set; }
        public System.DateTime HeureCreation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LignePieceComptable> LignePieceComptables { get; set; }
    }
}
