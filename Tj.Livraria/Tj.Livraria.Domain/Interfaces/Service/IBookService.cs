using Tj.Livraria.Domain.Entities;

namespace Tj.Livraria.Domain.Interfaces.Service
{
    public interface IBookService : IService<Book>
    {
        Book Get(int bookCod, bool addAuthorRelationship, bool addSubjectRelationship);
    }
}