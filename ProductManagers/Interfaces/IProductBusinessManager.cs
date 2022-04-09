using FYP_AgroNepalTrade.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.ProductManagers.Interfaces
{
    public interface IProductBusinessManager
    {
        Task<Product> CreateProduct(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<ProductViewModel>> GetProductViewModel(int? id, ClaimsPrincipal claimsPrincipal);
        IndexViewModel GetIndexViewModel(string searchString, int? page);
        Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<EditViewModel>> UpdateProduct(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal);


    }
}
