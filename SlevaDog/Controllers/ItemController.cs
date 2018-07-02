using Catalog.Business;
using Microsoft.AspNetCore.Mvc;
using SlevoDog.Models.CatalogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlevaDog.Controllers
{
    public class ItemController : Controller
    {
        private readonly CatalogService _catalogService;

        public ItemController(CatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IActionResult Item(int? id)
        {
            var test1 = id != null ? _catalogService.LoadById(id.Value) : throw new Exception(nameof(id));

            SaleViewModel saleItem = new SaleViewModel
            {
                Name = test1.Name,
                PriceAfterSale = test1.PriceAfterSale,
                OriginPrice = test1.OriginPrice,
                Image = test1.Image,
                ValidFrom = test1.ValidFrom,
                ValidTo = test1.ValidTo,
                LinkFirm = test1.LinkFirm,
                Description = test1.Description,
                PercentSale = test1.PercentSale,
                DateInsert = test1.DateInsert,
                Text = test1.comments?.Text
            };
            return View(saleItem);
        }
    }
}
