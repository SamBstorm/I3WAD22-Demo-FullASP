using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_Common.Repositories
{
    public interface IClientRepository<TEntity, TId> : IRepository<TEntity, TId>
    {
        int? CheckPassword(string email, string password);
    }
}
