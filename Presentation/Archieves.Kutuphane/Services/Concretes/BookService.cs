using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Kutuphane.Models.Book;
using Archieves.Kutuphane.Models.Wrappers;
using Archieves.Kutuphane.Services.Abstractions;
using AutoMapper;

namespace Archieves.Kutuphane.Services.Concretes
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<ModelResponse<BookViewModel>> AddBookModelAsync(BookAddModel model)
        {
            var result = new ModelResponse<BookViewModel>();
            try
            {
                var book = _mapper.Map<Book>(model);
                var insertResult = await _bookRepository.AddAsync(book);
                var bookViewModel = _mapper.Map<BookViewModel>(insertResult);
                return result.Success(bookViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<BookViewModel>> DeleteBookModelAsync(int id)
        {
            var result = new ModelResponse<BookViewModel>();
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                if (book is null)
                {
                    return result.Fail($"No book found with id {id}.");
                }
                /* Önemli Not:
                * Eğer silinecek olan kayı veritabanından tamamen silinmek istenmiyor, sadece aktiflik durumu değiştirilmek isteniyorsa;
                * 
                *                    ESKİ HALİ                  |                   YENİ HALİ
                *                                               |
                *                                               |   book.Status = false;
                * await _bookRepository.DeleteAsync(book);      |   await _bookRepository.UpdateAsync(book);
                *
                * Şeklinde bir yöntem izlenebilir.
                */
                var deleteResult = await _bookRepository.DeleteAsync(book);
                var bookViewModel = _mapper.Map<BookViewModel>(deleteResult);
                return result.Success(bookViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<List<BookViewModel>>> GetAllBooksAsync()
        {
            var result = new ModelResponse<List<BookViewModel>>();
            try
            {
                var books = _bookRepository.GetAllQuery().ToList();
                var bookViewModels = _mapper.Map<List<BookViewModel>>(books);
                return result.Success(bookViewModels);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<List<BookViewModel>>> GetAllBooksByIdAsync(int id)
        {
            var result = new ModelResponse<List<BookViewModel>>();
            try
            {
                var books = _bookRepository.GetAllQuery().Where(x => x.Id == id).ToList();
                var bookViewModels = _mapper.Map<List<BookViewModel>>(books);
                return result.Success(bookViewModels);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<BookViewModel>> GetBookByIdAsync(int id)
        {
            var result = new ModelResponse<BookViewModel>();
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                if (book is null)
                {
                    return result.Fail($"No book found with id {id}.");
                }
                var bookViewModel = _mapper.Map<BookViewModel>(book);
                return result.Success(bookViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<BookViewModel>> UpdateBookModelAsync(BookUpdateModel model)
        {
            var result = new ModelResponse<BookViewModel>();
            try
            {
                var book = _mapper.Map<Book>(model);
                var updateResult = await _bookRepository.UpdateAsync(book);
                var bookViewModel = _mapper.Map<BookViewModel>(updateResult);
                return result.Success(bookViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
    }
}
