using AgroNepalTrade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.ProductViewModels
{
    public class Product
    {
        public int Id { get; set; }
        public ApplicationUser Farmer { get; set; }
        [Required]
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Published { get; set; }
        public string UnitsForPrice { get; set; }
        public string UnitsForQuantity { get; set; }

    }
}
