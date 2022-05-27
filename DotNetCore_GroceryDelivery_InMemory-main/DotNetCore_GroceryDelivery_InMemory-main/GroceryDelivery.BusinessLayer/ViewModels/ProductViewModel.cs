using GroceryDelivery.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace GroceryDelivery.BusinessLayer.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Unit Price")]
        public Double Amount { get; set; }
        [Required]
        [Display(Name = "Stock")]
        public int stock { get; set; }
        public string photo { get; set; }
        public ProductOrder ProductOrder { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public int ProductPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Products.Count() / (double)ProductPerPage));
        }
        public IEnumerable<Product> PaginatedInterview()
        {
            int start = (CurrentPage - 1) * ProductPerPage;
            return Products.OrderBy(b => b.ProductId).Skip(start).Take(ProductPerPage);
        }
    }
}
