using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL = Demo_BLL.Entities;
using DAL = Demo_DAL.Entities;

namespace Demo_BLL
{
    static class Mapper
    {
        #region Mapper Client
        public static BLL.Client ToBLL(this DAL.Client entity)
        {
            if (entity is null) return null;
            return new BLL.Client()
            {
                idClient = entity.idClient,
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.adresse
            };
        }

        public static DAL.Client ToDAL(this BLL.Client entity)
        {
            if (entity is null) return null;
            return new DAL.Client()
            {
                idClient = entity.idClient,
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.adresse
            };
        }
        #endregion

        #region Mapper Spectacle
        public static BLL.Spectacle ToBLL(this DAL.Spectacle entity)
        {
            if (entity is null) return null;
            /* // AVEC Contructeur à 3 paramètres
             * return new BLL.Spectacle(
                entity.idSpectacle,
                entity.nom,
                entity.description
                );
            */
            //AVEC constructeur prévu pour la DAL
            return new BLL.Spectacle(entity);
        }

        public static DAL.Spectacle ToDAL(this BLL.Spectacle entity)
        {
            if (entity is null) return null;
            return new DAL.Spectacle()
            {
                idSpectacle = entity.idSpectacle,
                nom = entity.nom,
                description = entity.description
            };
        }
        #endregion
    }
}
