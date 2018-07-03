using AutoMapper;
using Catalog.Business.DTOObjects;
using Catalog.Dal.Entities;
using Catalog.Dal.Repository.Abstraction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Sale> LoadByIdAsync(int id)
        {
            var test = await _loadCatalog.LoadByIdAsync(id);
            return test;
        }

        public async Task<Sale> LoadEfCoreAsync(int id)
        {
            return await _loadCatalog.LoadEfCore(id);
        }

        public void InsertComment(int Id, string AuthorName, string Text, string IdUser = null)
        {
            Comments comments = new Comments
            {
                DateInsert = DateTime.Now,
                Disabled = false,
                FkSale = Id,
                Name = AuthorName,
                Text = Text,
                Rank = 0,
                FkUser = IdUser
            };

            _loadCatalog.InsertComment(comments);
        }
    }
}
