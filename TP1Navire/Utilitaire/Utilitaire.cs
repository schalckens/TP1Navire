using NavireHeritage.ClassesMetiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilitaireNavire
{
    class Utilitaire
    {
        /// <summary>
        /// Va rechercher dans le port les stockages à parcourir pour décharger le navire passé en paramètre de la quantité passée en paramètre.
        /// </summary>
        /// <param name="navire"></param>
        /// <param name="qteDecharge"></param>
        /// <returns></returns>
        public Dictionary<int,int> GetItineraireDechargeNavire(Navire navire, int qteDecharge) { }
        /// <summary>
        /// Va rechercher dans le port les stockages à parcourir pour charger le navire passé en paramètre de la quantité passée en paramètre.        /// </summary>
        /// <param name="navire"></param>
        /// <param name="qteCharge"></param>
        /// <returns></returns>
        public Dictionary<int, int> GetItineraireChargeNavire(Navire navire, int qteCharge) { }
    }
}
