using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBanque_BL
{
    public enum TypeTransaction {Debit, Credit }

    public class Transaction
    {
        public DateTime Date { get; private set; }
        public double Montant { get; private set; }
        public TypeTransaction Type { get; private set; }

        public Transaction(double montant, TypeTransaction type)
        {
            Montant = montant;
            Type = type;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("Le montant {0} a été porté au {1} le {2}",
                Montant.ToString(), Type, Date.ToLongDateString());
        }

    }
}