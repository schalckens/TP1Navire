using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;

namespace NavireHeritage.ClassesMetiers
{
    class Port
    {
        private string nom;
        private string latitude;
        private Dictionary<String, Navire> navires = new Dictionary<String, Navire>();
        private List<Stockage> stockages = new List<Stockage>();

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
            try
            {
                if (this.navires.Count < this.NbNavireMax)
                {
                    this.navires.Add(navire.Imo, navire);
                }
                else
                {
                    throw new GestionPortException("Ajout imposible, le port est complet");
                }

            }
            catch (ArgumentException)
            {

                throw new GestionPortException("Le navire " + navire.Imo + " est déjà enregistré");
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
                throw new GestionPortException("Impossible d'enregister le navire " + imo + " , il n'est pas dans le port");
            }
        }

        public void AjoutStockage(Stockage stockage)
        {
            this.stockages.Add(stockage);
        }

        public Navire GetNavire(string imo)
        {
            if (this.navires.TryGetValue(imo, out Navire navire))
            {
                return navire;
            }
            else
            {
                return null;
            }
        }


        public void Dechargement(string imo)
        {

            Navire navire = GetNavire(imo);
            if (navire != null && navire.LibelleFret == "Porte-conteneurs")
            {
                int i = 0;
                while (i < this.stockages.Count && !navire.EstDecharge())
                {
                    if (this.stockages[i].CapaciteDispo >= 0 && this.stockages[i].CapaciteDispo > navire.QteFret)
                    {
                        navire.Decharger(navire.QteFret);
                        this.stockages[i].Stocker(navire.QteFret);
                    }
                    else
                    {
                        navire.Decharger(this.stockages[i].CapaciteDispo);
                        this.stockages[i].Stocker(this.stockages[i].CapaciteDispo);

                    }
                    i++;
                }
                if (navire.EstDecharge())
                {
                    Console.WriteLine("Le navire à bien été déchargé");
                }
                else
                {
                    throw new GestionPortException("Le navire " + navire.Imo + " n'a pas pu être entièrement déchargé, il reste " + navire.QteFret + " tonnes.");
                }
            }
            else
            {
                throw new GestionPortException("Impossible de décharger le navire " + imo + " il n'est pas dans le port ou n'est pas un porte-conteneurs.");

            }
        }

        public int NbNavireMax { get => nbNavireMax; }
        internal Dictionary<string, Navire> Navires { get => navires; }
    }
}
