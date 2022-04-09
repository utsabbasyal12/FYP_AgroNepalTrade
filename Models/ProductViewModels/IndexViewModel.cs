using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.ProductViewModels
{
    public class IndexViewModel
    {
        public IPagedList<Product> Products { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
    }
}
