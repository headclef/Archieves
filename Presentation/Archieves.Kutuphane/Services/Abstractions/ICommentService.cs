using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Models.Wrappers;
using System.Linq.Expressions;

namespace Archieves.Kutuphane.Services.Abstractions
{
    public interface ICommentService
    {
        Task<ModelResponse<CommentViewModel>> AddCommentAsync(CommentAddModel model);
        Task<ModelResponse<CommentViewModel>> UpdateCommentAsync(CommentUpdateModel model);
        Task<ModelResponse<CommentViewModel>> DeleteCommentAsync(int id);
        Task<ModelResponse<CommentViewModel>> GetCommentByIdAsync(int id);
        Task<ModelResponse<List<CommentViewModel>>> GetAllCommentsAsync();
        Task<ModelResponse<List<CommentViewModel>>> GetAllCommentsByUserIdAsync(int id);
        Task<ModelResponse<List<CommentViewModel>>> GetAllCommentsByUserIdandStatusAsync(int id, bool status);
        Task<ModelResponse<List<CommentViewModel>>> GetAllCommentsByBookIdAsync(int bookId);
    }
}
