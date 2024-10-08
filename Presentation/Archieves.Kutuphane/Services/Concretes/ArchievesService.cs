using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Kutuphane.Extensions;
using Archieves.Kutuphane.Models.Author;
using Archieves.Kutuphane.Models.Book;
using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.Message;
using Archieves.Kutuphane.Models.Notification;
using Archieves.Kutuphane.Models.Rating;
using Archieves.Kutuphane.Models.Subscriber;
using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Models.Wrappers;
using Archieves.Kutuphane.Services.Abstractions;
using Archieves.Persistence.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
        private readonly INotificationRepository _notificationRepository;
        private readonly IMessageRepository _messageRepository;
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
            INotificationRepository notificationRepository,
            IMessageRepository messageRepository,
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
            _notificationRepository = notificationRepository;
            _messageRepository = messageRepository;
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
        public async Task<ModelResponse<List<BookViewModel>>> GetBooksAsync(string name)
        {
            var result = new ModelResponse<List<BookViewModel>>();
            try
            {
                var bookModels = (await GetBooks()).Where(x => x.Name.Contains(name)).ToList();
                return result.Success(bookModels);
            }
            catch (Exception ex)
            {
                return result.Fail($"Bir hata oluştu: {ex.Message}");
            }
        }
        public async Task<PagedModelResponse<List<BookViewModel>>> GetBookListAsync(BookPagerModel bookPagerModel)
        {
            var result = new PagedModelResponse<List<BookViewModel>>();
            try
            {
                var query = GetBooksQuery();
                query = query.Where(x => x.Status == true);
                query = query.OrderBy(x => x.Id);
                var totalItemCount = query.Count();
                var size = bookPagerModel.Size == 0 ? 1 : bookPagerModel.Size;
                var number = (totalItemCount / size) + (totalItemCount % size > 0 ? 1 : 0);
                var bookEntities = await query.Paginate(bookPagerModel).ToListAsync();
                var bookViewModels = _mapper.Map<List<BookViewModel>>(bookEntities);
                return result.Success(
                    bookViewModels,
                    bookPagerModel.Number,
                    bookViewModels.Count,
                    totalItemCount,
                    number);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<PagedModelResponse<List<BookViewModel>>> GetBookListAsync(BookPagerModel bookPagerModel, string name)
        {
            var result = new PagedModelResponse<List<BookViewModel>>();
            try
            {
                var query = GetBooksQuery(name);
                query = query.Where(x => x.Status == true);
                query = query.OrderBy(x => x.Id);
                var totalItemCount = query.Count();
                var size = bookPagerModel.Size == 0 ? 1 : bookPagerModel.Size;
                var number = (totalItemCount / size) + (totalItemCount % size > 0 ? 1 : 0);
                var bookEntities = await query.Paginate(bookPagerModel).ToListAsync();
                var bookViewModels = _mapper.Map<List<BookViewModel>>(bookEntities);
                return result.Success(
                    bookViewModels,
                    bookPagerModel.Number,
                    bookViewModels.Count,
                    totalItemCount,
                    number);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
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
                rating.Id = (await _ratingRepository.GetByBookIdAsync(rating.BookId)).Id;
                var ratingEntity = await _ratingRepository.GetByIdAsync(rating.Id);
                ratingEntity.Rate += rating.Rate;
                ratingEntity.Count += 1;
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
        public async Task<ModelResponse<List<RatingViewModel>>> GetRatingsAsync(int? id)
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
        #region Notification
        public async Task<ModelResponse<NotificationViewModel>> AddNotificationAsync(NotificationViewModel notification)
        {
            var result = new ModelResponse<NotificationViewModel>();
            try
            {
                var notificationEntity = _mapper.Map<Notification>(notification);
                var addedNotification = await _notificationRepository.AddAsync(notificationEntity);
                var addedNotificationViewModel = _mapper.Map<NotificationViewModel>(addedNotification);
                return result.Success(addedNotificationViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<ModelResponse<NotificationViewModel>> UpdateNotificationAsync(NotificationViewModel notification)
        {
            var result = new ModelResponse<NotificationViewModel>();
            try
            {
                var notificationEntity = _mapper.Map<Notification>(notification);
                var updatedNotification = await _notificationRepository.UpdateAsync(notificationEntity);
                var updatedNotificationViewModel = _mapper.Map<NotificationViewModel>(updatedNotification);
                return result.Success(updatedNotificationViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<ModelResponse<NotificationViewModel>> DeleteNotificationAsync(int id)
        {
            var result = new ModelResponse<NotificationViewModel>();
            try
            {
                var notification = await _notificationRepository.GetByIdAsync(id);
                var deletedNotification = await _notificationRepository.DeleteAsync(notification);
                return result.Success();
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<ModelResponse<NotificationViewModel>> GetNotificationAsync(int id)
        {
            var result = new ModelResponse<NotificationViewModel>();
            try
            {
                var notification = await _notificationRepository.GetByIdAsync(id);
                var notificationViewModel = _mapper.Map<NotificationViewModel>(notification);
                return result.Success(notificationViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<ModelResponse<List<NotificationViewModel>>> GetNotificationsAsync()
        {
            var result = new ModelResponse<List<NotificationViewModel>>();
            try
            {
                var notificationModels = await _notificationRepository.GetAllAsync();
                var notificationViewModels = _mapper.Map<List<NotificationViewModel>>(notificationModels);
                return result.Success(notificationViewModels);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        #endregion
        #region Message
        public async Task<ModelResponse<MessageViewModel>> AddMessageAsync(MessageViewModel messageViewModel)
        {
            var result= new ModelResponse<MessageViewModel>();
            try
            {
                var messageEntity = _mapper.Map<Message>(messageViewModel);
                var addedMessage = await _messageRepository.AddAsync(messageEntity);
                var addedMessageViewModel = _mapper.Map<MessageViewModel>(addedMessage);
                return result.Success(addedMessageViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<ModelResponse<MessageViewModel>> UpdateMessageAsync(MessageViewModel messageViewModel)
        {
            var result = new ModelResponse<MessageViewModel>();
            try
            {
                var messageEntity = _mapper.Map<Message>(messageViewModel);
                var updatedMessage = await _messageRepository.UpdateAsync(messageEntity);
                var updatedMessageViewModel = _mapper.Map<MessageViewModel>(updatedMessage);
                return result.Success(updatedMessageViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<ModelResponse<MessageViewModel>> DeleteMessageAsync(int id)
        {
            var result = new ModelResponse<MessageViewModel>();
            try
            {
                var message = await _messageRepository.GetByIdAsync(id);
                var deletedMessage = await _messageRepository.DeleteAsync(message);
                return result.Success();
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<ModelResponse<MessageViewModel>> GetMessageAsync(int id)
        {
            var result = new ModelResponse<MessageViewModel>();
            try
            {
                var message = await _messageRepository.GetByIdAsync(id);
                var messageViewModel = _mapper.Map<MessageViewModel>(message);
                return result.Success(messageViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<ModelResponse<List<MessageViewModel>>> GetMessagesAsync()
        {
            var result = new ModelResponse<List<MessageViewModel>>();
            try
            {
                var messageModels = await GetMessages();
                return result.Success(messageModels);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<ModelResponse<List<MessageViewModel>>> GetMessagesAsync(int? recieverId)
        {
            var result = new ModelResponse<List<MessageViewModel>>();
            try
            {
                var messageModels = (await GetMessages()).Where(x => x.Receiver == recieverId).ToList();
                return result.Success(messageModels);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        public async Task<ModelResponse<List<MessageViewModel>>> GetMessagesAsync(int? recieverId, int? senderId)
        {
            var result = new ModelResponse<List<MessageViewModel>>();
            try
            {
                var messageModels = await GetMessages(recieverId, senderId);
                return result.Success(messageModels);
            }
            catch (Exception ex)
            {
                return result.Fail(ex.Message);
            }
        }
        #endregion
        #region Methods
        public async Task<List<AuthorViewModel>> GetAuthors()
        {
            var result = (from author in _context.Set<Author>()
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
                          }).Distinct();
            return result.ToList();
        }
        public IQueryable<BookViewModel> GetBooksQuery()
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
            return result;
        }
        public IQueryable<BookViewModel> GetBooksQuery(string name)
        {
            var result = from book in _context.Set<Book>()
                         where book.Name.Contains(name)
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
            return result;
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
        public async Task<List<BookViewModel>> LatestBooks()
        {
            var result = _context.Set<Book>()
                         .OrderByDescending(x => x.Id)
                         .Take(4)
                         .ToList();
            var books = _mapper.Map<List<BookViewModel>>(result);
            return books;
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
        public async Task<List<MessageViewModel>> GetMessages()
        {
            var result = from messages in _context.Set<Message>()
                         join sender in _context.Set<User>() on messages.Sender equals sender.Id into senders
                         from sender in _context.Set<User>().DefaultIfEmpty()
                         join receiver in _context.Set<User>() on messages.Receiver equals receiver.Id into receivers
                         from receiver in _context.Set<User>().DefaultIfEmpty()
                         select new MessageViewModel
                         {
                             Id = messages.Id,
                             Sender = messages.Sender,
                             SenderName = sender.Name,
                             SenderSurname = sender.Surname,
                             Receiver = messages.Receiver,
                             ReceiverName = receiver.Name,
                             ReceiverSurname = receiver.Surname,
                             Subject = messages.Subject,
                             Details = messages.Details,
                             Date = messages.Date,
                             Status = messages.Status,
                         };
            return result.ToList();
        }
        public async Task<List<MessageViewModel>> GetMessages(int? receiverId, int? senderId)
        {
            var messages = await _context.Messages
                .Where(m => (m.Sender == senderId && m.Receiver == receiverId) || (m.Sender == receiverId && m.Receiver == senderId))
                .ToListAsync();

            var senderUserIds = messages.Select(m => m.Sender).Distinct().ToList();
            var receiverUserIds = messages.Select(m => m.Receiver).Distinct().ToList();

            var users = await _context.Users
                .Where(u => senderUserIds.Contains(u.Id) || receiverUserIds.Contains(u.Id))
                .ToListAsync();

            return messages.Select(m => new MessageViewModel
            {
                Id = m.Id,
                Sender = m.Sender,
                SenderName = users.First(u => u.Id == m.Sender).Name,
                SenderSurname = users.First(u => u.Id == m.Sender).Surname,
                Receiver = m.Receiver,
                ReceiverName = users.First(u => u.Id == m.Receiver).Name,
                ReceiverSurname = users.First(u => u.Id == m.Receiver).Surname,
                Subject = m.Subject,
                Details = m.Details,
                Date = m.Date,
                Status = m.Status,
            }).ToList();
        }
        #endregion
    }
}