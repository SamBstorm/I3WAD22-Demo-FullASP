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
    }
}
