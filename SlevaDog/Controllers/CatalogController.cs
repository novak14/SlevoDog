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
            var test = _catalogService.LoadAll().FirstOrDefault();

            Browse browse = new Browse
            {
                Id = test.Id,
                Name = test.Name,
                PriceAfterSale = test.PriceAfterSale,
                OriginPrice = test.OriginPrice,
                Image = test.Image,
                ValidFrom = test.ValidFrom,
                LinkFirm = test.LinkFirm,
                Description = test.Description
            };
            return View(browse);
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
