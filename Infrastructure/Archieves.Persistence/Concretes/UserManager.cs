using Archieves.Application.Abstraction;
using KütüphaneOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal UserDal;
        public UserManager(IUserDal userDal)
        {
            UserDal = userDal;
        }
        public void Add(User entity)
        {
            UserDal.Add(entity);
        }

        public void Delete(User entity)
        {
            UserDal.Delete(entity);
        }

        public ICollection<User> GetAll(int id)
        {
            return UserDal.GetAll(x => x.Id == id);
        }

        public ICollection<User> GetAll()
        {
            return UserDal.GetAll();
        }

        public User GetById(int id)
        {
            return UserDal.GetById(id);
        }

        public void Update(User entity)
        {
            UserDal.Update(entity);
        }
    }
}