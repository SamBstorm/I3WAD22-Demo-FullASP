using Demo_BLL.Entities;
using Demo_Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Services
{
    public class SpectacleService : ISpectacleRepository<Spectacle, int>
    {
        private readonly ISpectacleRepository<Demo_DAL.Entities.Spectacle, int> _repository;

        public SpectacleService(ISpectacleRepository<Demo_DAL.Entities.Spectacle, int> repository)
        {
            _repository = repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<Spectacle> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Spectacle Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(Spectacle entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public bool Update(int id, Spectacle entity)
        {
            return _repository.Update(id, entity.ToDAL());
        }
    }
}
