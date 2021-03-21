using System;
using GestionNavire.Classesmetier;
using GestionNavire.Exceptions;

namespace GestionNavire.Application
{
    class Program
    {
        private static Port port;
        static void Main()
        {
            try
            {
                port = new Port("Toulon");
                //Instanciations();
                try
                {
                    TesterEnregistrerArrivee();
                }
                catch (GestionPortException ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
                try
                {
                    TesterEnregistrerArriveeV2();
                }
                catch (GestionPortException ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
                try
                {
                    TesterEnregistrerDepart();
                }
                catch (GestionPortException ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
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
            catch (GestionPortException ex)
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
            Navire navire = null;
            try
            {
                navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
                port.EnregistrerArrivee(navire);
                navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
                port.EnregistrerArrivee(navire);
            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void TesterEnregistrerArriveeV2()
        {
            Navire navire = null;
            try
            {
                port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isbella", "porte-conteneurs", 197500));
                port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
                port.EnregistrerArrivee(new Navire("IMO9235232", "FORTUNE TRADER", "Cargo", 74750));
                port.EnregistrerArrivee(new Navire("IMO9405423", "SERENEA", "tANKER", 158583));
                port.EnregistrerArrivee(new Navire("IMO9574004", "TRITON SEAHAWK", "Hydrocarbures", 51201));
                port.EnregistrerArrivee(new Navire("IMO9748681", "NORDIC SPACE", "Tankers", 157587));

            }
            catch (GestionPortException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException)
            {
                throw new GestionPortException("Le navire" + navire.Imo + " est déjà enregistré");
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
                port.EnregistrerDepart("IMO9427639");
                port.EnregistrerDepart("IMO9405423");
                port.EnregistrerDepart("IMO1111111");
            }
            catch (GestionPortException ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            
        }
    }
}
