using GestionNavire.Exceptions;
using Station.Interfaces;
using System;
using System.Collections.Generic;

namespace NavireHeritage.ClassesMetiers
{
    class Port : Istationnable
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
        /// Nombre de quais d'accueil pour les tankers de jusqu'à 130000 tonnes (GT)
        /// </summary>
        private int nbQuaisTanker;
        /// <summary>
        /// Nombre de quais d'accueil pour les tankers de plus de 130000 tonnes(GT)
        /// </summary>
        private int nbQuaisSuperTanker;
        /// <summary>
        /// Nombre de quais d'accueil pour navires passagers
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
        /// Liste des stockages
        /// </summary>
        private List<Stockage> stockages = new List<Stockage>();
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
        public void EnregistrerArriveePrevue(Object navire)
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
            this.EnregistrerArrivee(navire.Imo);
        }
        public void EnregistrerArrivee(String imo)
        {
            if (navireAttendus.ContainsKey(imo))
            {
                Navire navire = this.navireAttendus[imo];
                if (navire is INavCommercable)
                {
                    GestionArrivee(navire);
                }
                else
                {
                    PermutationDictionary(navire, navireAttendus, navireArrives);
                }
            }
            else
            {
                throw new GestionPortException("");
            }
        }
        /// <summary>
        /// Méthode surcharge : enregistrement de l'arrivée d'un navire enregistré en tant que arrivée prévue. String = son id
        /// </summary>
        /// <param name="imo"></param>
        public void EnregistrerArrivee2(String imo)
        {
            if (navireAttendus.ContainsKey(imo))
            {
                Navire navire = this.navireAttendus[imo];
                if (navire is Cargo cargo)
                {
                    TraitementArrivee(cargo, navireAttendus, navireArrives);
                }
                else if (navire is Tanker tanker)
                {
                    TraitementArrivee(tanker, navireAttendus, navireArrives);
                }
                else
                {
                    PermutationDictionary(navire, navireAttendus, navireArrives);
                }
            }
            else
            {
                throw new GestionPortException("Le navire n'est pas attendu");
            }
        }

        private void TraitementArrivee(Cargo cargo, IDictionary<string, Navire> dictionaryDepart, IDictionary<string, Navire> dictionaryArrive)
        {
            if (this.GetNbCargoArrives() < nbPortique)
            {
                PermutationDictionary(cargo, dictionaryDepart, dictionaryArrive);
            }
            else
            {
                PermutationDictionary(cargo, dictionaryDepart, navireEnAttentes);
            }
        }
        private void TraitementArrivee(Tanker tanker, IDictionary<string, Navire> dictionaryDepart, IDictionary<string, Navire> dictionaryArrive)
        {
            if (tanker.TonnageActuel <= 130000)
            {
                if (this.GetNbTankerArrives() < nbQuaisTanker)
                {
                    PermutationDictionary(tanker, dictionaryDepart, dictionaryArrive);
                }
                else
                {
                    PermutationDictionary(tanker, dictionaryDepart, navireEnAttentes);
                }
            }
            else
            {
                if (this.GetNbSuperTankerArrives() < nbQuaisSuperTanker)
                {
                    PermutationDictionary(tanker, dictionaryDepart, dictionaryArrive);
                }
                else
                {
                    PermutationDictionary(tanker, dictionaryDepart,navireEnAttentes;
                }
            }

        }
        private static void PermutationDictionary(Navire navire, IDictionary<string, Navire> dictionaryDepart, IDictionary<string, Navire> dictionaryArrive)
        {
            dictionaryDepart.Remove(navire.Imo);
            dictionaryArrive.Add(navire.Imo, navire);
        }

        private void GestionArrivee(Navire navire)
        {
            if (navire is Cargo)
            {
                if (this.GetNbCargoArrives() < nbPortique)
                {
                    PermutationDictionary(navire, navireAttendus, navireArrives);
                }
                else
                {
                    PermutationDictionary(navire, navireAttendus, navireArrives);
                }
            }
            else
            {
                if (navire.TonnageActuel <= 130000)
                {
                    if (this.GetNbTankerArrives() < nbQuaisTanker)
                    {
                        PermutationDictionary(navire, navireAttendus, navireArrives);
                    }
                    else
                    {
                        PermutationDictionary(navire, navireAttendus, navireArrives);
                    }
                }
                else
                {
                    if (this.GetNbSuperTankerArrives() < nbQuaisSuperTanker)
                    {
                        PermutationDictionary(navire, navireAttendus, navireArrives);
                    }
                    else
                    {
                        PermutationDictionary(navire, navireAttendus, navireArrives);
                    }
                }
            }

        }
        private void GestionEnAttente(Navire navire)
        {
            int i = 0;
            Boolean test = false;
            while( i < navireEnAttentes.Count && test)
            {

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
                navirePartis.Add(GetNavire(imo).Imo, GetNavire(imo));
                

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
            return this.navirePartis.ContainsKey(imo);
        }
        /// <summary>
        /// Déhargement du navire dont l'id est passé en paramètre de la quantité passée en paramètre
        /// String : Id du navire
        /// Qté : quantité à décharger
        /// </summary>
        /// <param name="imo"></param>
        /// <param name="qteDecharge"></param>
        public void Dechargement(string imo, int qteDecharge){ }
        /// <summary>
        ///Chargement du navire dont l'id est passé en paramètre de la quantité passée en paramètre
        /// String : Id du navire
        /// Qté : quantité à décharger
        /// </summary>
        /// <param name="imo"></param>
        /// <param name="qteCharge"></param>
        public void Chargement(string imo, int qteCharge) { }
        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une exception de type Exception
        /// </summary>
        /// <param name="imo"></param>
        public Navire GetUnAttendu(string imo)
        {
            if (this.navireEnAttentes.TryGetValue(imo, out Navire navire))
            {
                return navire;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une exception de type Exception
        /// </summary>
        /// <param name="imo"></param>
        public Navire GetUnArrive(string imo)
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
        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une exception de type Exception
        /// </summary>
        /// <param name="imo"></param>
        public Navire GetUnParti(string imo)
        {
            if (!this.navireEnAttentes.TryGetValue(imo, out Navire navire))
            {
                return navire;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// retourne le nombre de tankers (tonnageGT <= 130000) présents dans le port
        /// </summary>
        /// <returns></returns>
        public int GetNbTankerArrives()
        {
            int cpt = 0;
            foreach (Navire navire in navireArrives.Values)
            {
                if (navire is Tanker tanker && tanker.TonnageDT <= 130000)
                {
                    cpt++;
                }
            }
            return cpt;
        }
        /// <summary>
        /// Retourne le nombre de super tankers (tonnageGT>130000) présents dans le port
        /// </summary>
        /// <returns></returns>
        public int GetNbSuperTankerArrives()
        {
            int cpt = 0;
            foreach (Navire navire in navireArrives.Values)
            {
                if (navire is Tanker tanker && tanker.TonnageDT > 130000)
                {
                    cpt++;
                }
            }
            return cpt;
        }
        /// <summary>
        /// retourne le nombre de cargos présents dans le port
        /// </summary>
        /// <returns></returns>
        public int GetNbCargoArrives()
        {
            int cpt = 0;
            foreach (Navire navire in navireArrives.Values)
            {
                if (navire is Cargo cargo)
                {
                    cpt++;
                }
            }
            return cpt;
        }
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
        public string Nom { get => nom; }
        public string Latitude { get => latitude; }
        public string Longitude { get => longitude; }
        public int NbPortique { get => nbPortique; set => nbPortique = value; }
        public int NbQuaisTanker { get => nbQuaisTanker; set => nbQuaisTanker = value; }
        public int NbQuaisSuperTanker { get => nbQuaisSuperTanker; set => nbQuaisSuperTanker = value; }
        public int NbQuaisPassager { get => nbQuaisPassager; set => nbQuaisPassager = value; }
        internal Dictionary<string, Navire> NavireAttendus { get => navireAttendus; }
        internal Dictionary<string, Navire> NavireArrives { get => navireArrives; }
        internal Dictionary<string, Navire> NavirePartis { get => navirePartis; }
        internal Dictionary<string, Navire> NavireEnAttentes { get => navireEnAttentes; }



    }
}
