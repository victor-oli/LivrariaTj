using System;
using System.Collections.Generic;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Domain.Interfaces.Service;

namespace Tj.Livraria.Domain.Services
{
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _repository;

        public SubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Subject entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Description))
                throw new NullOrEmptyException("Description can't be null or empty");

            return _repository.Add(entity);
        }

        public bool Delete(int cod)
        {
            if (cod < 1)
                throw new NullOrEmptyException("You need send a valid subject cod");

            return _repository.Delete(cod);
        }

        public Subject Get(int cod)
        {
            if (cod < 1)
                throw new NullOrEmptyException("You need send a valid subject cod");

            return _repository.Get(cod);
        }

        public List<Subject> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Update(Subject entity)
        {
            if (entity.SubjectCod < 1)
                throw new NullOrEmptyException("Cod can't be null or empty");

            if (string.IsNullOrWhiteSpace(entity.Description))
                throw new NullOrEmptyException("Cod can't be null or empty");

            var originalSubject = _repository.Get(entity.SubjectCod);

            originalSubject.Description = entity.Description;

            return _repository.Update(originalSubject);
        }
    }
}