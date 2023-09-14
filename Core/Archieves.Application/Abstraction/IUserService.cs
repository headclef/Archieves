using Archieves.Application.Abstraction.Common;
using KütüphaneOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Application.Abstraction
{
    public interface IUserService : IGenericService<User>
    {
        List<User> GetAll(int id);
    }
}
