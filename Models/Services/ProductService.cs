using AgroNepalTrade.Data;
using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.Models.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProductService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Product> Add(Product product)
        {
            applicationDbContext.Add(product);
            await applicationDbContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Update(Product product)
        {
            applicationDbContext.Update(product);
            await applicationDbContext.SaveChangesAsync();
            return product;
        }
        public Product GetProduct(int productId)
        {
            return applicationDbContext.Product
                .Include(product => product.Farmer)
                .FirstOrDefault(product => product.Id == productId);
        }
        public IEnumerable<Product> GetProducts(string searchString)
        {
            return applicationDbContext.Product
                .OrderByDescending(product => product.UpdatedOn)
                .Include(product => product.Farmer)
                .Where(product => product.ProductName.Contains(searchString));
        }
        public IEnumerable<Product> GetProducts(ApplicationUser applicationUser)
        {
            return applicationDbContext.Product
                .Include(product => product.Farmer)
                .Where(product => product.Farmer == applicationUser);
        }
    }
}
