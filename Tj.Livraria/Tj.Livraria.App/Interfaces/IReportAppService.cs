using System.Collections.Generic;
using Tj.Livraria.Domain.Views;

namespace Tj.Livraria.App.Interfaces
{
    public interface IReportAppService
    {
        List<BooksBySubject> GetBooksBySubject();
        List<AuthorsBySubject> GetAuthorsBySubject();
    }
}