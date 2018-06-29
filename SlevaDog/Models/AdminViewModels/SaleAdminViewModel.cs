using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SlevaDog.Models.AdminViewModels
{
    public class SaleAdminViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceAfterSale { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal OriginPrice { get; set; }
        public string Image { get; set; }

        [Display(Name = "Release Date"), DataType(DataType.DateTime)]
        public DateTime DateInsert { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string LinkFirm { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }
    }
}
