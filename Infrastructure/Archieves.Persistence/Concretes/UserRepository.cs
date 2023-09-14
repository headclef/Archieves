using Archieves.Application.Abstraction;
using KütüphaneOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class UserRepository : IUserDal
    {
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAll(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
