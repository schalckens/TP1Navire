using System;

namespace TP1Navire
{
    class Program
    {
        static void Main()
        {

            //TesterInstanciations();
            //TesterEnregistrerArrivee();
            //TesterRecupPosition();
            //TesterRecupPositionV2();
            TesterEnregistrerDepart();
            Console.WriteLine("--Fin du Programme--");
            Console.ReadKey();
        }

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

        public static void TesterEnregistrerArrivee()
        {
            try
            {
                Port port = new Port("Premier Port");
                port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500));
                port.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
                port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
                port.EnregistrerArrivee(new Navire("IMO9552149", "MSC Bastien"));
                port.EnregistrerArrivee(new Navire("IMO9554589", "MSC Emilou"));
                port.EnregistrerArrivee(new Navire("IMO9457149", "MSC Julien"));
                port.EnregistrerArrivee(new Navire("IMO9852149", "MSC Pastaga"));
                Console.WriteLine("Navires bien enregistrés dans le port");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void TesterRecupPosition()
        {
            (new Port("Toulon")).TesterRecupPosition();
        }

        public static void TesterRecupPositionV2()
        {
            (new Port("Toulon")).TesterRecupPositionV2();
        }

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
                Console.WriteLine("Depart du navire IMO1111111 enregistré0");
                Console.WriteLine("Fin des enregistrements des départs");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            
        }
        //Méthode d'affichage #1
        //public static void Affiche(Navire unNavire)
        //{
        //    //Console.WriteLine("\nIdentification : " + unNavire.Imo);
        //    //Console.WriteLine("Nom : " + unNavire.Nom);
        //    //Console.WriteLine("Type de Frêt : " + unNavire.LibelleFret);
        //    //Console.WriteLine("Quantité de Frêt : " + unNavire.QteFretMaxi);
        //    Console.WriteLine(unNavire); //possible grâce au override de la classe Navire à laquelle appartient unNavire
        //    Console.WriteLine("-----------------------------------------");
        //}
    }
}
