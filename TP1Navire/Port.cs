using System;
using System.Collections.Generic;

namespace GestionNavire.Classesmetier
{
    class Port
    {
        private string nom;
        private int nbNavireMax = 5;
        private Dictionary<String,Navire> navires = new Dictionary<String,Navire>();

        /// <summary>
        /// Constructeur de la classe Port.
        /// </summary>
        /// <param name="nom"> nom du port </param>
        public Port(string nom)
        {
            this.nom = nom;
        }

        /// <summary>
        /// Méthode permettant d'enregistrer l'arrivee d'un navire de la classe Navire
        /// dans l'attribut navires d'un objet port de la classe Port.
        /// </summary>
        /// <param name="navire"> objet navire de la classe Navire </param>
        public void EnregistrerArrivee(Navire navire)
        {
            if (this.navires.Count < nbNavireMax)
            {
                this.navires.Add(navire.Imo,navire);
            }
            else
            {
                throw new Exception("Ajout imposible, le port est complet");
            }
        }

        public void EnregistrerDepart(string imo)
        {
            if (this.navires.ContainsKey(imo))
            {
                this.navires.Remove(imo);
            }
            else
            {
                throw new Exception("Impossible d'enregister le navire " + imo + " , il n'est pas dans le port");
            }    
        }
    }
}
