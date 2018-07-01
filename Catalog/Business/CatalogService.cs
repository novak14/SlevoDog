using AutoMapper;
using Catalog.Business.DTOObjects;
using Catalog.Dal.Entities;
using Catalog.Dal.Repository.Abstraction;
using System;
using System.Collections.Generic;
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

        public List<Sale> LoadAll()
        {
            var test = _loadCatalog.LoadAll();
            return _loadCatalog.LoadAll();
        }

        public Sale LoadById(int id)
        {
            return _loadCatalog.LoadById(id);
        }
    }
}
