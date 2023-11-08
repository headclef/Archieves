using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Kutuphane.Models.Author;
using Archieves.Kutuphane.Models.Book;
using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.Rating;
using Archieves.Kutuphane.Models.Subscriber;
using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Models.Wrappers;
using Archieves.Kutuphane.Services.Abstractions;
using Archieves.Persistence.Contexts;
using AutoMapper;

namespace Archieves.Kutuphane.Services.Concretes
{
    public class ArchievesService : IArchievesService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IUserRepository _userRepository;
        private readonly ArchievesDbContext _context;
        private readonly IMapper _mapper;
        public ArchievesService
        (
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            ICommentRepository commentRepository,
            IRatingRepository ratingRepository,
            ISubscriberRepository subscriberRepository,
            IUserRepository userRepository,
            ArchievesDbContext context,
            IMapper mapper
        )
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _commentRepository = commentRepository;
            _ratingRepository = ratingRepository;
            _subscriberRepository = subscriberRepository;
            _userRepository = userRepository;
            _context = context;
            _mapper = mapper;
        }

        #region Author
        public async Task<ModelResponse<AuthorViewModel>> AddAuthorAsync(AuthorViewModel author)
        {
            var result = new ModelResponse<AuthorViewModel>();
            try
            {
                var authorEntity = _mapper.Map<Author>(author);
                var addedAuthor = await _authorRepository.AddAsync(authorEntity);
                var addedAuthorViewModel = _mapper.Map<AuthorViewModel>(addedAuthor);
                return result.Success(addedAuthorViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<AuthorViewModel>> UpdateAuthorAsync(AuthorViewModel author)
        {
            var result = new ModelResponse<AuthorViewModel>();
            try
            {
                var authorEntity = _mapper.Map<Author>(author);
                var updatedAuthor = await _authorRepository.UpdateAsync(authorEntity);
                var updatedAuthorViewModel = _mapper.Map<AuthorViewModel>(updatedAuthor);
                return result.Success(updatedAuthorViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<AuthorViewModel>> DeleteAuthorAsync(int id)
        {
            var result = new ModelResponse<AuthorViewModel>();
            try
            {
                var author = await _authorRepository.GetByIdAsync(id);
                var deletedAuthor = await _authorRepository.DeleteAsync(author);
                return result.Success();
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<AuthorViewModel>> GetAuthorAsync(int id)
        {
            var result = new ModelResponse<AuthorViewModel>();
            try
            {
                var author = await _authorRepository.GetByIdAsync(id);
                var authorViewModel = _mapper.Map<AuthorViewModel>(author);
                return result.Success(authorViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<AuthorViewModel>> GetAuthorAsync(AuthorViewModel author)
        {
            var result = new ModelResponse<AuthorViewModel>();
            try
            {
                var awaitModel = await _authorRepository.GetAllAsync();
                var model = awaitModel.FirstOrDefault(x => x.Name == author.Name && x.Surname == author.Surname);
                var authorViewModel = _mapper.Map<AuthorViewModel>(model);
                if (authorViewModel is not null)
                    return result.Success(authorViewModel);
                else
                    return result.Fail("Böyle bir yazar bulunamadı.");
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<List<AuthorViewModel>>> GetAuthorsAsync()
        {
            var result = new ModelResponse<List<AuthorViewModel>>();
            try
            {
                var authorModels = await GetAuthors();
                return result.Success(authorModels);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        #endregion
        #region Book
        public async Task<ModelResponse<BookViewModel>> AddBookAsync(BookViewModel book)
        {
            var result = new ModelResponse<BookViewModel>();
            try
            {
                var bookEntity = _mapper.Map<Book>(book);
                var addedBook = await _bookRepository.AddAsync(bookEntity);
                var addedBookViewModel = _mapper.Map<BookViewModel>(addedBook);
                return result.Success(addedBookViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<BookViewModel>> UpdateBookAsync(BookViewModel book)
        {
            var result = new ModelResponse<BookViewModel>();
            try
            {
                var bookEntity = _mapper.Map<Book>(book);
                var updatedBook = await _bookRepository.UpdateAsync(bookEntity);
                var updatedBookViewModel = _mapper.Map<BookViewModel>(updatedBook);
                return result.Success(updatedBookViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<BookViewModel>> DeleteBookAsync(int id)
        {
            var result = new ModelResponse<BookViewModel>();
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                var deletedBook = await _bookRepository.DeleteAsync(book);
                return result.Success();
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<BookViewModel>> GetBookAsync(int id)
        {
            var result = new ModelResponse<BookViewModel>();
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                var bookViewModel = _mapper.Map<BookViewModel>(book);
                return result.Success(bookViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<BookViewModel>> GetBookAsync(BookViewModel book)
        {
            var result = new ModelResponse<BookViewModel>();
            try
            {
                var modelBook = (await _bookRepository.GetAllAsync()).Where(x => x.Name == book.Name).FirstOrDefault();
                var bookViewModel = _mapper.Map<BookViewModel>(modelBook);
                return result.Success(bookViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<List<BookViewModel>>> GetBooksAsync()
        {
            var result = new ModelResponse<List<BookViewModel>>();
            try
            {
                var bookModels = await GetBooks();
                return result.Success(bookModels);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        #endregion
        #region Comment
        public async Task<ModelResponse<CommentViewModel>> AddCommentAsync(CommentViewModel comment)
        {
            var result = new ModelResponse<CommentViewModel>();
            try
            {
                var commentEntity = _mapper.Map<Comment>(comment);
                var addedComment = await _commentRepository.AddAsync(commentEntity);
                var addedCommentViewModel = _mapper.Map<CommentViewModel>(addedComment);
                return result.Success(addedCommentViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<CommentViewModel>> UpdateCommentAsync(CommentViewModel comment)
        {
            var result = new ModelResponse<CommentViewModel>();
            try
            {
                var commentEntity = _mapper.Map<Comment>(comment);
                var updatedComment = await _commentRepository.UpdateAsync(commentEntity);
                var updatedCommentViewModel = _mapper.Map<CommentViewModel>(updatedComment);
                return result.Success(updatedCommentViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<CommentViewModel>> DeleteCommentAsync(int id)
        {
            var result = new ModelResponse<CommentViewModel>();
            try
            {
                var comment = await _commentRepository.GetByIdAsync(id);
                var deletedComment = await _commentRepository.DeleteAsync(comment);
                return result.Success();
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<CommentViewModel>> GetCommentAsync(int id)
        {
            var result = new ModelResponse<CommentViewModel>();
            try
            {
                var comment = await _commentRepository.GetByIdAsync(id);
                var commentViewModel = _mapper.Map<CommentViewModel>(comment);
                return result.Success(commentViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<List<CommentViewModel>>> GetCommentsAsync()
        {
            var result = new ModelResponse<List<CommentViewModel>>();
            try
            {
                var commentModels = await GetComments();
                return result.Success(commentModels);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<List<CommentViewModel>>> GetCommentsAsync(int id)
        {
            var result = new ModelResponse<List<CommentViewModel>>();
            try
            {
                var commentModels = await _commentRepository.GetAllAsync();
                var comment = commentModels.Where(x => x.UserId == id).ToList();
                var commentViewModels = _mapper.Map<List<CommentViewModel>>(comment);
                return result.Success(commentViewModels);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        #endregion
        #region Rating
        public async Task<ModelResponse<RatingViewModel>> AddRatingAsync(RatingViewModel rating)
        {
            var result = new ModelResponse<RatingViewModel>();
            try
            {
                var ratingEntity = _mapper.Map<Rating>(rating);
                var addedRating = await _ratingRepository.AddAsync(ratingEntity);
                var addedRatingViewModel = _mapper.Map<RatingViewModel>(addedRating);
                return result.Success(addedRatingViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<RatingViewModel>> UpdateRatingAsync(RatingViewModel rating)
        {
            var result = new ModelResponse<RatingViewModel>();
            try
            {
                var ratingEntity = _mapper.Map<Rating>(rating);
                ratingEntity.Count = _ratingRepository.GetAllAsync().Result.Where(x => x.BookId == rating.BookId).FirstOrDefault().Count + 1;
                var updatedRating = await _ratingRepository.UpdateAsync(ratingEntity);
                var updatedRatingViewModel = _mapper.Map<RatingViewModel>(updatedRating);
                return result.Success(updatedRatingViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<RatingViewModel>> DeleteRatingAsync(int id)
        {
            var result = new ModelResponse<RatingViewModel>();
            try
            {
                var rating = await _ratingRepository.GetByIdAsync(id);
                var deletedRating = await _ratingRepository.DeleteAsync(rating);
                return result.Success();
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<RatingViewModel>> GetRatingAsync(int id)
        {
            var result = new ModelResponse<RatingViewModel>();
            try
            {
                var rating = await _ratingRepository.GetByIdAsync(id);
                var ratingViewModel = _mapper.Map<RatingViewModel>(rating);
                return result.Success(ratingViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<List<RatingViewModel>>> GetRatingsAsync()
        {
            var result = new ModelResponse<List<RatingViewModel>>();
            try
            {
                var ratingModels = await GetRatings();
                return result.Success(ratingModels);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<List<RatingViewModel>>> GetRatingsAsync(int id)
        {
            var result = new ModelResponse<List<RatingViewModel>>();
            try
            {
                var ratingModels = await _ratingRepository.GetAllAsync();
                var rating = ratingModels.Where(x => x.BookId == id).ToList();
                var ratingViewModels = _mapper.Map<List<RatingViewModel>>(rating);
                return result.Success(ratingViewModels);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        #endregion
        #region Subscriber
        public async Task<ModelResponse<SubscriberViewModel>> AddSubscriberAsync(SubscriberViewModel subscriber)
        {
            var result = new ModelResponse<SubscriberViewModel>();
            try
            {
                var subscriberEntity = _mapper.Map<Subscriber>(subscriber);
                var addedSubscriber = await _subscriberRepository.AddAsync(subscriberEntity);
                var addedSubscriberViewModel = _mapper.Map<SubscriberViewModel>(addedSubscriber);
                return result.Success(addedSubscriberViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<SubscriberViewModel>> UpdateSubscriberAsync(SubscriberViewModel subscriber)
        {
            var result = new ModelResponse<SubscriberViewModel>();
            try
            {
                var subscriberEntity = _mapper.Map<Subscriber>(subscriber);
                var updatedSubscriber = await _subscriberRepository.UpdateAsync(subscriberEntity);
                var updatedSubscriberViewModel = _mapper.Map<SubscriberViewModel>(updatedSubscriber);
                return result.Success(updatedSubscriberViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<SubscriberViewModel>> DeleteSubscriberAsync(int id)
        {
            var result = new ModelResponse<SubscriberViewModel>();
            try
            {
                var subscriber = await _subscriberRepository.GetByIdAsync(id);
                var deletedSubscriber = await _subscriberRepository.DeleteAsync(subscriber);
                return result.Success();
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<SubscriberViewModel>> GetSubscriberAsync(int id)
        {
            var result = new ModelResponse<SubscriberViewModel>();
            try
            {
                var subscriber = await _subscriberRepository.GetByIdAsync(id);
                var subscriberViewModel = _mapper.Map<SubscriberViewModel>(subscriber);
                return result.Success(subscriberViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<List<SubscriberViewModel>>> GetSubscribersAsync()
        {
            var result = new ModelResponse<List<SubscriberViewModel>>();
            try
            {
                var subscriberModels = await GetSubscribers();
                return result.Success(subscriberModels);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        #endregion
        #region User
        public async Task<ModelResponse<UserViewModel>> AddUserAsync(UserViewModel user)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var userEntity = _mapper.Map<User>(user);
                var addedUser = await _userRepository.AddAsync(userEntity);
                var addedUserViewModel = _mapper.Map<UserViewModel>(addedUser);
                return result.Success(addedUserViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<UserViewModel>> UpdateUserAsync(UserViewModel user)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var userEntity = _mapper.Map<User>(user);
                var updatedUser = await _userRepository.UpdateAsync(userEntity);
                var updatedUserViewModel = _mapper.Map<UserViewModel>(updatedUser);
                return result.Success(updatedUserViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<UserViewModel>> DeleteUserAsync(int id)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                var deletedUser = await _userRepository.DeleteAsync(user);
                return result.Success();
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<UserViewModel>> GetUserAsync(int id)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                var userViewModel = _mapper.Map<UserViewModel>(user);
                return result.Success(userViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<UserViewModel>> GetUserAsync(UserViewModel user)
        {
            var result = new ModelResponse<UserViewModel>();
            try
            {
                var awaitModel = await _userRepository.GetAllAsync();
                var model = awaitModel.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                var userViewModel = _mapper.Map<UserViewModel>(model);
                if (userViewModel is not null)
                    return result.Success(userViewModel);
                else
                    return result.Fail("Böyle bir kullanıcı bulunamadı.");
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<ModelResponse<List<UserViewModel>>> GetUsersAsync()
        {
            var result = new ModelResponse<List<UserViewModel>>();
            try
            {
                var userModels = await GetUsers();
                return result.Success(userModels);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        #endregion
        #region Methods
        public async Task<List<AuthorViewModel>> GetAuthors()
        {
            var result = from author in _context.Set<Author>()
                         join book in _context.Set<Book>() on author.Id equals book.AuthorId into books
                         from book in _context.Set<Book>().DefaultIfEmpty()
                         select new AuthorViewModel
                         {
                             Id = author.Id,
                             Name = author.Name,
                             Surname = author.Surname,
                             Description = author.Description,
                             Date = author.Date,
                             Status = author.Status,
                         };
            return result.ToList();
        }
        public async Task<List<BookViewModel>> GetBooks()
        {
            var result = from book in _context.Set<Book>()
                         join author in _context.Set<Author>() on book.AuthorId equals author.Id into authors
                         from author in _context.Set<Author>().DefaultIfEmpty()
                         select new BookViewModel
                         {
                             Id = book.Id,
                             Name = book.Name,
                             AuthorId = book.AuthorId,
                             AuthorName = author.Name,
                             AuthorSurname = author.Surname,
                             Description = book.Description,
                             Image = book.Image,
                             Date = book.Date,
                             Status = book.Status,
                         };
            return result.ToList();
        }
        public async Task<List<CommentViewModel>> GetComments()
        {
            var result = from comment in _context.Set<Comment>()
                         join book in _context.Set<Book>() on comment.BookId equals book.Id into books
                         from book in _context.Set<Book>().DefaultIfEmpty()
                         join user in _context.Set<User>() on comment.UserId equals user.Id into users
                         from user in _context.Set<User>().DefaultIfEmpty()
                         select new CommentViewModel
                         {
                             Id = comment.Id,
                             Content = comment.Content,
                             Rate = comment.Rate,
                             BookId = comment.BookId,
                             BookName = book.Name,
                             UserId = comment.UserId,
                             UserName = user.Name,
                             UserSurname = user.Surname,
                             Date = comment.Date,
                             Status = comment.Status,
                         };
            return result.ToList();
        }
        public async Task<List<RatingViewModel>> GetRatings()
        {
            var result = from rating in _context.Set<Rating>()
                         join book in _context.Set<Book>() on rating.BookId equals book.Id into books
                         from book in _context.Set<Book>().DefaultIfEmpty()
                         select new RatingViewModel
                         {
                             Id = rating.Id,
                             Rate = rating.Rate,
                             Count = rating.Count,
                             BookId = rating.BookId,
                             BookName = book.Name,
                             Date = rating.Date,
                             Status = rating.Status,
                         };
            return result.ToList();
        }
        public async Task<List<SubscriberViewModel>> GetSubscribers()
        {
            var result = from subscriber in _context.Set<Subscriber>()
                         select new SubscriberViewModel
                         {
                             Id = subscriber.Id,
                             Email = subscriber.Email,
                             Date = subscriber.Date,
                             Status = subscriber.Status,
                         };
            return result.ToList();
        }
        public async Task<List<UserViewModel>> GetUsers()
        {
            var result = from user in _context.Set<User>()
                         select new UserViewModel
                         {
                             Id = user.Id,
                             Name = user.Name,
                             Surname = user.Surname,
                             Email = user.Email,
                             Password = user.Password,
                             Phone = user.Phone,
                             Address = user.Address,
                             Image = user.Image,
                             Date = user.Date,
                             Status = user.Status,
                         };
            return result.ToList();
        }
        #endregion
    }
}