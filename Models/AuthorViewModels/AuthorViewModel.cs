using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.Models.BlogViewModels;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.AuthorViewModels
{
    public class AuthorViewModel
    {
        public ApplicationUser Author { get; set; }
        public IPagedList<Blog> Blogs{ get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
    }
}
