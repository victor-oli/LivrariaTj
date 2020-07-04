﻿using System;
using System.Collections.Generic;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Domain.Interfaces.Service;

namespace Tj.Livraria.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Author entity)
        {
            entity.IsValid();

            return _repository.Add(entity);
        }

        public bool Delete(int cod)
        {
            if (cod < 1)
                throw new NullOrEmptyException("You need send a valid author cod");

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
            entity.IsValid();

            var originalAuthor = _repository.Get(entity.AuthorCod);

            if (originalAuthor == null)
                throw new EntityNotFoundException($"Author not found, cod: {entity.AuthorCod}");

            return _repository.Update(entity);
        }
    }
}