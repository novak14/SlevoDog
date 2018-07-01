using Catalog.Business;
using Microsoft.AspNetCore.Mvc;
using SlevoDog.Models.CatalogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlevoDog.Controllers
{
    public class CatalogController : Controller
    {
        private readonly CatalogService _catalogService;

        public CatalogController(CatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IActionResult Index()
        {
            var test = _catalogService.LoadAll();

            Sale sale = new Sale();

            foreach (var item in test)
            {
                Sale saleItem = new Sale
                {
                    Id = item.Id,
                    Name = item.Name,
                    PriceAfterSale = item.PriceAfterSale,
                    OriginPrice = item.OriginPrice,
                    Image = item.Image,
                    LinkFirm = item.LinkFirm,
                    PercentSale = item.PercentSale
                };

                sale.saleCollection.collections.Add(saleItem);
            }
            return View(sale);
        }

        public IActionResult Item(int? id)
        {
            var test1 = id != null ? _catalogService.LoadById(id.Value) : throw new Exception(nameof(id));

            Sale saleItem = new Sale
            {
                Name = test1.Name,
                PriceAfterSale = test1.PriceAfterSale,
                OriginPrice = test1.OriginPrice,
                Image = test1.Image,
                ValidFrom = test1.ValidFrom,
                LinkFirm = test1.LinkFirm,
                Description = test1.Description
            };
            return View(saleItem);
        }
    }
}
