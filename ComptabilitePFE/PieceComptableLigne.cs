using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComptabilitePFE
{
    public class PieceComptableLigne
    {
        public IList<LignePieceComptable> lignePieceComptables { get; set; }
        public PieceComptable pieceComptable { get; set; }
    }
}