﻿using KütüphaneOtomasyonu.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Domain.Entities
{
    public class Subscriber : BaseEntity
    {
        public string Email { get; set; }
    }
}
