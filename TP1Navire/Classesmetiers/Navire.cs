using System.Text.RegularExpressions;

namespace GestionNavire.Classesmetier
{
    class Navire
    {
        private string imo;
        private string nom;
        private string libelleFret;
        private int qteFretMaxi;

        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi)
        {
            if (IsIMOValide(imo)) 
            {
                this.imo = imo;
            }
            else
            {
                throw new System.Exception("Erreur : IMO non valide.");
            }
            this.nom = nom;
            this.libelleFret = libelleFret;
            this.QteFretMaxi = qteFretMaxi;
        }
        public Navire(string imo, string nom):this(imo,nom,"Indéfini",0){}

        public override string ToString()
        {
            return "Identification"+ " : " + Imo.ToString() + "\nNom" + " : " + Nom.ToString() + "\nType de Frêt" + " : " + LibelleFret.ToString() + "\nQuantité de Frêt" + " : " + QteFretMaxi.ToString() + "\n-----------------------------------------------";
        }

        public bool IsIMOValide(string imo) 
        {
            string prototypeIMO = @"IMO\d{7}$";
            Match match = Regex.Match(imo, prototypeIMO);
            return match.Success;
        }

        public string Imo { get => imo;}
        public string Nom { get; set; }
        public string LibelleFret { get; set; }
        public int QteFretMaxi 
        { 
            get => qteFretMaxi; 
            set 
            { 
                if (value >= 0 )
                {
                    this.qteFretMaxi = value;
                }
                else
                {
                    throw new System.Exception("Erreur, quantité de fret non valide");
                }
            } 
        }

    }
}
