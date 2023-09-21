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
    public class SubscriberRepository : ISubscriberDal
    {
        public void Add(Subscriber entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Subscriber entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Subscriber> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Subscriber> GetAll(Expression<Func<Subscriber, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Subscriber GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Subscriber entity)
        {
            throw new NotImplementedException();
        }
    }
}
