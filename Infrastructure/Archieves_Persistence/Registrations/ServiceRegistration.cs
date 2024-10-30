using Archieves_Application.Interfaces.Services.Abstract;
using Archieves_Persistence.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Archieves_Persistence.Registrations
{
    public static class ServiceRegistration
    {
        public static void RegisterServiceRegistrations(this IServiceCollection services)
        {
            // Get the assembly
            var assembly = Assembly.GetExecutingAssembly();
            // Add the services to the assembly
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookCategoryService, BookCategoryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}