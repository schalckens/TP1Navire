using System;
using NavireHeritage.ClassesMetiers;
using GestionNavire.Exceptions;
using NavireHeritage.ClassesTechniques;

namespace NavireHeritage
{
    class Program
    {
        static void Main()
        {
            try
            {
                Port port = new Port("Marseille", "43.2976N", "5.3471E", 4, 3, 2, 4);
                //Test.ChargementInitial(port);
                //Console.WriteLine(port);
                //Test.AfficheAttendus(port);
                Test.TestEnregistrerArriveePrevue(port,new Cargo("IMO9780859","CMA CGM A. LINCOLN","43.43279 N","134.76258 W",140872,148992,123000,"marchandises diverses"));
            }
            catch (GestionPortException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

    }
}
