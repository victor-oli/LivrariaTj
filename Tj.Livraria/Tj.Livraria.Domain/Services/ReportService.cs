using System.Collections.Generic;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Domain.Interfaces.Service;
using Tj.Livraria.Domain.Views;

namespace Tj.Livraria.Domain.Services
{
    public class ReportService : IReportService
    {
        private IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public List<AuthorsBySubject> GetAuthorsBySubject()
        {
            return _repository.GetAuthorsBySubject();
        }

        public List<BooksBySubject> GetBooksBySubject()
        {
            return _repository.GetBooksBySubject();
        }
    }
}