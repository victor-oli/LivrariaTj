using System.Collections.Generic;
using Tj.Livraria.Domain.Views;

namespace Tj.Livraria.Domain.Interfaces.Service
{
    public interface IReportService
    {
        List<BooksBySubject> GetBooksBySubject();
        List<AuthorsBySubject> GetAuthorsBySubject();
    }
}