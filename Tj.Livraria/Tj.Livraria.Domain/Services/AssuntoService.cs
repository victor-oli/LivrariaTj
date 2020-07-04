using System;
using System.Collections.Generic;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Domain.Interfaces.Service;

namespace Tj.Livraria.Domain.Services
{
    public class AssuntoService : IAssuntoService
    {
        private IAssuntoRepository _repository;

        public AssuntoService(IAssuntoRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Assunto entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Descricao))
                throw new NullOrEmptyException("Description can't be null or empty");

            return _repository.Add(entity);
        }

        public bool Delete(int cod)
        {
            throw new NotImplementedException();
        }

        public Assunto Get(int cod)
        {
            if (cod < 1)
                throw new NullOrEmptyException("You need send a valid subject cod");

            return _repository.Get(cod);
        }

        public List<Assunto> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Update(Assunto entity)
        {
            if (entity.CodAssunto < 1)
                throw new NullOrEmptyException("Cod can't be null or empty");

            if (string.IsNullOrWhiteSpace(entity.Descricao))
                throw new NullOrEmptyException("Cod can't be null or empty");

            var originalSubject = _repository.Get(entity.CodAssunto);

            originalSubject.Descricao = entity.Descricao;

            return _repository.Update(originalSubject);
        }
    }
}