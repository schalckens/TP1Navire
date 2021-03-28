using GestionNavire.Exceptions;
using System.Text.RegularExpressions;

namespace NavireHeritage.ClassesMetiers
{
    abstract class Navire
    {
        private static string imo;
        private static string nom;
        private static string latitude;
        private static string longitude;
        private static int tonnageDT;
        private static int tonnageDWT;
        private static int tonnageActuel;

        public Navire(string imo,string pnom,string platitude,string plongitude,int ptonnageDT,int ptonnageDWT,int ptonnageActuel)
        {
            if (IsIMOValide(imo))
            {
                this.imo = imo;
            }
            else
            {
                throw new GestionPortException("Erreur : IMO non valide.");
            }
            nom = pnom;
            Latitude = platitude;
            Longitude = plongitude;
            tonnageDT = ptonnageDT;
            tonnageDWT = ptonnageDWT;
            TonnageActuel = ptonnageActuel;

        }

        public override string ToString()
        {
            return "\n Identification : {0} \n Nom : {1} \n Coordonnées GPS : {2}N/ {3}", imo ,Nom,Latitude,Longitude;
        }

        public bool IsIMOValide(string imo)
        {
            string prototypeIMO = "^IMO[0-9]{7}$";
            Match match = Regex.Match(imo, prototypeIMO);
            return match.Success;
        }

        public string Imo { get => imo;}
        public static string Nom { get => nom;}
        public static string Latitude { get => latitude; set => latitude = value; }
        public static string Longitude { get => longitude; set => longitude = value; }
        public static int TonnageDT { get => tonnageDT}
        public static int TonnageDWT { get => tonnageDWT;}
        public static int TonnageActuel { get => tonnageActuel; set => tonnageActuel = value; }
    }
}
