using Tj.Livraria.Domain.Entities;

namespace Tj.Livraria.App.Interfacies
{
    public interface IBookAppService : IAppService<Book>
    {
        Book Get(int bookCod, bool addAuthorRelationship, bool addSubjectRelationship);
    }
}