using Archieves.Application.Abstraction;
using Archieves.Domain.Entities;
using Archieves.Persistence.Concretes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes
{
    public class EfUserRepository : GenericRepository<User>, IUserDal {}
}
