using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;

namespace NavireHeritage.ClassesMetiers
{
    class Port
    {
        private string nom;
        private string latitude;
        private string longitude;
        private int nbPortique;
        private int nbQuaisTanker;
        private int nbQuaisSuperTanker;
        private int nbQuaisPassager;
        private Dictionary<string, Navire> navireAttendus;
        private Dictionary<string, Navire> navireArrives;
        private Dictionary<string, Navire> navirePartis;
        private Dictionary<string, Navire> navireEnAttentes;

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

        public void enregistrerArriveePrevue(Navire navire)
        {
            this.navireAttendus.Add(navire.Imo, navire);
        }
        public void enregistrerArrivee(Navire navire)
        {
            this.navireArrives.Add(navire.Imo, navire);
        }
        private void AjoutNavireEnAttente(Navire navire)
        {
            this.navireEnAttentes.Add(navire.Imo, navire);
        }
        public Boolean EstAttendu(String imo)
        {
            return this.navireAttendus.ContainsKey(imo);
        }
        public Boolean EstPresent(String imo)
        {
            return this.navireArrives.ContainsKey(imo);
        }
        public Boolean EstEnAttente(String imo)
        {
            return this.navireEnAttentes.ContainsKey(imo);
        }
        public void Dechargement(string imo,int qteDecharge) { }
        public void Chargement(string imo,int qteCharge) { }
        public void GetUnEnAttente(string a) { }
        public void GetUnArrive(string a) { }
        public void GetUnParti(string a) { }
        public int GetNbTankerArrives() { return 0; }
        public int GetNbSuperTankerArrives() { return 0; }
        public int GetNbCargoArrives() { return 0; }
        private void AjoutNavireEnAttente(Navire navire) { }

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
