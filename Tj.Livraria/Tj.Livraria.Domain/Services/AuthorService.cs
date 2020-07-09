using System;
using System.Collections.Generic;
using System.Linq;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Domain.Interfaces.Service;

namespace Tj.Livraria.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _repository;
        private IBookRepository _bookRepository;

        public AuthorService(IAuthorRepository repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }

        public bool Add(Author entity)
        {
            entity.IsValidToCreateOrUpdate();

            entity.Name = entity.Name.ToLower();

            var existsAuthor = _repository.GetByName(entity.Name);

            if (existsAuthor != null)
                throw new AlreadyExistsException("Already exists an author with this name");

            return _repository.Add(entity);
        }

        public bool Delete(int cod)
        {
            if (cod < 1)
                throw new NullOrEmptyException("You need send a valid author cod");

            List<Book> associatedBooks = _bookRepository.GetAllByAuthor(cod);

            if (associatedBooks.Any())
                throw new RelationshipViolationException("Can't delete this author, he is in use");

            return _repository.Delete(cod);
        }

        public Author Get(int cod)
        {
            if (cod < 1)
                throw new NullOrEmptyException("You need send a valid author cod");

            return _repository.Get(cod);
        }

        public List<Author> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Update(Author entity)
        {
            entity.IsValidToCreateOrUpdate();

            entity.Name = entity.Name.ToLower();

            var originalAuthor = _repository.Get(entity.AuthorCod);

            if (originalAuthor == null)
                throw new EntityNotFoundException($"Author not found, cod: {entity.AuthorCod}");

            if (originalAuthor.AuthorCod != entity.AuthorCod)
                throw new AlreadyExistsException("Already exists an author with this name");

            return _repository.Update(entity);
        }
    }
}