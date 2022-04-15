using FYP_AgroNepalTrade.Models.FarmerViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.ProductManagers.Interfaces
{
    public interface IFarmerHomeBusinessManager
    {
        ActionResult<FarmerViewModel> GetFarmerViewModel(string farmerId, string searchString, int? page);
    }
}
