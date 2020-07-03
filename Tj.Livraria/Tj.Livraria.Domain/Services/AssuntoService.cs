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
            throw new NotImplementedException();
        }

        public List<Assunto> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Assunto entity)
        {
            throw new NotImplementedException();
        }
    }
}