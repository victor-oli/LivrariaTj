using System;
using System.Collections.Generic;
using System.Text;

namespace Tj.Livraria.App.Interfacies
{
    public interface IAppService<Entity>
    {
        bool Add(Entity entity);
        List<Entity> GetAll();
        Entity Get(int cod);
        bool Update(Entity entity);
        bool Delete(int cod);
    }
}