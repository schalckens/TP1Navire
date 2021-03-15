namespace GestionNavire.Classesmetier
{
    class Navire
    {
        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi)
        {
            this.Imo = imo;
            this.Nom = nom;
            this.LibelleFret = libelleFret;
            this.QteFretMaxi = qteFretMaxi;
        }
        public Navire(string imo, string nom):this(imo,nom,"Indéfini",0){}

        public override string ToString()
        {
            return "Identification"+ " : " + Imo.ToString() + "\nNom" + " : " + Nom.ToString() + "\nType de Frêt" + " : " + LibelleFret.ToString() + "\nQuantité de Frêt" + " : " + QteFretMaxi.ToString() + "\n-----------------------------------------------";
        }

        public string Imo { get; set; }
        public string Nom { get; set; }
        public string LibelleFret { get; set; }
        public int QteFretMaxi { get; set; }

    }
}
