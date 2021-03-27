namespace NavireHeritage.ClassesMetiers
{
    class Cargo : Navire
    {
        private string typeFret;

        public Cargo(string imo,string nom,string latitude,string longitude,int tonnageDT,int tonnageDWT,int tonnageActuel,string typeFret) : base(imo,nom,latitude,longitude,tonnageDT,tonnageDWT,tonnageActuel)
        {
            this.typeFret = typeFret;
        }

        public void Charger(int tonnageActuel)
        {
            TonnageActuel -= tonnageActuel;
        }
        public void Decharger(int tonnageActuel) 
        {
            TonnageActuel += tonnageActuel;
        }

        public string TypeFret { get => typeFret;}

    }
}
