using Demo_ASP.Models.ClientModelView;
using Demo_BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Handlers
{
    public static class Mapper
    {
        public static ClientListItem ToListItem(this Client entity)
        {
            if (entity is null) return null;
            return new ClientListItem()
            {
                idClient = entity.idClient,
                nom = entity.nom,
                prenom = entity.prenom
            };
        }

        public static Client ToBLL(this ClientCreateForm entity)
        {
            if (entity is null) return null;
            return new Client()
            {
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.adresse
            };
        }
    }
}
