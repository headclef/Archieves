using Archieves.Application.Abstraction;
using Archieves.Persistence.Concretes.Common;
using KütüphaneOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class BookRepository : IBookDal
    {
        public void Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Book> GetAll(Expression<Func<Book, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
