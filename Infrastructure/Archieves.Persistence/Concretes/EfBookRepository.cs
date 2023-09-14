using Archieves.Application.Abstraction;
using Archieves.Persistence.Concretes.Common;
using KütüphaneOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class EfBookRepository : GenericRepository<Book>, IBookDal {}
}
