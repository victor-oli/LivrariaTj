using System.Collections.Generic;
using Tj.Livraria.App.Interfaces;
using Tj.Livraria.Domain.Interfaces.Service;
using Tj.Livraria.Domain.Views;

namespace Tj.Livraria.App.AppServices
{
    public class ReportAppService : IReportAppService
    {
        private IReportService _service;

        public ReportAppService(IReportService service)
        {
            _service = service;
        }

        public List<BooksBySubject> GetBooksBySubject()
        {
            return _service.GetBooksBySubject();
        }
    }
}