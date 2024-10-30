using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Application.Interfaces.Repositories.Abstract.Common;
using Archieves_Persistence.Repositories.Concrete;
using Archieves_Persistence.Repositories.Concrete.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Archieves_Persistence.Registrations
{
    public static class RepositoryRegistrations
    {
        public static void RegisterRepositoryRegistrations(this IServiceCollection services)
        {
            // Get the assembly
            var assembly = Assembly.GetExecutingAssembly();
            // Add the repositories to the assembly
            services.AddScoped(typeof(IArchievesRepository<>), typeof(ArchievesRepository<>));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}