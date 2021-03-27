using System;
using System.Collections.Generic;
using System.Text;

namespace Station.Interfaces
{
    class Istationnable
    {
        protected object GetUnAttendu(string a) { }
        public void EnregistrerArriveePrevue(Object obj) { }
        public void EnregistrerArrivee(string a) { }
        public void EnregistrerDepart(string a) { }
        public Boolean EstAttendu(string a) { return true; }
        public Boolean EstPresent(string a) { return true; }
        protected object GetUnArrive(string a) { }
        protected object GetUnParti(string a) { }

    }
}
