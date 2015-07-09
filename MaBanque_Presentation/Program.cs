using MaBanque_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MaBanque_Presentation
{
    class Program
    {
        static Banque<Compte> BanqueDivers;
        static Banque<CompteCourant> BanqueCourrant;
        static Banque<CompteEpargne> BanqueEpargne;

        static void Main(string[] args)
        {
            BanqueCourrant = new MaBanque_BL.Banque<MaBanque_BL.CompteCourant>();
            BanqueCourrant.AddCompte(new MaBanque_BL.CompteCourant("Florian"));
            BanqueCourrant.AddCompte(new MaBanque_BL.CompteCourant("Tosca"));
            BanqueCourrant.AddCompte(new MaBanque_BL.CompteCourant("Marco"));

            BanqueEpargne = new MaBanque_BL.Banque<MaBanque_BL.CompteEpargne>();
            BanqueEpargne.AddCompte(new MaBanque_BL.CompteEpargne("Florian"));
            BanqueEpargne.AddCompte(new MaBanque_BL.CompteEpargne("Abdallah"));

            BanqueDivers = new MaBanque_BL.Banque<MaBanque_BL.Compte>();
            BanqueDivers.AddCompte(new MaBanque_BL.CompteCourant("Christian"));
            BanqueDivers.AddCompte(new MaBanque_BL.CompteEpargne("steph"));

            BanqueCourrant["Florian"].Crediter(1500);
            BanqueCourrant[2].Crediter(2000);
            BanqueCourrant[3].Crediter(150);

            BanqueEpargne[4].Crediter(11000);
            BanqueEpargne[5].Crediter(800);

            BanqueDivers[6].Crediter(2000);

            List<Compte> cpts;
            IEnumerable<Compte> cptsCourant = BanqueCourrant.Where(x => x.Solde > 1000).Select(x=>x).ToList();
            cpts = cptsCourant.ToList();

            IEnumerable<Compte> cptsEpargne= BanqueEpargne.Where(x => x.Solde > 1000).Select(x => x).ToList();
            foreach (Compte item in cptsEpargne)
            {
                cpts.Add(item);
            }

            IEnumerable<Compte> cptsDivers = BanqueDivers.Where(x => x.Solde > 1000).Select(x => x).ToList();
            foreach (Compte item in cptsDivers)
            {
                cpts.Add(item);
            }

            IEnumerable<string> clientsList =
                cpts.OrderBy(c => c.Proprietaire).Select(c => c.Proprietaire).Distinct();


            Console.WriteLine("");
            Console.WriteLine("");

            foreach (var item in clientsList)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
