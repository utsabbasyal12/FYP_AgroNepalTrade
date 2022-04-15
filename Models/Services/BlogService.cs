using AgroNepalTrade.Data;
using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.Models.BlogViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FYP_AgroNepalTrade.Models.Services
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BlogService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Blog GetBlog(int blogId)
        {
            return applicationDbContext.Blogs
                .Include(blog => blog.Creator)
                .Include(blog => blog.Comments)
                    .ThenInclude(comment => comment.Author)
                .Include(blog => blog.Comments)
                    .ThenInclude(comment => comment.Comments)
                        .ThenInclude(reply => reply.Parent)
                .FirstOrDefault(blog => blog.Id == blogId);
        }
        public IEnumerable<Blog> GetBlogs(string searchString)
        {
            return applicationDbContext.Blogs
                .OrderByDescending(blog => blog.UpdatedOn)
                .Include(blog => blog.Creator)
                .Include(blog => blog.Comments)
                .Where(blog => blog.Title.Contains(searchString) || blog.Content.Contains(searchString));
        }

        public IEnumerable<Blog> GetBlogs(ApplicationUser applicationUser)
        {
            return applicationDbContext.Blogs
                .Include(blog => blog.Creator)
                .Include(blog => blog.Approver)
                .Include(blog => blog.Comments)
                .Where(blog => blog.Creator == applicationUser);
        }

        public Comment GetComment(int commentId)
        {
            return applicationDbContext.Comments
                .Include(comment => comment.Author)
                .Include(comment => comment.Blog)
                .Include(comment => comment.Parent)
                .FirstOrDefault(comment => comment.Id == commentId);
        }
        public async Task<Blog> Add(Blog blog)
        {
            applicationDbContext.Add(blog);
            await applicationDbContext.SaveChangesAsync();
            return blog;
        }
        public async Task<Comment> Add(Comment comment)
        {
            applicationDbContext.Add(comment);
            await applicationDbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Blog> Update(Blog blog)
        {
            applicationDbContext.Update(blog);
            await applicationDbContext.SaveChangesAsync();
            return blog;
        }
    }
}
