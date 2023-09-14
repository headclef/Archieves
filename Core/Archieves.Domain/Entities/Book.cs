using KütüphaneOtomasyonu.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KütüphaneOtomasyonu.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
