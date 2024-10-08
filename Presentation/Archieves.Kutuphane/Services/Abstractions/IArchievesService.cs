using Archieves.Kutuphane.Models.Author;
using Archieves.Kutuphane.Models.Book;
using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.Message;
using Archieves.Kutuphane.Models.Notification;
using Archieves.Kutuphane.Models.Rating;
using Archieves.Kutuphane.Models.Subscriber;
using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Models.Wrappers;

namespace Archieves.Kutuphane.Services.Abstractions
{
    public interface IArchievesService
    {
        #region Author
        Task<ModelResponse<AuthorViewModel>> AddAuthorAsync(AuthorViewModel author);
        Task<ModelResponse<AuthorViewModel>> UpdateAuthorAsync(AuthorViewModel author);
        Task<ModelResponse<AuthorViewModel>> DeleteAuthorAsync(int id);
        Task<ModelResponse<AuthorViewModel>> GetAuthorAsync(int id);
        Task<ModelResponse<AuthorViewModel>> GetAuthorAsync(AuthorViewModel author);
        Task<ModelResponse<List<AuthorViewModel>>> GetAuthorsAsync();
        #endregion
        #region Book
        Task<ModelResponse<BookViewModel>> AddBookAsync(BookViewModel book);
        Task<ModelResponse<BookViewModel>> UpdateBookAsync(BookViewModel book);
        Task<ModelResponse<BookViewModel>> DeleteBookAsync(int id);
        Task<ModelResponse<BookViewModel>> GetBookAsync(int id);
        Task<ModelResponse<BookViewModel>> GetBookAsync(BookViewModel book);
        Task<ModelResponse<List<BookViewModel>>> GetBooksAsync();
        Task<ModelResponse<List<BookViewModel>>> GetBooksAsync(string name);
        Task<PagedModelResponse<List<BookViewModel>>> GetBookListAsync(BookPagerModel bookPagerModel);
        Task<PagedModelResponse<List<BookViewModel>>> GetBookListAsync(BookPagerModel bookPagerModel, string name);
        #endregion
        #region Comment
        Task<ModelResponse<CommentViewModel>> AddCommentAsync(CommentViewModel comment);
        Task<ModelResponse<CommentViewModel>> UpdateCommentAsync(CommentViewModel comment);
        Task<ModelResponse<CommentViewModel>> DeleteCommentAsync(int id);
        Task<ModelResponse<CommentViewModel>> GetCommentAsync(int id);
        Task<ModelResponse<List<CommentViewModel>>> GetCommentsAsync();
        Task<ModelResponse<List<CommentViewModel>>> GetCommentsAsync(int id);
        #endregion
        #region Rating
        Task<ModelResponse<RatingViewModel>> AddRatingAsync(RatingViewModel rating);
        Task<ModelResponse<RatingViewModel>> UpdateRatingAsync(RatingViewModel rating);
        Task<ModelResponse<RatingViewModel>> DeleteRatingAsync(int id);
        Task<ModelResponse<RatingViewModel>> GetRatingAsync(int id);
        Task<ModelResponse<List<RatingViewModel>>> GetRatingsAsync();
        Task<ModelResponse<List<RatingViewModel>>> GetRatingsAsync(int? id);
        #endregion
        #region Subscriber
        Task<ModelResponse<SubscriberViewModel>> AddSubscriberAsync(SubscriberViewModel subscriber);
        Task<ModelResponse<SubscriberViewModel>> UpdateSubscriberAsync(SubscriberViewModel subscriber);
        Task<ModelResponse<SubscriberViewModel>> DeleteSubscriberAsync(int id);
        Task<ModelResponse<SubscriberViewModel>> GetSubscriberAsync(int id);
        Task<ModelResponse<List<SubscriberViewModel>>> GetSubscribersAsync();
        #endregion
        #region User
        Task<ModelResponse<UserViewModel>> AddUserAsync(UserViewModel user);
        Task<ModelResponse<UserViewModel>> UpdateUserAsync(UserViewModel user);
        Task<ModelResponse<UserViewModel>> DeleteUserAsync(int id);
        Task<ModelResponse<UserViewModel>> GetUserAsync(int id);
        Task<ModelResponse<UserViewModel>> GetUserAsync(UserViewModel user);
        Task<ModelResponse<List<UserViewModel>>> GetUsersAsync();
        #endregion
        #region Notification
        Task<ModelResponse<NotificationViewModel>> AddNotificationAsync(NotificationViewModel notification);
        Task<ModelResponse<NotificationViewModel>> UpdateNotificationAsync(NotificationViewModel notification);
        Task<ModelResponse<NotificationViewModel>> DeleteNotificationAsync(int id);
        Task<ModelResponse<NotificationViewModel>> GetNotificationAsync(int id);
        Task<ModelResponse<List<NotificationViewModel>>> GetNotificationsAsync();
        #endregion
        #region Message
        Task<ModelResponse<MessageViewModel>> AddMessageAsync(MessageViewModel messageViewModel);
        Task<ModelResponse<MessageViewModel>> UpdateMessageAsync(MessageViewModel messageViewModel);
        Task<ModelResponse<MessageViewModel>> DeleteMessageAsync(int id);
        Task<ModelResponse<MessageViewModel>> GetMessageAsync(int id);
        Task<ModelResponse<List<MessageViewModel>>> GetMessagesAsync();
        Task<ModelResponse<List<MessageViewModel>>> GetMessagesAsync(int? recieverId);
        Task<ModelResponse<List<MessageViewModel>>> GetMessagesAsync(int? recieverId, int? senderId);
        #endregion
        #region Methods
        Task<List<BookViewModel>> LatestBooks();
        #endregion
    }
}