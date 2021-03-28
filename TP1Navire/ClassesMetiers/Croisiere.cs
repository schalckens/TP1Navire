using GestionNavire.Exceptions;
using System.Collections.Generic;

namespace NavireHeritage.ClassesMetiers
{
    class Croisiere : Navire
    {
        private string typeNavireCroisiere;
        private int nbPassagersMaxi;
        private Dictionary<string, Passager> passagers;

        public Croisiere(string imo, string pnom, string platitude, string plongitude, int ptonnageDT, int ptonnageDWT, int ptonnageActuel, string typeNavireCroisiere, int nbPassagersMaxi) : base(imo, pnom, platitude, plongitude, ptonnageDT, ptonnageDWT, ptonnageActuel)
        {
            this.typeNavireCroisiere = typeNavireCroisiere;
            this.nbPassagersMaxi = nbPassagersMaxi;
        }
        public Croisiere(string imo, string pnom, string platitude, string plongitude, int ptonnageDT, int ptonnageDWT, int ptonnageActuel, string typeNavireCroisiere, int nbPassagersMaxi,Dictionary<string,Passager> passagers) : base(imo, pnom, platitude, plongitude, ptonnageDT, ptonnageDWT, ptonnageActuel)
        {
            this.typeNavireCroisiere = typeNavireCroisiere;
            this.nbPassagersMaxi = nbPassagersMaxi;
            this.passagers = passagers;
        }

        public void Embarquer(Dictionary<string,Passager> passagers2)
        {
            if(passagers2.Count < (nbPassagersMaxi - this.passagers.Count)) 
            {
                foreach(Passager passager in passagers2.Values)
                {
                    this.passagers.Add(passager.NumPasseport,passager);
                }
            }
            else
            {
                throw new GestionPortException("Le nombre de passager est supérieur à la capacité maximale, tous les passagers n'embarque pas.");
            }
        }
        public Dictionary<string,Passager> Debarquer(Dictionary<string, Passager> passagers2)
        {
            Dictionary<string, Passager> passagers3 = new Dictionary<string, Passager>();
            foreach(Passager passager in passagers2.Values)
            {
                if (this.passagers.ContainsKey(passager.NumPasseport))
                {
                    this.passagers.Remove(passager.NumPasseport);
                }
                else
                {
                    passagers3.Add(passager.NumPasseport, passager);
                }
            }

            return passagers3;
        }

        public string TypeNavireCroisiere { get => typeNavireCroisiere;}
        public int NbPassagersMaxi { get => nbPassagersMaxi; }
        internal Dictionary<string, Passager> Passagers { get => passagers; }
    }
}
