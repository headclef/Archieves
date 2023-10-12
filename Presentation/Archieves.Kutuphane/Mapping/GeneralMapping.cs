using Archieves.Domain.Entities;
using Archieves.Kutuphane.Models.Author;
using Archieves.Kutuphane.Models.Book;
using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.Rating;
using Archieves.Kutuphane.Models.Subscriber;
using Archieves.Kutuphane.Models.User;
using AutoMapper;

namespace Archieves.Kutuphane.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Author, AuthorViewModel>().ReverseMap();
            CreateMap<Author, AuthorAddModel>().ReverseMap();

            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Book, BookAddModel>().ReverseMap();

            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Comment, CommentAddModel>().ReverseMap();

            CreateMap<Rating, RatingViewModel>().ReverseMap();
            CreateMap<Rating, RatingAddModel>().ReverseMap();

            CreateMap<Subscriber, SubscriberViewModel>().ReverseMap();
            CreateMap<Subscriber, SubscriberAddModel>().ReverseMap();

            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, UserAddModel>().ReverseMap();

            CreateMap<UserViewModel, UserUpdateModel>().ReverseMap();
        }
    }
}
