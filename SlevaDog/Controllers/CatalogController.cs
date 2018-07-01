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

        public IActionResult Index(string sortOrder)
        {
            if (String.IsNullOrEmpty(sortOrder))
            {
                ViewData["PriceSortParm"] = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
                ViewData["NewSortParm"] = String.IsNullOrEmpty(sortOrder) ? "new_desc" : "";
                ViewData["SaleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "sale_desc" : "";
            }
            else
            {
                ViewData["PriceSortParm"] = "price_desc" ;
                ViewData["NewSortParm"] =  "new_desc";
                ViewData["SaleSortParm"] = "sale_desc";
            }


            var test = _catalogService.LoadAll(sortOrder);

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

        public IActionResult Filter(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            return View("Index");
        }
    }
}
