﻿using SlevoDog.Models.CatalogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlevaDog.Models.CatalogViewModels
{
    public class SaleCollection
    {
        public List<Sale> collections;
        public SaleCollection()
        {
            collections = new List<Sale>();
        }
    }
}
