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
            Imo = imo;
            nom = pnom;
            Latitude = platitude;
            Longitude = plongitude;
            tonnageDT = ptonnageDT;
            tonnageDWT = ptonnageDWT;
            TonnageActuel = ptonnageActuel;

        }

        public string Imo 
        { 
            get => imo; 
            private set 
            { 

            } 
        }
        public static string Nom { get => nom;}
        public static string Latitude { get => latitude; set => latitude = value; }
        public static string Longitude { get => longitude; set => longitude = value; }
        public static int TonnageDT { get => tonnageDT}
        public static int TonnageDWT { get => tonnageDWT;}
        public static int TonnageActuel { get => tonnageActuel; set => tonnageActuel = value; }
    }
}
