using GestionNavire.Exceptions;
using NavireHeritage.ClassesMetiers;
using System;
using System.Collections.Generic;

namespace Station.Interfaces
{
    /// <summary>
    /// Cette interface va imposer les méthodes nécessaires à la gestion de tout navire de croisière.
    /// Dans notre exemple il s'agira de l'embarquement et du débarquement de passagers afin de
    /// maintenir à jour la liste des passagers croisiéristes du navire.
    /// </summary>
    interface ICroisierable
    {
        /// <summary>
        /// Méthode qui met à jour la liste d'objets présents dans un bateau(passagers ou autres) Les objets de la liste passée en
        /// paramètre doivent être ajoutés de la liste des objets présents
        /// dans le navire.Une exception sera générée si le nombre de
        /// d'objets dépasse le nombre de d'objets maximum du navire.
        /// Aucun objet ne sera alors ajouté.
        /// </summary>
        /// <param name="objects"></param>
        public void Embarquer(List<Object> objects);
        /// <summary>
        /// Méthode qui met à jour la liste d'objets présents dans un bateau(passagers ou autres). Les objets passés en
        /// paramètres doivent être retirés de la liste des objets présents
        /// dans le navire.Cette méthode retourne la liste des objets
        /// passés en paramètre et qui n'ont pas été trouvés dans la liste
        /// des objets présents dans le navire.
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public List<Object> Debarquer(List<Object> objects);

    }
}
