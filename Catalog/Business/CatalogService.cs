using AutoMapper;
using Catalog.Business.DTOObjects;
using Catalog.Dal.Entities;
using Catalog.Dal.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Business
{
    public class CatalogService
    {
        private readonly ISaleRepository _loadCatalog;

        public CatalogService(ISaleRepository loadCatalog)
        {
            _loadCatalog = loadCatalog;
        }

        public List<Sale> LoadAll(string sortOrder)
        {
            var fullCatalog = _loadCatalog.LoadAll();
            switch (sortOrder)
            {
                case "price_desc":
                    fullCatalog = fullCatalog.OrderBy(s => s.PriceAfterSale).ToList();
                    break;
                case "new_desc":
                    fullCatalog = fullCatalog.OrderByDescending(s => s.DateInsert).ToList();
                    break;
                case "sale_desc":
                    fullCatalog = fullCatalog.OrderByDescending(s => s.PercentSale).ToList();
                    break;
            }
            return fullCatalog.ToList();
        }

        public Sale LoadById(int id)
        {
            return _loadCatalog.LoadById(id);
        }
    }
}
