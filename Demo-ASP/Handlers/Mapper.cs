using Demo_ASP.Models.ClientModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Handlers
{
    public static class Mapper
    {
        public static ClientListItem ToListItem(this Demo_BLL.Entities.Client entity)
        {
            if (entity is null) return null;
            return new ClientListItem()
            {
                idClient = entity.idClient,
                nom = entity.nom,
                prenom = entity.prenom
            };
        }
    }
}
