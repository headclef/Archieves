using Archieves.Application.Abstraction;
using Archieves.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class BookService : IBookService
    {
        IBookDal BookDal;
        public BookService() // Constructor
        {
            BookDal = new EfBookRepository();
        }
        public void Add(Book entity)
        {
            BookDal.Add(entity);
        }
        public void Delete(Book entity)
        {
            BookDal.Delete(entity);
        }
        public void Update(Book entity)
        {
            BookDal.Update(entity);
        }
        public ICollection<Book> GetAll()
        {
            return BookDal.GetAll();
        }
        public ICollection<Book> GetAll(int id)
        {
            return BookDal.GetAll(x => x.Id == id);
        }
        public Book GetById(int id)
        {
            return BookDal.GetById(id);
        }
    }
}