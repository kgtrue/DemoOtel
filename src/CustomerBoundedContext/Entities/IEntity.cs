﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBoundedContext.Entities
{
    public interface IEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
