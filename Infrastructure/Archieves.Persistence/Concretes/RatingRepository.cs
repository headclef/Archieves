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
    public class RatingRepository : IRatingDal
    {
        public void Add(Rating entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Rating entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Rating> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Rating> GetAll(Expression<Func<Rating, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Rating GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Rating entity)
        {
            throw new NotImplementedException();
        }
    }
}
