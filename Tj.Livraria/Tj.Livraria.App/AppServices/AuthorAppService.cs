using System.Collections.Generic;
using Tj.Livraria.App.Interfacies;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Service;

namespace Tj.Livraria.App.AppServices
{
    public class AuthorAppService : IAuthorAppService
    {
        private IAuthorService _service;

        public AuthorAppService(IAuthorService service)
        {
            _service = service;
        }

        public bool Add(Author entity)
        {
            return _service.Add(entity);
        }

        public bool Delete(int cod)
        {
            return _service.Delete(cod);
        }

        public Author Get(int cod)
        {
            return _service.Get(cod);
        }

        public List<Author> GetAll()
        {
            return _service.GetAll();
        }

        public bool Update(Author entity)
        {
            return _service.Update(entity);
        }
    }
}