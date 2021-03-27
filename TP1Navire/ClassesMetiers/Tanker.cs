using System;
using System.Collections.Generic;
using System.Text;

namespace NavireHeritage.ClassesMetiers
{
    class Tanker : Navire
    {
        private string typeFluide;

        public Tanker(string imo, string pnom, string platitude, string plongitude, int ptonnageDT, int ptonnageDWT, int ptonnageActuel,string typeFluide) : base(imo, pnom, platitude, plongitude, ptonnageDT, ptonnageDWT, ptonnageActuel)
        {
            this.typeFluide = typeFluide;
        }
        public void Charger(int tonnageActuel)
        {
            TonnageActuel -= tonnageActuel;
        }
        public void Decharger(int tonnageActuel)
        {
            TonnageActuel += tonnageActuel;
        }

        public string TypeFluide { get => typeFluide;}
    }
}
