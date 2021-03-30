using NavireHeritage.ClassesMetiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Station.Interfaces
{
    /// <summary>
    /// Cette interface va imposer les méthodes nécessaires à la gestion de toute infrastructure gérant des objets de passage.Ici il s'agit de Port qui gère les arrivées et départs de navires, mais il
    /// pourrait s'agir de trains ou d'avion.
    /// </summary>
    interface Istationnable
    {

        /// <summary>
        /// Méthode qui met à jour la liste des objets qui sont
        /// susceptibles d'arriver dans la station (port, aéroport,…)
        /// </summary>
        /// <param name="obj"></param>
        public void EnregistrerArriveePrevue(Navire navire);
        /// <summary>
        /// Méthode qui enregistre l'arrivée réelle de l'objet.
        /// </summary>
        /// <param name="a"></param>
        public void EnregistrerArrivee(string imo);
        /// <summary>
        /// Méthode qui enregistre le départ d'un objet présent dans la
        /// station.
        /// </summary>
        /// <param name="a"></param>
        public void EnregistrerDepart(string imo);
        /// <summary>
        /// Retourne vrai si l'objet dont l'id est passé en paramètre fait
        /// partie des objets attendus dans la station
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Boolean EstAttendu(string imo);
        /// <summary>
        /// Retourne vrai si l'objet dont l'id est passé en paramètre fait
        /// partie des objets présents dans la station
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Boolean EstPresent(string imo);
        /// <summary>
        /// Retourne vrai si l'objet dont l'id est passé en paramètre est
        /// parti de la station depuis peu de temps
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Boolean EstParti(string imo);
        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une
        /// exception de type Exception
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Navire GetUnAttendu(string imo);
        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une
        /// exception de type Exception
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Navire GetUnArrive(string imo);
        /// <summary>
        /// Retourne l'objet dont l'id a été passé en paramètre ou une
        /// exception de type Exception
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Navire GetUnParti(string imo);

    }
}
