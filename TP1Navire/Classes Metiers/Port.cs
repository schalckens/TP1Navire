﻿using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;

namespace GestionNavire.ClassesMetiers
{
    class Port
    {
        private string nom;
        private int nbNavireMax = 5;
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
                if (this.Navires.Count < this.NbNavireMax)
                {
                    this.Navires.Add(navire.Imo, navire);
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

            if (this.Navires.ContainsKey(imo))
            {
                this.Navires.Remove(imo);
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
                throw new Exception("");
            }
        }


        public void Dechargement(string imo)
        {
            Navire navire = GetNavire(imo);
            if (this.navires.ContainsKey(imo) && navire.LibelleFret == "Porte-conteneurs")
            {
                int i = 0;
                while (i < this.stockages.Count && navire.QteFret != 0)
                {
                    navire.Decharger(this.stockages[i].CapaciteDispo);
                    i++;
                }
                if (i < this.stockages.Count)
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
                throw new GestionPortException("Impossible de décharger le navire " + navire.Imo + " il n'est pas dans le port ou n'est pas un porte-conteneurs.");
            }
        }

        public int NbNavireMax { get => nbNavireMax; }
        internal Dictionary<string, Navire> Navires { get => navires; }
    }
}