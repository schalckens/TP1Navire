using System;
using System.Collections.Generic;
using System.Text;

namespace NavireHeritage.ClassesMetiers
{
    class Stockage 
    {
        private int numero;
        private int capaciteMaxi;
        private int capaciteDispo;

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
