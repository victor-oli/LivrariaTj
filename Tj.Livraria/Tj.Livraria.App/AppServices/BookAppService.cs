using System.Collections.Generic;
using Tj.Livraria.App.Interfacies;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Service;

namespace Tj.Livraria.App.AppServices
{
    public class BookAppService : IBookAppService
    {
        private IBookService _service;

        public BookAppService(IBookService service)
        {
            _service = service;
        }

        public bool Add(Book entity)
        {
            return _service.Add(entity);
        }

        public bool Delete(int cod)
        {
            return _service.Delete(cod);
        }

        public Book Get(int cod)
        {
            return _service.Get(cod);
        }

        public Book Get(int bookCod, bool addAuthorRelationship, bool addSubjectRelationship)
        {
            return _service.Get(bookCod, addAuthorRelationship, addSubjectRelationship);
        }

        public List<Book> GetAll()
        {
            return _service.GetAll();
        }

        public bool Update(Book entity)
        {
            return _service.Update(entity);
        }
    }
}