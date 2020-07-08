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
            entity.IsValidToCreateOrUpdate();

            entity.Description = entity.Description.ToLower();

            Subject existingSubject = _repository.GetByDescription(entity.Description);

            if (existingSubject != null)
                throw new AlreadyExistsException("Already exists a subject with this description");

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
            entity.IsValidToCreateOrUpdate();

            var originalSubject = _repository.Get(entity.SubjectCod);

            if (originalSubject == null)
                throw new EntityNotFoundException($"Subject not found, cod: {entity.SubjectCod}");

            return _repository.Update(entity);
        }
    }
}