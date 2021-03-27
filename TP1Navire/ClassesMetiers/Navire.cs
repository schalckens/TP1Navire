using System.Text.RegularExpressions;
using System;
using GestionNavire.Exceptions;

namespace NavireHeritage.ClassesMetiers
{
    class Navire
    {
        private string imo;
        private string nom;
        private string libelleFret;
        private int qteFretMaxi;
        private int qteFret;

        public Navire(string imo, string nom, string libelleFret, int qteFretMaxi, int qteFret)
        {
            if (IsIMOValide(imo)) 
            {
                this.imo = imo;
            }
            else
            {
                throw new GestionPortException("Erreur : IMO non valide.");
            }
            this.nom = nom;
            this.libelleFret = libelleFret;
            this.QteFretMaxi = qteFretMaxi;

            if (qteFret >= 0 && qteFret <= this.QteFretMaxi)
            {
                this.qteFret = qteFret;
            }
            else
            {
                throw new GestionPortException("Valeur incohérente pour la quantité de fret stockée dans le navire");
            }
        }
        public Navire(string imo, string nom):this(imo,nom,"Indéfini",0,0){}

        public override string ToString()
        {
            return "Identification"+ " : " + Imo.ToString() + "\nNom" + " : " + Nom.ToString() + "\nType de Frêt" + " : " + LibelleFret.ToString() + "\nQuantité de Frêt" + " : " + QteFretMaxi.ToString() + "\n-----------------------------------------------";
        }

        public bool IsIMOValide(string imo) 
        {
            string prototypeIMO = "^IMO[0-9]{7}$";
            Match match = Regex.Match(imo, prototypeIMO);
            return match.Success;
        }

        public void Decharger(int quantite)
        {
            if(quantite >= 0 && quantite <= this.QteFret)
            {
                this.qteFret -= quantite;
            }
            else
            {
                if(quantite < 0)
                {
                    throw new GestionPortException("La quantité à décharger ne peut être négative");
                }
                else
                {
                    throw new GestionPortException("Impossible de décharger plus que la quantité de fret dans le navire");
                }
            }
        }
        public bool EstDecharge()
        {
            return this.qteFret == 0;
        }

        public string Imo { get => imo;}
        
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
                    throw new GestionPortException("Erreur, quantité de fret non valide");
                }
            } 
        }

        public int QteFret { get => qteFret;}
        public string Nom { get => nom; set => nom = value; }
        public string LibelleFret { get => libelleFret; }
    }
}
