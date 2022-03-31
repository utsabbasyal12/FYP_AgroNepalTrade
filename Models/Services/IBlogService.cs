using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.Models.BlogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.Services
{
    public interface IBlogService
    {
        Task<Blog> Add(Blog blog);
    }
}
