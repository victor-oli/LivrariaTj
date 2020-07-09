using System;
using System.Collections.Generic;
using System.Linq;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Exceptions;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Domain.Interfaces.Service;

namespace Tj.Livraria.Domain.Services
{
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _repository;
        private IBookRepository _bookRepository;

        public SubjectService(ISubjectRepository repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
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

            List<Book> associatedBooks = _bookRepository.GetAllBySubject(cod);

            if (associatedBooks.Any())
                throw new RelationshipViolationException("Can't delete this subject, he is in use");

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

            entity.Description = entity.Description.ToLower();

            var originalSubject = _repository.Get(entity.SubjectCod);

            if (originalSubject == null)
                throw new EntityNotFoundException($"Subject not found, cod: {entity.SubjectCod}");

            var subjectWithSameName = _repository.GetByDescription(entity.Description);

            if (subjectWithSameName != null && subjectWithSameName.SubjectCod != entity.SubjectCod)
                throw new AlreadyExistsException("Already exists a subject with this description");

            return _repository.Update(entity);
        }
    }
}