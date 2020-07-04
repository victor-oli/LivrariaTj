using Tj.Livraria.Domain.Entities;

namespace Tj.Livraria.Infra.Mapping
{
    public abstract class AuthorMapping
    {
        public static Author Map(dynamic author)
        {
            return new Author
            {
                AuthorCod = author.CodAu,
                Name = author.Nome
            };
        }
    }
}