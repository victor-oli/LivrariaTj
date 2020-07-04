using Microsoft.Extensions.DependencyInjection;
using Tj.Livraria.Domain.Interfaces.Repository;
using Tj.Livraria.Infra.Repositories;

namespace Tj.Livraria.App.IoC
{
    public abstract class RepositoryConfig
    {
        public static void Config(IServiceCollection collection)
        {
            collection.AddScoped<ISubjectRepository, SubjectRepository>();
            collection.AddScoped<IAuthorRepository, AuthorRepository>();
            collection.AddScoped<IBookRepository, BookRepository>();
        }
    }
}