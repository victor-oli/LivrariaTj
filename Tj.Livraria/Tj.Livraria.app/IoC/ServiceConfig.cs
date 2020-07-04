using Microsoft.Extensions.DependencyInjection;
using Tj.Livraria.Domain.Interfaces.Service;
using Tj.Livraria.Domain.Services;

namespace Tj.Livraria.App.IoC
{
    public abstract class ServiceConfig
    {
        public static void Config(IServiceCollection collection)
        {
            collection.AddScoped<ISubjectService, SubjectService>();
            collection.AddScoped<IAuthorService, AuthorService>();
            collection.AddScoped<IBookService, BookService>();
        }
    }
}