using System;
using System.Collections.Generic;
using System.Text;

namespace NavireHeritage.ClassesMetiers
{
    class Passager
    {
        /// <summary>
        /// Numéro de passeport du passager
        /// </summary>
        private string numPasseport;
        /// <summary>
        /// Nom du passager
        /// </summary>
        private string nom;
        /// <summary>
        /// Prénom du passager
        /// </summary>
        private string prenom;
        /// <summary>
        /// Nationalité du passager
        /// </summary>
        private string nationalite;
        /// <summary>
        /// Constructeur permettant de valoriser les attributs de la classe.
        /// </summary>
        /// <param name="numPasseport"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="nationalite"></param>
        public Passager(string numPasseport, string nom, string prenom, string nationalite)
        {
            this.numPasseport = numPasseport;
            this.nom = nom;
            this.prenom = prenom;
            this.nationalite = nationalite;
        }

        public string NumPasseport { get => numPasseport;}
        public string Nom { get => nom; }
        public string Prenom { get => prenom;}
        public string Nationalite { get => nationalite;}
    }
}
