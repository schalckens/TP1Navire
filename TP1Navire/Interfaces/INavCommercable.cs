
namespace Station.Interfaces
{
    /// <summary>
    /// Cette interface va imposer les méthodes nécessaires à la gestion de tout navire marchand. Dans notre exemple il s'agira du chargement et déchargement.
    /// </summary>
    interface INavCommercable
    {
        /// <summary>
        /// Méthode qui met à jour le tonnage actuel du navire avec la valeur passée en paramètre. La quantité passée en paramètre est enlevée à la quantité actuelle.
        /// </summary>
        /// <param name="qteDecharge"></param>
        public void Decharger(int qteDecharge);
        /// <summary>
        ///Méthode qui met à jour le tonnage actuel du bateau avec la valeur passée en paramètre. La quantité passée en paramètre est ajoutée à la quantité actuelle.
        /// </summary>
        /// <param name="qteCharge"></param>
        public void Charger(int qteCharge);
    }
}
