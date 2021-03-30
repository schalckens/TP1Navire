using GestionNavire.Exceptions;
using System.Text.RegularExpressions;

namespace NavireHeritage.ClassesMetiers
{
    public abstract class Navire
    {
        /// <summary>
        /// Numéro IMO du bateau sous la forme IMO9999999
        /// </summary>
        protected static string imo;
        /// <summary>
        /// Nom du navire
        /// </summary>
        protected static string nom;
        /// <summary>
        /// Position mise à jour à intervalles réguliers par un programme externe
        /// </summary>
        protected static string latitude;
        /// <summary>
        /// Position mise à jour à intervalles réguliers par un programme externe
        /// </summary>
        protected static string longitude;
        /// <summary>
        /// Tonnage du bateau (volume total m²)
        /// </summary>
        protected static int tonnageDT;
        /// <summary>
        /// Hargement maximal que peut embarquer un navire. Il comprend le personnel, les consommables (nourriture, fluides,...) et la cargaison.
        /// </summary>
        protected static int tonnageDWT;
        /// <summary>
        /// Partie du tonnage du bateau actuellement utilisée. Il est exprimé en tonnaux
        /// </summary>
        protected static int tonnageActuel;
        /// <summary>
        /// Constructeur permettant d'initialiser respectivement les attributs imo,latitude,longitude,nom,tonnageActuel,tonnageDT,tonnageDWT
        /// </summary>
        /// <param name="imo"> Matricule du navire</param>
        /// <param name="pnom"> Nom du navire </param>
        /// <param name="platitude">Position du navire(latitude)</param>
        /// <param name="plongitude">Position du navire(latitude)</param>
        /// <param name="ptonnageDT">Tonnage du navire</param>
        /// <param name="ptonnageDWT">Hargement maximal du navire </param>
        /// <param name="ptonnageActuel"> partie du tonnage utilisée du navire</param>
        public Navire(string imo,string pnom,string platitude,string plongitude,int ptonnageDT,int ptonnageDWT,int ptonnageActuel)
        {
            if (IsIMOValide(imo))
            {
                this.Imo = imo;
            }
            else
            {
                throw new GestionPortException("Erreur : IMO non valide.");
            }
            nom = pnom;
            Latitude = platitude;
            Longitude = plongitude;
            if (ptonnageDT > 0 && ptonnageDWT > 0) { tonnageDT = ptonnageDT; tonnageDWT = ptonnageDWT; }
            TonnageActuel = ptonnageActuel;

        }

        /// <summary>
        /// Regex pour  que l'IMO soit soit valide
        /// </summary>
        /// <param name="imo"> Matricule du navire à tester</param>
        /// <returns> True si l'IMo du navire est valide </returns>
        public bool IsIMOValide(string imo)
        {
            string prototypeIMO = "^IMO[0-9]{7}$";
            Match match = Regex.Match(imo, prototypeIMO);
            return match.Success;
        }
        public override string ToString()
        {
            return "\n Numéro IMO : "+ Imo +"\n Nom : "+ Nom + "\n Coordonnées GPS : " + Latitude + "N / " + Longitude + "E \n TonnageDT : " + tonnageDT + "\n TonnageDWT : " + tonnageDWT + "\n Tonnage Actuel : " + TonnageActuel;
        }
        public string Imo { get => imo; private set { imo = value; } }
        public string Nom { get => nom;}
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public int TonnageDT { get => tonnageDT; }
        public int TonnageDWT { get => tonnageDWT;}
        public int TonnageActuel 
        { 
            get => tonnageActuel; 
            protected set 
            { 
                if (value>0 && value <= tonnageDWT)
                {
                    tonnageActuel = value;
                }
                else
                {
                    if (value < 0)
                    {
                        throw new GestionPortException("Impossible d'avoir un tonnage négatif");
                    }
                    else
                    {
                        throw new GestionPortException("Impossible d'avoir un tonnage supérieur à la capacité macimal du navire");
                    }
                }
            } 
        }
    }
}
