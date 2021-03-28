using GestionNavire.Exceptions;
using System;
using System.Collections.Generic;

namespace Station.Interfaces
{
    interface ICroisierable
    {
        public void Embarquer( List<Object> objects ) 
        {
            if (objects.Count < (??))
            {
                ?? += objects;
            }
            else
            {
                throw new GestionPortException("Le nombre est supérieur à la capacité maximale, rien n'est enregistré.");
            }
        }
        public List<Object> Debarquer( List<Object> objects) 
        {
            List<Object> objects2 = new Lis<Object>();
            foreach (Object objet in objects)
            {
                if (this.???.Contains(objet))
                {
                    this.???.Remove(objet);
                }
                else
                {
                    objects2.Add(objet);
                }
            }

            return objects2;
        }

    }
}
