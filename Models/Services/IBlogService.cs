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
        Blog GetBlog(int blogId);
        IEnumerable<Blog> GetBlogs(string searchString);
        IEnumerable<Blog> GetBlogs(ApplicationUser applicationUser);
        Comment GetComment(int commentId);
        Task<Comment> Add(Comment comment);
        Task<Blog> Add(Blog blog);
        Task<Blog> Update(Blog blog);


    }
}
