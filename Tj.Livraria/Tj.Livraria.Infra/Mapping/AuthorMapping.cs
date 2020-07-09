using Tj.Livraria.Domain.Entities;

namespace Tj.Livraria.Infra.Mapping
{
    public abstract class AuthorMapping
    {
        public static Author Map(dynamic author)
        {
            if (author == null)
                return null;

            return new Author
            {
                AuthorCod = author.CodAu,
                Name = author.Nome
            };
        }
    }
}