using System;
using GestionNavire.Classesmetier;

namespace GestionNavire.Application
{
    class Program
    {
        static void Main()
        {

            TesterInstanciations();
            TesterEnregistrerArrivee();
            TesterEnregistrerDepart();
            
            Console.WriteLine("--Fin du Programme--");
        }
        /// <summary>
        /// Méthode permettant de Tester l'instanciation d'un nouveau navire de la classe Navire.
        /// </summary>
        public static void TesterInstanciations()
        {
            //déclaration de l'objet unNavire de la classe Navire
            Navire unNavire;
            //instanciation de l'objet
            unNavire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
            //Méthode d'affichage #2
            //Affiche(unNavire);
            Console.WriteLine(unNavire);
            //Déclaration ET instanciation d'un autre objet de la classe Navire
            Navire unAutreNavire = new Navire("IMO9839272", "MSC Isabelle", "Porte-conteneurs", 197500);
            //Affiche(unAutreNavire);
            Console.WriteLine(unAutreNavire);
            unAutreNavire = new Navire("IMO8715871", "MSC PILAR");
            //Affiche(unAutreNavire);
            Console.WriteLine(unAutreNavire);
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
