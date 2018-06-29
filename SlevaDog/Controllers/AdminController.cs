using Admin.Business;
using Admin.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using SlevaDog.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlevoDog.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertItem(SaleAdminViewModel saleAdminViewModel, bool? bDisabled)
        {
            SaleAdmin test = new SaleAdmin
            {
                AveragePrice = saleAdminViewModel.AveragePrice,
                DateInsert = saleAdminViewModel.DateInsert,
                Description = saleAdminViewModel.Description,
                Disabled = saleAdminViewModel.Disabled,
                Image = saleAdminViewModel.Image,
                LinkFirm = saleAdminViewModel.LinkFirm,
                Name = saleAdminViewModel.Name,
                OriginPrice = saleAdminViewModel.OriginPrice,
                PriceAfterSale = saleAdminViewModel.PriceAfterSale,
                ValidFrom = saleAdminViewModel.ValidFrom,
                ValidTo = saleAdminViewModel.ValidTo
            };
            _adminService.InsertSale(test);

            //_adminService.InsertSale(saleAdminViewModel.AveragePrice, saleAdminViewModel.DateInsert, saleAdminViewModel.Description, saleAdminViewModel.Disabled,
            //                         saleAdminViewModel.Image, saleAdminViewModel.LinkFirm, saleAdminViewModel.Name, saleAdminViewModel.);
            return View("Index");
        }
    }
}
