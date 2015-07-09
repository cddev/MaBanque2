using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBanque_BL
{
   public  class CompteCourant :Compte
    {
        public CompteCourant(string proprietaire) : base(proprietaire)
        {
            Montantdecouvert = 0;
        }

        public CompteCourant(string proprietaire, double montantDecouvert)
            :this(proprietaire)
        {
            Montantdecouvert = montantDecouvert;
        }

        public double Montantdecouvert { get; private set; }

        public override bool Debiter(double montant)
        {
            if (montant<=Solde+Montantdecouvert)
            {
                Solde -= montant;
                return true;
            }
            return false;
        }
    }
}
