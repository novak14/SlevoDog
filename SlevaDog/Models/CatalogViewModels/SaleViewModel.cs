using SlevaDog.Models.CatalogViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SlevoDog.Models.CatalogViewModels
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal PriceAfterSale { get; set; }
        public decimal AveragePrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal OriginPrice { get; set; }
        public string Image { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string LinkFirm { get; set; }
        public string Description { get; set; }

        public int PercentSale { get; set; }

        public SaleCollection saleCollection { get; } = new SaleCollection();

        // Comments
        public string AuthorName { get; set; }
        public DateTime DateInsertComment { get; set; }
        public int RankComment { get; set; }
        public string Text { get; set; }

        public string IdUser { get; set; }
    }
}
