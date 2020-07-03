using System.Collections.Generic;

namespace Tj.Livraria.Domain.Interfaces.Repository
{
    public interface IRepository<Entity> where Entity : class
    {
        void Add(Entity entity);
        List<Entity> GetAll();
        Entity Get(int cod);
        void Update(Entity entity);
        void Delete(int cod);
    }
}