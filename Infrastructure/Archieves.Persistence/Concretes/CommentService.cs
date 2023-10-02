using Archieves.Application.Abstraction;
using Archieves.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class CommentService : ICommentService
    {
        ICommentDal CommentDal;
        public CommentService() // Constructor
        {
            CommentDal = new EfCommentRepository();
        }
        public void Add(Comment entity)
        {
            CommentDal.Add(entity);
        }
        public void Delete(Comment entity)
        {
            CommentDal.Delete(entity);
        }
        public void Update(Comment entity)
        {
            CommentDal.Update(entity);
        }
        public ICollection<Comment> GetAll()
        {
            return CommentDal.GetAll();
        }
        public ICollection<Comment> GetAll(int id)
        {
            return CommentDal.GetAll(x => x.Id == id);
        }
        public ICollection<Comment> GetAllByUserId(int id) // TODO: Yorumları kullanıcıya göre listeleme
        {
            return CommentDal.GetAll(x => x.UserId == id);
        }
        public Comment GetById(int id)
        {
            return CommentDal.GetById(id);
        }
    }
}