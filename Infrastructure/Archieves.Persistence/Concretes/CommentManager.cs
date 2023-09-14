using Archieves.Application.Abstraction;
using KütüphaneOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class CommentManager : ICommentService
    {
        ICommentDal CommentDal;
        public CommentManager(ICommentDal commentDal)
        {
            CommentDal = commentDal;
        }
        public void Add(Comment entity)
        {
            CommentDal.Add(entity);
        }

        public void Delete(Comment entity)
        {
            CommentDal.Delete(entity);
        }

        public ICollection<Comment> GetAll(int id)
        {
            return CommentDal.GetAll(x => x.Id == id);
        }

        public ICollection<Comment> GetAll()
        {
            return CommentDal.GetAll();
        }

        public Comment GetById(int id)
        {
            return CommentDal.GetById(id);
        }

        public void Update(Comment entity)
        {
            CommentDal.Update(entity);
        }
    }
}