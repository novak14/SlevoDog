using Catalog.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Dal.Repository.Abstraction
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> LoadAll();
        Sale LoadById(int id);
    }
}
