using System;

namespace TP1Navire
{
    class Program
    {
        static void Main()
        {
            TesterInstanciations();
            Console.WriteLine("--Fin du Programme--");
            Console.ReadKey();
        }

        public static void TesterInstanciations()
        {
            //déclaration de l'objet unNavire de la classe Navire
            Navire unNavire;
            //instanciation de l'objet
            unNavire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827);
            Affiche(unNavire);
            //Déclaration ET instanciation d'un autre objet de la classe Navire
            Navire unAutreNavire = new Navire("IMO9839272", "MSC Isabelle", "Porte-conteneurs", 197500);
            Affiche(unAutreNavire);
            //
            unAutreNavire = new Navire("IMO8715871", "MSC PILAR");
            Affiche(unAutreNavire);
        }
        public static void Affiche(Navire unNavire)
        {
            //Console.WriteLine("\nIdentification : " + unNavire.Imo);
            //Console.WriteLine("Nom : " + unNavire.Nom);
            //Console.WriteLine("Type de Frêt : " + unNavire.LibelleFret);
            //Console.WriteLine("Quantité de Frêt : " + unNavire.QteFretMaxi);
            Console.WriteLine(unNavire);
            Console.WriteLine("-----------------------------------------");
        }
    }
}
