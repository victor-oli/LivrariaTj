using System.Collections.Generic;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Domain.Interfaces.Service;

namespace Tj.Livraria.Domain.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Book entity)
        {
            entity.IsValidToCreate();

            return _repository.Add(entity);
        }

        public bool Delete(int cod)
        {
            if (cod < 1)
                throw new NullOrEmptyException("You need send a valid book cod");

            return _repository.Delete(cod);
        }

        public Book Get(int cod)
        {
            if (cod < 1)
                throw new NullOrEmptyException("You need send a valid book cod");

            return _repository.Get(cod);
        }

        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Update(Book entity)
        {
            entity.IsValidToCreate();

            var originalAuthor = _repository.Get(entity.BookCod);

            if (originalAuthor == null)
                throw new EntityNotFoundException($"Book not found, cod: {entity.BookCod}");

            return _repository.Update(entity);
        }
    }
}