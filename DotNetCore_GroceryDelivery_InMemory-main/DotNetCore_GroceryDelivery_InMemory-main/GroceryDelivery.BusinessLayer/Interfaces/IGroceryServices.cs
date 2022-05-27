using GroceryDelivery.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.BusinessLayer.Interfaces
{
    public interface IGroceryServices
    {
        //List of method to perform all related operation
        Task<Product> AddProduct(Product product);
        Task<ApplicationUser> PlaceOrder(int ProductId, ApplicationUser user);
        Task<IEnumerable<Product>> GetAllProduct(int? id);
        Task<Product> GetProductById(int ProductId);
        Task<IEnumerable<Product>> ProductByName(string name);
        Task<IList<Menubar>> MenuList();
        Task<IEnumerable<ProductOrder>> OrderByuserId(int UserId);
    }
}
