using System.Collections.Generic;
using Tj.Livraria.Domain.Entities;

namespace Tj.Livraria.Domain.Interfaces.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        List<Book> GetAllBySubject(int subjectCod);
        List<Book> GetAllByAuthor(int authorCod);
    }
}