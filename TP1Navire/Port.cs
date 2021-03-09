using System;
using System.Collections.Generic;

namespace TP1Navire
{
    class Port
    {
        private string nom;
        private int nbNavireMax = 5;
        private List<Navire> navires = new List<Navire>();

        public Port(string nom)
        {
            this.nom = nom;
        }

        public void EnregistrerArrivee(Navire navire)
        {
            if (navires.Count < nbNavireMax)
            {
                this.navires.Add(navire);
            }
            else
            {
                Console.WriteLine("Ajout imposible, le port est complet");
            }
        }

        public void EnregistrerDepart(string imo)
        {
            if (EstPresent(imo))
            {
                navires.RemoveAt(RecupPosition(imo));
            }
            else
            {
                Console.WriteLine("Ce navire n'est pas dans ce port");
            }
        }
        public bool EstPresent(string imo)
        {
            foreach (Navire nav in navires)
            {

                if (nav.Imo == imo)
                {
                    return true;
                }
            }
            return false;
        }

        private int RecupPosition(string imo)
        {
            foreach (Navire nav in navires)
            {
                if (EstPresent(imo))
                {
                    return RecupPosition(nav);
                }
            }
            return -1;
        }
        private int RecupPosition(Navire navire)
        {
            return navires.IndexOf(navire);
        }

    }
}
