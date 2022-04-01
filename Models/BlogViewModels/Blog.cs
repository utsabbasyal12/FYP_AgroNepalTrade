
using AgroNepalTrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Models.BlogViewModels
{
    public class Blog
    {
        public int Id { get; set; }
        public ApplicationUser Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Published { get; set; }
        public bool Approved { get; set; }
        public ApplicationUser Approver { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
