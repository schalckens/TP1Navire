using Station.Interfaces;

namespace NavireHeritage.ClassesMetiers
{
    class Cargo : Navire,INavCommercable
    {
        /// <summary>
        /// Chaine représentant le type de cargaison du bateau : denrées, périssables, matériel ...
        /// </summary>
        private string typeFret;
        /// <summary>
        /// Constructeur permettant de valoriser les attributs de la classe mère et le type de fret
        /// </summary>
        /// <param name="imo"></param>
        /// <param name="nom"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="tonnageDT"></param>
        /// <param name="tonnageDWT"></param>
        /// <param name="tonnageActuel"></param>
        /// <param name="typeFret"></param>
        public Cargo(string imo,string nom,string latitude,string longitude,int tonnageDT,int tonnageDWT,int tonnageActuel,string typeFret) : base(imo,nom,latitude,longitude,tonnageDT,tonnageDWT,tonnageActuel)
        {
            this.typeFret = typeFret;
        }
        public override string ToString()
        {
            return base.ToString() + "\n Type de Fret : " + typeFret;
        }
        /// <summary>
        /// Méthode qui met à jour le tonnage actuel du bateau avec la valeur passée en paramètre. La quantité passée en paramètre est enlevée à la quantité actuelle
        /// </summary>
        /// <param name="tonnageActuel"></param>
        public void Charger(int tonnageActuel)
        {
            TonnageActuel += tonnageActuel;
        }
        /// <summary>
        /// Méthode qui met à jour le tonnage actuel du bateau avec la valeur passée en paramètre. La quantité passée en paramètre est ajoutée à la quantité actuelle
        /// </summary>
        /// <param name="tonnageActuel"></param>
        public void Decharger(int tonnageActuel) 
        {
            TonnageActuel -= tonnageActuel;
        }

        public string TypeFret { get => typeFret;}

    }
}
