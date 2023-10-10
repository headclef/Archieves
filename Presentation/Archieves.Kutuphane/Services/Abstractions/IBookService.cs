using Archieves.Kutuphane.Models.Book;
using Archieves.Kutuphane.Models.Wrappers;

namespace Archieves.Kutuphane.Services.Abstractions
{
    public interface IBookService
    {
        Task<ModelResponse<BookViewModel>> AddBookModelAsync(BookAddModel model);
        Task<ModelResponse<BookViewModel>> UpdateBookModelAsync(BookUpdateModel model);
        Task<ModelResponse<BookViewModel>> DeleteBookModelAsync(int id);
        Task<ModelResponse<BookViewModel>> GetBookByIdAsync(int id);
        Task<ModelResponse<List<BookViewModel>>> GetAllBooksAsync();
        Task<ModelResponse<List<BookViewModel>>> GetAllBooksByIdAsync(int id);
    }
}
