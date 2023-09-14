﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Application.Abstraction.Common
{
    public interface IGenericService<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        ICollection<T> GetAll();
        T GetById(int id);
    }
}
