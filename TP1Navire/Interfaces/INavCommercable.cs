using System;
using System.Collections.Generic;
using System.Text;

namespace Station.Interfaces
{
    interface INavCommercable
    {
        public void Decharger(int qteDecharge) { }
        public void Charger(int qteCharge) { }
    }
}
