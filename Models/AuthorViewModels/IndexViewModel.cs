using FYP_AgroNepalTrade.Models.BlogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.AuthorViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Blog> Blogs { get; internal set; }
    }
}
