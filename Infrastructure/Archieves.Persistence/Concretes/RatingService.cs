using Archieves.Application.Abstraction;
using Archieves.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class RatingService : IRatingService
    {
        IRatingDal _ratingDal;
        public RatingService()
        {
            _ratingDal = new EfRatingRepository();
        }
        public void Add(Rating entity)
        {
            _ratingDal.Add(entity);
        }
        public void Delete(Rating entity)
        {
            _ratingDal.Delete(entity);
        }
        public void Update(Rating entity)
        {
            _ratingDal.Update(entity);
        }
        public ICollection<Rating> GetAll()
        {
            return _ratingDal.GetAll();
        }
        public ICollection<Rating> GetAll(int id)
        {
            return _ratingDal.GetAll(x => x.Id == id);
        }
        public Rating GetById(int id)
        {
            return _ratingDal.GetById(id);
        }
    }
}
