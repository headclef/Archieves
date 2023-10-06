using Archieves.Application.Abstraction;
using Archieves.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class AuthorRepository : IAuthorDal
    {
        public void Add(Author entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(Author entity)
        {
            throw new NotImplementedException();
        }
        public ICollection<Author> GetAll()
        {
            throw new NotImplementedException();
        }
        public ICollection<Author> GetAll(Expression<Func<Author, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}