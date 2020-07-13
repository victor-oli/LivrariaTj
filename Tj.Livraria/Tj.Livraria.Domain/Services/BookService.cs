﻿using System.Collections.Generic;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Domain.Interfaces.Service;

namespace Tj.Livraria.Domain.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;
        private IAuthorRepository _authorRepository;
        private ISubjectRepository _subjectRepository;

        public BookService(IBookRepository repository, IAuthorRepository authorRepository, ISubjectRepository subjectRepository)
        {
            _repository = repository;
            _authorRepository = authorRepository;
            _subjectRepository = subjectRepository;
        }

        public bool Add(Book entity)
        {
            entity.IsValidToCreateOrUpdate();

            entity.Title = entity.Title.ToLower();
            entity.PublishingCompany = entity.PublishingCompany.ToLower();

            var anotherBookWithSameTitleAndEdition = _repository.GetByTitleAndEdition(entity.Title, entity.Edition);

            if (anotherBookWithSameTitleAndEdition != null)
                throw new AlreadyExistsException("Already exists a book with this title and edition");

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

        public Book Get(int bookCod, bool addAuthorRelationship, bool addSubjectRelationship)
        {
            Book book = Get(bookCod);

            if (book != null)
            {
                if (addAuthorRelationship)
                    book.Authors = _authorRepository.GetAllByBookCod(book.BookCod);

                if (addSubjectRelationship)
                    book.Subjects = _subjectRepository.GetAllByBookCod(book.BookCod);
            }

            return book;
        }

        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Update(Book entity)
        {
            entity.IsValidToCreateOrUpdate();

            entity.Title = entity.Title.ToLower();
            entity.PublishingCompany = entity.PublishingCompany.ToLower();

            var originalAuthor = _repository.Get(entity.BookCod);

            if (originalAuthor == null)
                throw new EntityNotFoundException($"Book not found, cod: {entity.BookCod}");

            var anotherBookWithSameTitleAndEdition = _repository.GetByTitleAndEdition(entity.Title, entity.Edition);

            if (anotherBookWithSameTitleAndEdition != null && anotherBookWithSameTitleAndEdition.BookCod != entity.BookCod)
                throw new AlreadyExistsException("Already exists a book with this title and edition");

            return _repository.Update(entity);
        }
    }
}