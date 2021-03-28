using System;
using System.Collections.Generic;
using System.Text;

namespace NavireHeritage.ClassesMetiers
{
    class Tanker : Navire
    {
        /// <summary>
        /// Gaz liquide, pétrole, huile ...
        /// </summary>
        private string typeFluide;
        /// <summary>
        /// Constructeur permettant de valoriser les attributs de la classe mère et le type de fluide à bord du navire
        /// </summary>
        /// <param name="imo"></param>
        /// <param name="nom"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="tonnageDT"></param>
        /// <param name="tonnageDWT"></param>
        /// <param name="tonnageActuel"></param>
        /// <param name="typeFluide"></param>
        public Tanker(string imo, string nom, string latitude, string longitude, int tonnageDT, int tonnageDWT, int tonnageActuel,string typeFluide) : base(imo, nom, latitude, longitude, tonnageDT, tonnageDWT, tonnageActuel)
        {
            this.typeFluide = typeFluide;
        }
        /// <summary>
        /// Méthode qui met à jour le tonnage actuel du bateau avec la valeur passée en paramètre. La quantité passée en paramètre est enlevée à la quantité actuelle
        /// </summary>
        /// <param name="tonnageActuel"></param>
        public void Charger(int tonnageActuel)
        {
            TonnageActuel -= tonnageActuel;
        }
        /// <summary>
        /// Méthode qui met à jour le tonnage actuel du bateau avec la valeur passée en paramètre. La quantité passée en paramètre est ajoutée à la quantité actuelle
        /// </summary>
        /// <param name="tonnageActuel"></param>
        public void Decharger(int tonnageActuel)
        {
            TonnageActuel += tonnageActuel;
        }

        public string TypeFluide { get => typeFluide;}
    }
}
