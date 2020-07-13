using System.Collections.Generic;
using Tj.Livraria.Domain.Views;

namespace Tj.Livraria.Domain.Interfaces.Repository
{
    public interface IReportRepository
    {
        List<BooksBySubject> GetBooksBySubject();
        List<AuthorsBySubject> GetAuthorsBySubject();
    }
}