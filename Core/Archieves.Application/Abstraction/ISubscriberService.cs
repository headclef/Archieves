﻿using Archieves.Application.Abstraction.Common;
using Archieves.Domain.Entities;
using KütüphaneOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Application.Abstraction
{
    public interface ISubscriberService : IGenericService<Subscriber>
    {
        ICollection<Subscriber> GetAll(int id);
    }
}
