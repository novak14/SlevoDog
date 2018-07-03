using Catalog.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SlevaDog.Models.CatalogViewModels;
using SlevoDog.Models;
using SlevoDog.Models.CatalogViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SlevaDog.Controllers
{
    public class ItemController : Controller
    {
        private readonly CatalogService _catalogService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ItemController(CatalogService catalogService, UserManager<ApplicationUser> userManager)
        {
            _catalogService = catalogService;
            _userManager = userManager;
        }

        public async Task<IActionResult> ItemAsync(int? id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var test1 = id != null ? await _catalogService.LoadByIdAsync(id.Value) : throw new Exception(nameof(id));
            stopwatch.Stop();
            var dapper = stopwatch.Elapsed;

            SaleViewModel saleItem = new SaleViewModel
            {
                Id = test1.Id,
                Name = test1.Name,
                PriceAfterSale = test1.PriceAfterSale,
                OriginPrice = test1.OriginPrice,
                Image = test1.Image,
                ValidFrom = test1.ValidFrom,
                ValidTo = test1.ValidTo,
                LinkFirm = test1.LinkFirm,
                Description = test1.Description,
                PercentSale = (int)test1.PercentSale,
                DateInsert = test1.DateInsert,
            };

            foreach(var item in test1.Comments)
            {
                CommentsViewModel commentsViewModel = new CommentsViewModel
                {
                    AuthorName = item.Name,
                    Text = item.Text,
                    DateInsertComment = item.DateInsert,
                    RankComment = item.Rank
                };
                saleItem.Comments.Add(commentsViewModel);

            }

            return View("Item", saleItem);
        }

        public async Task<IActionResult> AddComments(SaleViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                model.AuthorName = user.UserName;
                model.IdUser = user.Id;
            }
            _catalogService.InsertComment(model.Id, model.AuthorName, model.Text);
            return await ItemAsync(model.Id);
        }
    }
}
