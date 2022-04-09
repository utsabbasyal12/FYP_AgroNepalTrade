using FYP_AgroNepalTrade.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.FarmerViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Product { get; internal set; }
    }
}
