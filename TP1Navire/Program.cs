using System;
using GestionNavire.Classesmetier;

namespace GestionNavire.Application
{
    class Program
    {
        static void Main()
        {
            try
            {
                Instanciations();
                //TesterEnregistrerArrivee();
                //TesterEnregistrerDepart();
                Console.WriteLine("--Fin normale du programme--");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.ReadKey(); }
            
            
        }
        /// <summary>
        /// Méthode permettant de Tester l'instanciation d'un nouveau navire de la classe Navire.
        /// </summary>
        public static void Instanciations()
        {
            try
            {
                Navire navire = new Navire("IMO9427639","Copper Spirit","Hydrocarbures",156827);
                navire = new Navire("IMO9839272", "MSC Isabella","Porte-conteneurs",197500);
                navire = new Navire("IMO8715871", "MSC PILAR", "Porte-conteneurs", 67183);
                navire = new Navire("XMO9235232", "FORTUNE TRADER", "Cargo", 74750);
                navire = new Navire("IMO9574004", "TRITON SEAHAWK", "Hydrocarbures", 51201);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
        /// <summary>
        /// Méthode permettant de tester l'enregistrement de l'arrivée d'un 
        /// navire de la classe Navire dans l'attribut de navires d'un port de la classe Port.
        /// </summary>
        public static void TesterEnregistrerArrivee()
        {
            try
            {
                Port port = new Port("Premier Port");
                port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
                port.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
                port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
                //port.EnregistrerArrivee(new Navire("IMO9552149", "MSC Bastien"));
                //port.EnregistrerArrivee(new Navire("IMO9554589", "MSC Emilou"));
                //port.EnregistrerArrivee(new Navire("IMO9457149", "MSC Julien"));
                //port.EnregistrerArrivee(new Navire("IMO9852149", "MSC Pastaga"));
                Console.WriteLine("Navires bien enregistrés dans le port");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        
        /// <summary>
        /// Méthode permettant de tester l'enregistrement du départ d'un 
        /// navire de la classe Navire dans l'attribut de navires d'un port de la classe Port.
        /// </summary>
        public static void TesterEnregistrerDepart()
        {
            try
            {
                Port port = new Port("Toulon");
                port.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
                port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
                port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
                port.EnregistrerDepart("IMO8715871");
                Console.WriteLine("Depart du navire IMO8715871 enregistré");
                port.EnregistrerDepart("IMO1111111");
                Console.WriteLine("Depart du navire IMO1111111 enregistré");
                Console.WriteLine("Fin des enregistrements des départs");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            
        }
    }
}
