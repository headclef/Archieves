using Archieves.Application.Abstraction;
using Archieves.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class AuthorService : IAuthorService
    {
        IAuthorDal AuthorDal;
        public AuthorService() // Constructor
        {
            AuthorDal = new EfAuthorRepository();
        }
        public void Add(Author entity)
        {
            AuthorDal.Add(entity);
        }
        public void Delete(Author entity)
        {
            AuthorDal.Delete(entity);
        }
        public void Update(Author entity)
        {
            AuthorDal.Update(entity);
        }
        public ICollection<Author> GetAll()
        {
            return AuthorDal.GetAll();
        }
        public ICollection<Author> GetAll(int id)
        {
            return AuthorDal.GetAll(x => x.Id == id);
        }
        public Author GetById(int id)
        {
            return AuthorDal.GetById(id);
        }
    }
}