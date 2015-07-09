using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace MaBanque_BL
{
    public class Banque <TCompte> : IEnumerable<TCompte> where TCompte: Compte
    {
        #region Constructeurs
        public Banque()
        {
            isAudit = false;
            Comptes = new List<TCompte>();
        }
        #endregion

        #region Propriétés
        public List<TCompte> Comptes { get; private set; }
        
        public string Nom { get; set; }
        #endregion

        #region Méthodes Métiers
        public void AddCompte(TCompte compte)
        {
            Comptes.Add(compte);
        }


        private bool isAudit;

        public void ChangerAudit()
        {
            if (!isAudit)
            {
                isAudit = true;
                foreach (TCompte cpte in Comptes)
                {
                    cpte.MonAudit += Cpte_MonAudit;
                }
            }
            else
            {
                isAudit = false;
                foreach (TCompte cpte in Comptes)
                {
                    cpte.MonAudit -= Cpte_MonAudit;

                }
            }
        }

        private void Cpte_MonAudit(object sender, MonAuditEventArgs e)
        {
            if (File.Exists(@"c:\temp\Audit.bak"))
            {
                StreamWriter writer = File.AppendText(@"c:\temp\Audit.bak");
                writer.WriteLine("Num Cpte :" + e.NumCpte + ", " + e.Description);
                writer.Close();
            }
        }
        #endregion

        #region Indexeur
        public TCompte this[int index]
        {
            get
            {
                return Comptes.Find(cpt => cpt.Numero==index);
                //return Comptes.Where(cpt => cpt.Numero == index).Select(cpt => cpt).FirstOrDefault();
            }
        }

        public TCompte this[string index]
        {
            get { return Comptes.Find(cpt => cpt.Proprietaire == index); }
        }
        #endregion


        public IEnumerator<TCompte> GetEnumerator()
        {
            return Comptes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
