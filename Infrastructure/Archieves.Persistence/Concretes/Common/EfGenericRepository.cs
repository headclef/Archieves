using Archieves.Application.Abstraction.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Concretes.Common
{
    public class EfGenericRepository<T> : GenericRepository<T>, IGenericDal<T> where T : class {}
}
