using System.Collections.Generic;

namespace Tj.Livraria.Domain.Interfaces.Repository
{
    public interface IRepository<Entity> where Entity : class
    {
        bool Add(Entity entity);
        List<Entity> GetAll();
        Entity Get(int cod);
        bool Update(Entity entity);
        bool Delete(int cod);
    }
}