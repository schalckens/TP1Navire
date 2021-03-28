using System;
using System.Collections.Generic;
using System.Text;

namespace NavireHeritage.ClassesMetiers
{
    class Stockage 
    {
        /// <summary>
        /// Identifiant du stockage.
        /// </summary>
        private int numero;
        /// <summary>
        /// Capacité de tonnage maximum du stockage
        /// </summary>
        private int capaciteMaxi;
        /// <summary>
        /// Capacité disponible du stockage
        /// </summary>
        private int capaciteDispo;
        /// <summary>
        /// Constructeur permettant de valoriser les attributs numero et capaciteMaxi . La capaciteDispo sera valorisée à capaciteMaxi
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="capaciteMaxi"></param>
        public Stockage(int numero, int capaciteMaxi)
        {
            this.numero = numero;
            this.capaciteMaxi = capaciteMaxi;
            this.capaciteDispo = capaciteMaxi;
        }

        public int Numero { get => numero; }
        public int CapaciteMaxi { get => capaciteMaxi; set => capaciteMaxi = value; }
        public int CapaciteDispo { get => capaciteDispo; set => capaciteDispo = value; }
    }
}
