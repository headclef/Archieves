using Archieves.Kutuphane.Models.Book;

namespace Archieves.Kutuphane.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, IBookPagerModel pager)
        {
            if (pager.Size != 0 && pager.Number != 0)
            {
                query = query
                    .Skip((pager.Number - 1) * pager.Size)
                    .Take(pager.Size);
            }
            return query;
        }
    }
}
