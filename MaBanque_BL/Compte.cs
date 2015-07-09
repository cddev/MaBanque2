using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBanque_BL
{
    public abstract class Compte
    {
        public static int DernierNumero { get; private set; }
        public int Numero { get; private set; }
        public double Solde { get; protected set; }
        public string Proprietaire { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public event MonAuditEventHandler MonAudit;

        public Compte(string proprietaire)
        {
            Numero = DernierNumero + 1;
            DernierNumero = Numero;
            Proprietaire = proprietaire;
            Transactions = new List<Transaction>();
        }

        public Compte (string proprietaire, double solde):this(proprietaire)
        {
            Solde = solde;
            
        }

        public void Crediter(double montant)
        {
            Solde += montant;
            Transaction trans = new Transaction(montant, TypeTransaction.Debit);
            Transactions.Add(trans);
            OnMonAudit(trans);
        }

        public void Crediter(double montant, Compte Crediteur)
        {
            if (Crediteur.Debiter(montant))
            {
                this.Crediter(montant);
                
            }
        }

        public virtual bool Debiter(double montant)
        {
            bool reussite = false;
            if (montant<=Solde)
            {
                Solde -= montant;
                reussite = true;
                Transaction trans = new Transaction(montant, TypeTransaction.Debit);
                Transactions.Add(trans);
                OnMonAudit(trans);
            }
            return reussite;
        }

        public bool Debiter(double montant, Compte Destinataire)
        {
            if (Debiter(montant))
            {
                Destinataire.Crediter(montant);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("Solde du compte de {1} est de : {0}",
                Solde, Proprietaire);
        }

        private void OnMonAudit(Transaction trans)
        {
            if (MonAudit!=null)
            {
                MonAudit(this, new MonAuditEventArgs(this.Numero,trans.ToString()));
            }
        }

    }
}
