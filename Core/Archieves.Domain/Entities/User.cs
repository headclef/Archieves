using KütüphaneOtomasyonu.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneOtomasyonu.Domain.Entities
{
    public class User : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(25)]
        public string Password { get; set; }

        [StringLength(13)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Address { get; set; }


        public string Image { get; set; }
        public bool Status { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
