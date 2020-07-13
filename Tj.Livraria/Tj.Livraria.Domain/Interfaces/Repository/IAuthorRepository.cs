using System.Collections.Generic;
using Tj.Livraria.Domain.Entities;

namespace Tj.Livraria.Domain.Interfaces.Repository
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetByName(string name);
        List<Author> GetAllByBookCod(int bookCod);
        void AddManyRelations(int bookCod, List<Author> authors);
        void DeleteManyRelations(int bookCod, List<Author> authors);
    }
}