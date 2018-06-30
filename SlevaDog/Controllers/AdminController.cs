using Admin.Business;
using Admin.Dal.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlevaDog.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlevoDog.Controllers
{
    [Authorize(Roles = "Admin")]
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
            if (ModelState.IsValid)
            {
                SaleAdmin saleAdmin = Mapper.Map<SaleAdmin>(saleAdminViewModel);

                _adminService.InsertSale(saleAdmin);
            }

            return View("Index");
        }
    }
}
