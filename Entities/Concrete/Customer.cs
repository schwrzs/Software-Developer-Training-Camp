﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity

    {
        public string ProductId { get; set; }
        public string ContactNAme { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
 

    }
}
