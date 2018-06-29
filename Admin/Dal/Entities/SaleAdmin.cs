using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Dal.Entities
{
    public class SaleAdmin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceAfterSale { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal OriginPrice { get; set; }
        public string Image { get; set; }

        public DateTime DateInsert { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string LinkFirm { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }
    }
}
