using GestionNavire.Exceptions;
using Station.Interfaces;
using System;
using System.Collections.Generic;

namespace NavireHeritage.ClassesMetiers
{
    class Port : IStationnable
    {
        /// <summary>
        /// Nom du port
        /// </summary>
        private string nom;
        /// <summary>
        /// Position (Latitude) du port
        /// </summary>
        private string latitude;
        /// <summary>
        /// Position (Longitude) du port
        /// </summary>
        private string longitude;
        /// <summary>
        /// Nombre de points d'accueil d'un cargo
        /// </summary>
        private int nbPortique;
        /// <summary>
        /// Nombre de quais d'accueil pour navires passagers
        /// </summary>
        private int nbQuaisTanker;
        /// <summary>
        /// Nombre de quais d'accueil pour les tankers de jusqu'à 130000 tonnes (GT)
        /// </summary>
        private int nbQuaisSuperTanker;
        /// <summary>
        /// Nombre de quais d'accueil pour les tankers de plus de 130000 tonnes(GT)
        /// </summary>
        private int nbQuaisPassager;
        /// <summary>
        /// Dictionnaire des navires attendus. String = id du navire
        /// </summary>
        private Dictionary<string, Navire> navireAttendus;
        /// <summary>
        /// Dictionnaire des navires arrivés, c’est-à-dire présents dans le port. String = id du navire
        /// </summary>
        private Dictionary<string, Navire> navireArrives;
        /// <summary>
        /// Dictionnaire des navires partis récemment. String = id du navire
        /// </summary>
        private Dictionary<string, Navire> navirePartis;
        /// <summary>
        /// Dictionnaire des navires en attente d'avoir un quai libre pour stationner. String = id du navire
        /// </summary>
        private Dictionary<string, Navire> navireEnAttentes;
        /// <summary>
        /// Constructeur permettant de valoriser les attributs de la classe.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="nbPortique"></param>
        /// <param name="nbQuaisTanker"></param>
        /// <param name="nbQuaisSuperTanker"></param>
        /// <param name="nbQuaisPassager"></param>
        public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisTanker, int nbQuaisSuperTanker, int nbQuaisPassager)
        {
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.nbPortique = nbPortique;
            this.nbQuaisTanker = nbQuaisTanker;
            this.nbQuaisSuperTanker = nbQuaisSuperTanker;
            this.nbQuaisPassager = nbQuaisPassager;
        }
        /// <summary>
        /// Enregistrement de l'arrivée proche d'un navire
        /// </summary>
        /// <param name="navire"></param>
        public void EnregistrerArriveePrevue(Navire navire)
        {
            if (!this.EstPresent(navire.Imo) && !this.EstEnAttente(navire.Imo) && !this.EstAttendu(navire.Imo))
            {
                this.navireAttendus.Add(navire.Imo, navire);
            }
            else 
            {
                if (this.EstPresent(navire.Imo))
                {
                    throw new GestionPortException("Impossible d'enregistrer ce navire dans les Arrivée Prévue car il est déjà dans le port");
                }
                else if (this.EstEnAttente(navire.Imo))
                {
                    throw new GestionPortException("Impossible d'enregistrer ce navire dans les Arrivée Prévue car il est déjà dans la liste d'attente");
                }
                else
                {
                    throw new GestionPortException("Impossible d'enregistrer ce navire dans les Arrivée Prévue car il est déjà dans la liste des navires attendus");
                }
            }
        }
        /// <summary>
        /// Enregistrement de l'arrivée d'un navire enregistré en tant que arrivée prévue.
        /// </summary>
        /// <param name="navire"></param>
        public void EnregistrerArrivee(Navire navire)
        {
            if (navire is Cargo)
            {
                if (this.NbPortique > navireArrives.Count)
                {
                    navireArrives.Add(navire.Imo, navire);
                }
                else
                {
                    this.AjoutNavireEnAttente(navire);
                    throw new GestionPortException("Bateau mis en attente, il ne reste plus de quais libres pour les cargos");
                }
            }
            else if (navire is Croisiere)
            {
                if (this.NbQuaisPassager > navireArrives.Count)
                {
                    navireAttendus.Add(navire.Imo, navire);
                }
                else
                {
                    this.AjoutNavireEnAttente(navire);
                    throw new GestionPortException("Bateau mis en attente, il ne reste plus de quais libres pour les navires de croisières");
                }
            }
            else if (navire is Tanker)
            {
                if (Navire.TonnageDWT <= 130000)
                {
                    if (this.nbQuaisTanker < navireArrives.Count)
                    {
                        navireAttendus.Add(navire.Imo, navire);
                    }
                    else
                    {
                        this.AjoutNavireEnAttente(navire);
                        throw new GestionPortException("Bateau mis en attente, il ne reste plus de quais libres pour les tankers");
                    }
                }
                else
                {
                    if (this.NbQuaisSuperTanker < navireArrives.Count)
                    {
                        navireAttendus.Add(navire.Imo, navire);
                    }
                    else
                    {
                        this.AjoutNavireEnAttente(navire);
                        throw new GestionPortException("Bateau mis en attente, il ne reste plus de quais libres pour les super tankers");
                    }
                }
            } 
        }
        /// <summary>
        /// Méthode surcharge : enregistrement de l'arrivée d'un navire enregistré en tant que arrivée prévue. String = son id
        /// </summary>
        /// <param name="imo"></param>
        public void EnregistrerArrivee(String imo)
        {
            if (navireAttendus.ContainsKey(imo))
            {
                foreach (Navire navire in navireAttendus.Values)
                {
                    if (navire.Imo == imo)
                    {
                        EnregistrerArrivee(navire);
                    }
                }
            }
        }
        /// <summary>
        /// enregistrement du départ d'un navire présent dans le port. String = son id
        /// On ne peut enregistrer un départ que si le Navire est présent dans le port.
        /// </summary>
        /// <param name="navire"></param>
        public void EnregistrerDepart(Navire navire) 
        {
            EnregistrerDepart(navire.Imo);
        }
        public void EnregistrerDepart(string imo)
        {
            if (EstPresent(imo))
            {
                this.navireArrives.Remove(imo);
            }
            else
            {
                throw new GestionPortException("Impossible d'enregister le depart du navire " + imo + " , il n'est pas dans le port");
            }
        }
        /// <summary>
        ///Ajout du navire passé en paramètre dans le dictionnaire des navires en attente d'un quai dans le port.
        /// </summary>
        /// <param name="navire"></param>
        private void AjoutNavireEnAttente(Navire navire)
        {
            this.navireEnAttentes.Add(navire.Imo, navire);
        }
        /// <summary>
        /// Retourne vrai si le navire est attendu. Id= imo
        /// </summary>
        /// <param name="imo"></param>
        /// <returns></returns>
        public Boolean EstAttendu(String imo)
        {
            return this.navireAttendus.ContainsKey(imo);
        }
        /// <summary>
        /// Retourne vrai si le navire est dans le port. Id= imo
        /// </summary>
        /// <param name="imo"></param>
        /// <returns></returns>
        public Boolean EstPresent(String imo)
        {
            return this.navireArrives.ContainsKey(imo);
        }
        /// <summary>
        /// Retourne vrai si le navire est en attenteRetourne vrai si le navire est en attente d'un quai dans le port. Id= imo d'un quai dans le port. Id= imo
        /// </summary>
        /// <param name="imo"></param>
        /// <returns></returns>
        public Boolean EstEnAttente(String imo)
        {
            return this.navireEnAttentes.ContainsKey(imo);
        }
        public Boolean EstParti(string imo)
        {

        }
        /// <summary>
        /// Déhargement du navire dont l'id est passé en paramètre de la quantité passée en paramètre
        /// String : Id du navire
        /// Qté : quantité à décharger
        /// </summary>
        /// <param name="imo"></param>
        /// <param name="qteDecharge"></param>
        public void Dechargement(string imo,int qteDecharge) 
        {
            Navire navire = GetNavire(imo);
            if (navire != null && navire.LibelleFret == "Porte-conteneurs")
            {
                int i = 0;
                while (i < this.stockages.Count && !navire.EstDecharge())
                {
                    if (this.stockages[i].CapaciteDispo >= 0 && this.stockages[i].CapaciteDispo > navire.QteFret)
                    {
                        navire.Decharger(navire.QteFret);
                        this.stockages[i].Stocker(navire.QteFret);
                    }
                    else
                    {
                        navire.Decharger(this.stockages[i].CapaciteDispo);
                        this.stockages[i].Stocker(this.stockages[i].CapaciteDispo);

                    }
                    i++;
                }
                if (navire.EstDecharge())
                {
                    Console.WriteLine("Le navire à bien été déchargé");
                }
                else
                {
                    throw new GestionPortException("Le navire " + navire.Imo + " n'a pas pu être entièrement déchargé, il reste " + navire.QteFret + " tonnes.");
                }
            }
            else
            {
                throw new GestionPortException("Impossible de décharger le navire " + imo + " il n'est pas dans le port ou n'est pas un porte-conteneurs.");

            }
        }
        /// <summary>
        ///Chargement du navire dont l'id est passé en paramètre de la quantité passée en paramètre
        /// String : Id du navire
        /// Qté : quantité à décharger
        /// </summary>
        /// <param name="imo"></param>
        /// <param name="qteCharge"></param>
        public void Chargement(string imo,int qteCharge) { }

        
        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une exception de type Exception
        /// </summary>
        /// <param name="imo"></param>
        public void GetUnEnAttente(string imo) { }
        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une exception de type Exception
        /// </summary>
        /// <param name="imo"></param>
        public void GetUnArrive(string imo) { }
        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une exception de type Exception
        /// </summary>
        /// <param name="imo"></param>
        public void GetUnParti(string imo) { }
        /// <summary>
        /// retourne le nombre de tankers (tonnageGT <= 130000) présents dans le port
        /// </summary>
        /// <returns></returns>
        public int GetNbTankerArrives() { return 0; }
        /// <summary>
        /// Retourne le nombre de super tankers (tonnageGT>130000) présents dans le port
        /// </summary>
        /// <returns></returns>
        public int GetNbSuperTankerArrives() { return 0; }
        /// <summary>
        /// retourne le nombre de cargos présents dans le port
        /// </summary>
        /// <returns></returns>
        public int GetNbCargoArrives() { return 0; }
        public Navire GetNavire(string imo)
        {
            if (this.navireArrives.TryGetValue(imo, out Navire navire))
            {
                return navire;
            }
            else
            {
                return null;
            }
        }
        public string Nom { get => nom;}
        public string Latitude { get => latitude;}
        public string Longitude { get => longitude;}
        public int NbPortique { get => nbPortique; set => nbPortique = value; }
        public int NbQuaisTanker { get => nbQuaisTanker; set => nbQuaisTanker = value; }
        public int NbQuaisSuperTanker { get => nbQuaisSuperTanker; set => nbQuaisSuperTanker = value; }
        public int NbQuaisPassager { get => nbQuaisPassager; set => nbQuaisPassager = value; }
        internal Dictionary<string, Navire> NavireAttendus { get => navireAttendus;}
        internal Dictionary<string, Navire> NavireArrives { get => navireArrives;}
        internal Dictionary<string, Navire> NavirePartis { get => navirePartis;}
        internal Dictionary<string, Navire> NavireEnAttentes { get => navireEnAttentes; }



    }
}
