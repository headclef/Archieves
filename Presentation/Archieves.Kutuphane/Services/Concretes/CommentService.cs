using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.Wrappers;
using Archieves.Kutuphane.Services.Abstractions;
using AutoMapper;
using System.Linq.Expressions;

namespace Archieves.Kutuphane.Services.Concretes
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<ModelResponse<CommentViewModel>> AddCommentAsync(CommentAddModel model)
        {
            var result = new ModelResponse<CommentViewModel>();
            try
            {
                var comment = _mapper.Map<Comment>(model);
                var insertResult = await _commentRepository.AddAsync(comment);
                var commentViewModel = _mapper.Map<CommentViewModel>(insertResult);
                return result.Success(commentViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<CommentViewModel>> DeleteCommentAsync(int id)
        {
            var result = new ModelResponse<CommentViewModel>();
            try
            {
                var comment = await _commentRepository.GetByIdAsync(id);
                if (comment is null)
                {
                    return result.Fail($"No comment found with id {id}.");
                }
                var deleteResult = await _commentRepository.DeleteAsync(comment);
                var commentViewModel = _mapper.Map<CommentViewModel>(deleteResult);
                return result.Success(commentViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<List<CommentViewModel>>> GetAllCommentsAsync()
        {
            var result = new ModelResponse<List<CommentViewModel>>();
            try
            {
                var comment = _commentRepository.GetAllQuery().ToList();
                var commentViewModel = _mapper.Map<List<CommentViewModel>>(comment);
                return result.Success(commentViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }

        public async Task<ModelResponse<List<CommentViewModel>>> GetAllCommentsAsync(int id, bool status)
        {
            var result = new ModelResponse<List<CommentViewModel>>();
            try
            {
                var comments = _commentRepository.GetAllQuery().Where(x => x.UserId == id && x.Status == status).ToList();
                var commentViewModels = _mapper.Map<List<CommentViewModel>>(comments);
                return result.Success(commentViewModels);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }

        public async Task<ModelResponse<List<CommentViewModel>>> GetAllCommentsByBookIdAsync(int bookId)
        {
            var result = new ModelResponse<List<CommentViewModel>>();
            try
            {
                var comments = _commentRepository.GetAllQuery().Where(x => x.BookId == bookId).ToList();
                var commentViewModels = _mapper.Map<List<CommentViewModel>>(comments);
                return result.Success(commentViewModels);
            }
            catch (Exception ex)
            {
                return result.Fail($"An error occured: {ex.Message}.");
            }
        }
        public async Task<ModelResponse<CommentViewModel>> GetCommentByIdAsync(int id)
        {
            var result = new ModelResponse<CommentViewModel>();
            try
            {
                var comment = _commentRepository.GetByIdAsync(id);
                if (comment is null)
                {
                    return result.Fail($"No comment found with id {id}.");
                }
                var commentViewModel = _mapper.Map<CommentViewModel>(comment);
                return result.Success(commentViewModel);
            }
            catch (Exception ex)
            {
                return result.Fail($"An error occured: {ex.Message}.");
            }
        }
        public async Task<ModelResponse<CommentViewModel>> UpdateCommentAsync(CommentUpdateModel model)
        {
            var result = new ModelResponse<CommentViewModel>();
            try
            {
                var comment = await _commentRepository.GetByIdAsync(model.Id);
                var updateComment = _mapper.Map(model, comment);
                var updateResult = await _commentRepository.UpdateAsync(updateComment);
                var commentViewModel = _mapper.Map<CommentViewModel>(updateResult);
                return result.Success(commentViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
    }
}