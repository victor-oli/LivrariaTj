using System;
using System.Collections.Generic;
using Tj.Livraria.App.Interfacies;
using Tj.Livraria.Domain.Entities;
using Tj.Livraria.Domain.Interfaces.Service;

namespace Tj.Livraria.App.AppServices
{
    public class SubjectAppService : ISubjectAppService
    {
        private ISubjectService _service;

        public SubjectAppService(ISubjectService service)
        {
            _service = service;
        }

        public bool Add(Subject entity)
        {
            return _service.Add(entity);
        }

        public bool Delete(int cod)
        {
            throw new NotImplementedException();
        }

        public Subject Get(int cod)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetAll()
        {
            return _service.GetAll();
        }

        public bool Update(Subject entity)
        {
            return _service.Update(entity);
        }
    }
}