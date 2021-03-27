using System;
using NavireHeritage.ClassesMetiers;
using GestionNavire.Exceptions;

namespace NavireHeritage
{
    class Program
    {
        private static Port port;
        static void Main()
        {
            try
            {
                //port = new Port("Toulon");
                ////Instanciations();
                //try { TesterEnregistrerArrivee(); }
                //catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
                //try { TesterEnregistrerArriveeV2(); }
                //catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
                //try { TesterEnregistrerDepart(); }
                //catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
                //TesterInstanciationsStockage();

                port = new Port("Toulon");
                InitPort();
                ////Instanciations();
                try { TesterEnregistrerArrivee(); }
                catch (GestionPortException ex)
                { Console.WriteLine(ex.Message); }

                try { TesterEnregistrerArriveeV2(); }
                catch (GestionPortException ex)
                { Console.WriteLine(ex.Message); }

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("------- Début des déchargements -------");
                Console.WriteLine("-----------------------------------------");
                AjouterStockages();
                TesterDechargerNavires();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("------- fin des déchargements -------");
                Console.WriteLine("---------------------------------------");

                try { TesterEnregistrerDepart(); }
                catch (GestionPortException ex)
                { Console.WriteLine(ex.Message); }
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
        //public static void Instanciations()
        //{
        //    try
        //    {
        //        Navire navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827, 156827);
        //        navire = new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500, 197500);
        //        navire = new Navire("IMO8715871", "MSC PILAR", "Porte-conteneurs", 67183, 67183);
        //        navire = new Navire("XMO9235232", "FORTUNE TRADER", "Cargo", 74750, 74750);
        //        navire = new Navire("IMO9574004", "TRITON SEAHAWK", "Hydrocarbures", 51201, 51201);
        //    }
        //    catch (GestionPortException ex)
        //    {
        //        Console.WriteLine(ex.Message); 
        //    }
        //}

        public static void InitPort()
        {
            Port port = new Port("Toulon");
            Navire unNavire;
            unNavire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827, 120000);
            Navire unAutreNavire = new Navire("IMO9839272", "MSC Isabelle", "Porte-conteneurs", 197500, 13000);
            unAutreNavire = new Navire("IMO8715871", "MSC PILAR");
            Console.WriteLine("Fin de chargement du Port");
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
                navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827, 150000);
                port.EnregistrerArrivee(navire);
                navire = new Navire("IMO9427639", "Copper Spirit", "Hydrocarbures", 156827, 150000);
                port.EnregistrerArrivee(navire);
                Console.WriteLine("Navires bien enregistrés dans le port");
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
                port.EnregistrerArrivee(new Navire("IMO9839272", "MSC Isabella", "Porte-conteneurs", 197500, 150000));
                port.EnregistrerArrivee(new Navire("IMO8715871", "MSC PILAR"));
                port.EnregistrerArrivee(new Navire("IMO9235232", "FORTUNE TRADER", "Cargo", 74750, 70000));
                port.EnregistrerArrivee(new Navire("IMO9405423", "SERENEA", "tANKER", 158583, 150000));
                port.EnregistrerArrivee(new Navire("IMO9574004", "TRITON SEAHAWK", "Hydrocarbures", 51201, 50000));
                
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

        public static void TesterInstanciationsStockage()
        {
            try{new Stockage(1, 15000);}
            catch (GestionPortException ex)
            {Console.WriteLine(ex.Message);}

            try{new Stockage(2, 12000,10000);}
            catch (GestionPortException ex)
            {Console.WriteLine(ex.Message);}

            try{new Stockage(3, -25000,-10000);}
            catch (GestionPortException ex)
            {Console.WriteLine(ex.Message);}

            try{new Stockage(4, 15000,20000);}
            catch (GestionPortException ex)
            {Console.WriteLine(ex.Message);}

        }


        public static void AjouterStockages()
        {
            port.AjoutStockage(new Stockage(1, 160000));
            port.AjoutStockage(new Stockage(2, 12000));
            port.AjoutStockage(new Stockage(3, 25000));
            port.AjoutStockage(new Stockage(4, 15000));
            port.AjoutStockage(new Stockage(5, 15000));
            port.AjoutStockage(new Stockage(6, 15000));
            port.AjoutStockage(new Stockage(7, 15000));
            port.AjoutStockage(new Stockage(8, 15000));
            port.AjoutStockage(new Stockage(9, 35000));
            port.AjoutStockage(new Stockage(10, 19000));
        }

        public static void TesterDechargerNavires()
        {
            try
            {
                String imo = "IMO9839272";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
                port.EnregistrerDepart(imo);
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                String imo = "IMO1111111";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                String imo = "IMO9574004";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                port.EnregistrerArrivee(new Navire("IMO9786841", "EVER GLOBE", "Porte-conteneurs", 198937, 190000));
                String imo = "IMO9786841";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
                port.EnregistrerDepart(imo);
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
            try
            {
                port.EnregistrerArrivee(new Navire("IMO9776432", "CMACGM LOUIS BLERIOT", "Porte-conteneurs", 202684, 190000));
                String imo = "IMO9776432";
                port.Dechargement(imo);
                Console.WriteLine("Navire " + imo + " déchargé");
            }
            catch (GestionPortException ex) { Console.WriteLine(ex.Message); }
        }


    }
}
