using Archieves_Application.Dtos;
using Archieves_Domain.Entities;
using AutoMapper;

namespace Archieves_Persistence.Mapper
{
    public class ArchievesMapper : Profile
    {
        public ArchievesMapper()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<BookCategory, BookCategoryDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<Log, LogDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}