using System;
using System.Collections.Generic;
using System.Text;

namespace Station.Interfaces
{
    interface IStationnable
    {

        
        public void EnregistrerArriveePrevue(Object obj) { }
        public void EnregistrerArrivee(string a) { }
        public void EnregistrerDepart(string a) { }
        public Boolean EstAttendu(string a) { return true; }
        public Boolean EstPresent(string a) { return true; }
        public Boolean EstPresent(string a) { return true; }
        protected object GetUnAttendu(string a) { }
        protected object GetUnArrive(string a) { }
        protected object GetUnParti(string a) { }

    }
}
