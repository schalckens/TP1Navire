using GestionNavire.Exceptions;
using System.Collections.Generic;

namespace NavireHeritage.ClassesMetiers
{
    class Croisiere : Navire
    {
        /// <summary>
        /// V : voilier ; M : moteur
        /// </summary>
        private string typeNavireCroisiere;
        /// <summary>
        /// Nombre de passager maximum que peut embarquer un navire
        /// </summary>
        private int nbPassagersMaxi;
        /// <summary>
        /// Dictionnaire d'objets de la classe Passager identifiés par leur numéro de passeport. Représente les personnes croisiéristes à bord du bateau
        /// </summary>
        private Dictionary<string, Passager> passagers;
        /// <summary>
        /// Constructeur permettant de valoriser les attributs de la classe mère, le type de navire de croisère et le nombre de passagers maximum
        /// </summary>
        /// <param name="imo"></param>
        /// <param name="pnom"></param>
        /// <param name="platitude"></param>
        /// <param name="plongitude"></param>
        /// <param name="ptonnageDT"></param>
        /// <param name="ptonnageDWT"></param>
        /// <param name="ptonnageActuel"></param>
        /// <param name="typeNavireCroisiere"></param>
        /// <param name="nbPassagersMaxi"></param>
        public Croisiere(string imo, string pnom, string platitude, string plongitude, int ptonnageDT, int ptonnageDWT, int ptonnageActuel, string typeNavireCroisiere, int nbPassagersMaxi) : base(imo, pnom, platitude, plongitude, ptonnageDT, ptonnageDWT, ptonnageActuel)
        {
            this.typeNavireCroisiere = typeNavireCroisiere;
            this.nbPassagersMaxi = nbPassagersMaxi;
        }
        /// <summary>
        /// Constructeur surchage permettant en plus de charger une liste de passagers
        /// </summary>
        /// <param name="imo"></param>
        /// <param name="pnom"></param>
        /// <param name="platitude"></param>
        /// <param name="plongitude"></param>
        /// <param name="ptonnageDT"></param>
        /// <param name="ptonnageDWT"></param>
        /// <param name="ptonnageActuel"></param>
        /// <param name="typeNavireCroisiere"></param>
        /// <param name="nbPassagersMaxi"></param>
        /// <param name="passagers"></param>
        public Croisiere(string imo, string pnom, string platitude, string plongitude, int ptonnageDT, int ptonnageDWT, int ptonnageActuel, string typeNavireCroisiere, int nbPassagersMaxi,Dictionary<string,Passager> passagers) : base(imo, pnom, platitude, plongitude, ptonnageDT, ptonnageDWT, ptonnageActuel)
        {
            this.typeNavireCroisiere = typeNavireCroisiere;
            this.nbPassagersMaxi = nbPassagersMaxi;
            this.passagers = passagers;
        }
        /// <summary>
        /// Méthode qui met à jour la liste des passagers du bateau. Les passagers passés en paramètres doivent être ajoutés de la liste des passagers du navire. Une exception sera générée si le nombre de passagers dépasse le nombre de passagers maximum du navire. Aucun passager ne sera alors ajouté.
        /// </summary>
        /// <param name="passagers2"></param>
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
        /// <summary>
        /// Méthode qui met à jour la liste des passagers du bateau. Les passagers passés en paramètres doivent être retirés de la liste des passagers du navire. Cette méthode retourne la liste des passagers passés en paramètre et qui n'ont pas été trouvés dans la liste des passagers du navire.
        /// </summary>
        /// <param name="passagers2"></param>
        /// <returns></returns>
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
