using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.Models.ProductViewModels;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.FarmerViewModels
{
    public class FarmerViewModel
    {
        public ApplicationUser Author { get; set; }
        public IPagedList<Product> Products{ get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public ApplicationUser Farmer { get; internal set; }
    }
}
