using GestionNavire.Exceptions;
using Station.Interfaces;
using System;
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
        private Dictionary<String,Passager> passagers;
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
            this.passagers = new Dictionary<String,Passager>();
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
            if (passagers.Count < (this.nbPassagersMaxi - this.passagers.Count))
            {
                this.passagers = passagers;
            }
        }
        /// <summary>
        /// Méthode qui met à jour la liste des passagers du bateau. Les passagers passés en paramètres doivent être ajoutés de la liste des passagers du navire. Une exception sera générée si le nombre de passagers dépasse le nombre de passagers maximum du navire. Aucun passager ne sera alors ajouté.
        /// </summary>
        /// <param name="passagers2"></param>
        public void Embarquer(List<Object> passagers2)
        {
            foreach(Passager passager in passagers2)
            {
                if (!this.passagers.ContainsKey(passager.NumPasseport))
                {
                    this.passagers.Add(passager.NumPasseport, passager);
                }
                else
                {
                    throw new GestionPortException("Le passager et déjà présent sur la liste");
                }
            }
        }
        /// <summary>
        /// Méthode qui met à jour la liste des passagers du bateau. Les passagers passés en paramètres doivent être retirés de la liste des passagers du navire. Cette méthode retourne la liste des passagers passés en paramètre et qui n'ont pas été trouvés dans la liste des passagers du navire.
        /// </summary>
        /// <param name="passagers2"></param>
        /// <returns></returns>
        public List<Object> Debarquer(List<Object> passagers2)
        {
            List<Object> absents = new List<Object>();
            foreach (Passager passager in passagers2)
            {
                if (this.passagers.ContainsKey(passager.NumPasseport))
                {
                    this.passagers.Remove(passager.NumPasseport);
                }
                else
                {
                    absents.Add(passager);
                }
            }
            return absents;
        }

        public string TypeNavireCroisiere { get => typeNavireCroisiere;}
        public int NbPassagersMaxi { get => nbPassagersMaxi; }
        internal Dictionary<string,Passager> Passagers { get => passagers; }
    }
}
