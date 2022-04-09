using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.ProductViewModels
{
    public class EditViewModel
    {

        [Display(Name = "Header Image")]
        public IFormFile HeaderImage { get; set; }
        public Product Product{ get; set; }
    }
}
