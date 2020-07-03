using System.Collections.Generic;

namespace Tj.Livraria.Domain.Interfaces.Service
{
    public interface IService<Entity>
    {
        bool Add(Entity entity);
        List<Entity> GetAll();
        Entity Get(int cod);
        bool Update(Entity entity);
        bool Delete(int cod);
    }
}