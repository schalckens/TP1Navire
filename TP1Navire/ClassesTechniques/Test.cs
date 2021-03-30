using NavireHeritage.ClassesMetiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavireHeritage.ClassesTechniques
{
    public abstract class Test
    {
        public static void ChargementInitial(Port port)
        {
            //cargos
            port.EnregistrerArriveePrevue(new Cargo("IMO9780859","CMA CGM A. LINCOLN","43.43279 N","134.76258 W",140872,148992,123000,"marchandises diverses"));
            port.EnregistrerArriveePrevue(new Cargo("IMO9250098", "CONTAINERSHIPS VII", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "marchandises diverses"));
            port.EnregistrerArriveePrevue(new Cargo("IMO9502910", "MAERSK EMERALD", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "marchandises diverses"));

            //Croisiere
            port.EnregistrerArriveePrevue(new Croisiere("IMO9241061", "RMS QUEEN MARY 2", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "BFHQBS",500));
            port.EnregistrerArriveePrevue(new Croisiere("IMO9803613", "MSC GRANDIOSA", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "fnvjsb",500));
            port.EnregistrerArriveePrevue(new Croisiere("IMO9351476", "CRUISE ROMA", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "mfqsdufjnh",500));

            //Tanker
            port.EnregistrerArriveePrevue(new Tanker("IMO9334076", "EJNAN", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "FGSD"));
            port.EnregistrerArriveePrevue(new Tanker("IMO9380374", "CITRUS", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "FBDSF"));
            port.EnregistrerArriveePrevue(new Tanker("IMO9220952", "HARAD", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "GBSDB"));
            port.EnregistrerArriveePrevue(new Tanker("IMO9197832", "KALAMOS", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "BBGSDB"));
            port.EnregistrerArriveePrevue(new Tanker("IMO9379715", "NEW DRAGON", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "BSBSFSGB"));
        }
        public static void AfficheAttendus(Port port)
        {
            foreach(Navire navire in port.NavireAttendus.Values)
            {
                Console.WriteLine(navire);
            }
        }
        public static void TestEnregistrerArriveePrevue(Port port, Navire navire)
        {
            try
            {
                port.EnregistrerArriveePrevue(navire);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
