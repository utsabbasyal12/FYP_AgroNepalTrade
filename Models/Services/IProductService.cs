using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.Services
{
    public interface IProductService
    {
        Product GetProduct(int productId);
        IEnumerable<Product> GetProducts(string searchString);
        IEnumerable<Product> GetProducts(ApplicationUser applicationUser);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);

    }
}
