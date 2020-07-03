using System.Collections.Generic;

namespace Tj.Livraria.Domain.Interfaces.Service
{
    public interface IService<Entity>
    {
        void Add(Entity entity);
        List<Entity> GetAll();
        Entity Get(int cod);
        void Update(Entity entity);
        void Delete(int cod);
    }
}