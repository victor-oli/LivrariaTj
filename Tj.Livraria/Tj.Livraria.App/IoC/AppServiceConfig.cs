using Microsoft.Extensions.DependencyInjection;
using Tj.Livraria.App.AppServices;
using Tj.Livraria.App.Interfacies;

namespace Tj.Livraria.App.IoC
{
    public abstract class AppServiceConfig
    {
        public static void Config(IServiceCollection collection)
        {
            collection.AddScoped<ISubjectAppService, SubjectAppService>();
            collection.AddScoped<IAuthorAppService, AuthorAppService>();
            collection.AddScoped<IBookAppService, BookAppService>();
        }
    }
}