using Archieves.Application.Abstraction.Common;
using Archieves.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes.Common
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T t)
        {
            using (var c = new ArchievesDbContext())
            {
                c.Add(t);
                c.SaveChanges();
            }
        }

        public void Update(T t)
        {
            using (var c = new ArchievesDbContext())
            {
                c.Update(t);
                c.SaveChanges();
            }
        }

        public void Delete(T t)
        {
            using (var c = new ArchievesDbContext())
            {
                c.Remove(t);
                c.SaveChanges();
            }
        }

        public ICollection<T> GetAll()
        {
            using (var c = new ArchievesDbContext())
            {
                return c.Set<T>().ToList();
            }
        }
        public ICollection<T> GetAll(Expression<Func<T, bool>> filter)
        {
            using (var c = new ArchievesDbContext())
            {
                return c.Set<T>().Where(filter).ToList();
            }
        }

        public T GetById(int id)
        {
            using (var c = new ArchievesDbContext())
            {
                return c.Set<T>().Find(id);
            }
        }
    }
}
