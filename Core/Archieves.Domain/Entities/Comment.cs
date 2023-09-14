using KütüphaneOtomasyonu.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneOtomasyonu.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public string Username { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
