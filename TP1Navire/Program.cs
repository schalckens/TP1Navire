using System;

namespace TP1Navire
{
    class Program
    {
        static void Main()
        {
            TesterInstanciations();
            TesterEnregistrerArrivee();
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
            Port port = new Port("Premier Port");
            port.EnregistrerArrivee(new Navire("IMO9839272","MSC Isabella","Porte-conteneurs",197500));
            port.EnregistrerArrivee(new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827));
            port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
            Console.WriteLine("Navires bien enregistrés dans le port");
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
