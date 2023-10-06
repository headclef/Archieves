using Archieves.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Domain.Entities
{
    public class Rating : BaseEntity
    {
        [Range(0, 10)]
        public int Rate { get; set; }
        public int Count { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
