using GestionNavire.Exceptions;
using Station.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NavireHeritage.ClassesMetiers
{
    class Croisiere : Navire,ICroisierable
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
        private List<Passager> passagers;
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
            this.passagers = new List<Passager>();
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
        public Croisiere(string imo, string pnom, string platitude, string plongitude, int ptonnageDT, int ptonnageDWT, int ptonnageActuel, string typeNavireCroisiere, int nbPassagersMaxi,List<Passager> passagers) : base(imo, pnom, platitude, plongitude, ptonnageDT, ptonnageDWT, ptonnageActuel)
        {
            this.typeNavireCroisiere = typeNavireCroisiere;
            this.nbPassagersMaxi = nbPassagersMaxi;
            this.passagers = passagers;
        }
        /// <summary>
        /// Méthode qui met à jour la liste des passagers du bateau. Les passagers passés en paramètres doivent être ajoutés de la liste des passagers du navire. Une exception sera générée si le nombre de passagers dépasse le nombre de passagers maximum du navire. Aucun passager ne sera alors ajouté.
        /// </summary>
        /// <param name="passagers2"></param>
        public void Embarquer(List<Passager> passagers2)
        {
            if(passagers2.Count < (nbPassagersMaxi - this.passagers.Count)) 
            {
                this.passagers.Union(passagers2);
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
        public List<Passager> Debarquer(List<Passager> passagers2)
        {
            List<Passager> passagers3 = new List<Passager>();
            foreach(Passager passager in passagers2)
            {
                if (this.passagers.Contains(passager))
                {
                    this.passagers.Remove(passager);
                }
                else
                {
                    passagers3.Add(passager);
                }
            }

            return passagers3;
        }

        public string TypeNavireCroisiere { get => typeNavireCroisiere;}
        public int NbPassagersMaxi { get => nbPassagersMaxi; }
        internal Dictionary<string, Passager> Passagers { get => passagers; }
    }
}
