using Archieves.Application.Abstraction;
using Archieves.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class SubscriberService : ISubscriberService
    {
        ISubscriberDal subscriberDal;
        public SubscriberService() // Contructor
        {
            subscriberDal = new EfSubscriberRepository();
        }
        public void Add(Subscriber entity)
        {
            subscriberDal.Add(entity);
        }
        public void Delete(Subscriber entity)
        {
            subscriberDal.Delete(entity);
        }
        public void Update(Subscriber entity)
        {
            subscriberDal.Update(entity);
        }
        public ICollection<Subscriber> GetAll()
        {
            return subscriberDal.GetAll();
        }
        public ICollection<Subscriber> GetAll(int id)
        {
            return subscriberDal.GetAll(x => x.Id == id);
        }
        public Subscriber GetById(int id)
        {
            return subscriberDal.GetById(id);
        }
    }
}