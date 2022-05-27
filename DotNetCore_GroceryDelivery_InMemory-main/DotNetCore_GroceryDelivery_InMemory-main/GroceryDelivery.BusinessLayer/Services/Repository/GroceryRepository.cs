using GroceryDelivery.DataLayer;
using GroceryDelivery.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.BusinessLayer.Services.Repository
{
    public class GroceryRepository : IGroceryRepository
    {
        /// <summary>
        /// Creating Referance variable of GroceryDbContext
        /// Injecting in GroceryRepository constructor
        /// </summary>
        private readonly GroceryDbContext _groceryContext;

        public GroceryRepository(GroceryDbContext groceryDbContext)
        {
            _groceryContext = groceryDbContext;
        }
        /// <summary>
        /// Add new product in InMemoryDb
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> AddProduct(Product product)
        {
            _groceryContext.Products.Add(product);
            await _groceryContext.SaveChangesAsync();
            return product;
        }
        /// <summary>
        /// Get All product and product by id also
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProduct(int ?id)
        {
            if(id == null)
            {
                var product = await _groceryContext.Products.
                OrderByDescending(x => x.ProductName).ToListAsync();
                return product;
            }
            else
            {
                var product = await _groceryContext.Products.Where(x => x.CatId == id).
                OrderByDescending(x => x.ProductName).ToListAsync();
                return product;
            }
        }
        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int ProductId)
        {
            var result = await _groceryContext.Products
                                 .Where(x => x.ProductId == ProductId)
                                 .FirstOrDefaultAsync();
            return result;
        }
        /// <summary>
        /// Menu List of catogery
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Menubar>> MenuList()
        {
            var menu = await _groceryContext.Menubars.ToListAsync();
            return menu;
        }
        /// <summary>
        /// Place order
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> PlaceOrder(int ProductId, ApplicationUser user)
        {
            _groceryContext.ApplicationUsers.Add(user);
            var order = new ProductOrder()
            {
                ProductId = ProductId,
                UserId = user.UserId
            };
            _groceryContext.Add(order);
            await _groceryContext.SaveChangesAsync();
            return user;
        }
        /// <summary>
        /// Find Product by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> ProductByName(string name)
        {
            var result = await _groceryContext.Products.
                Where(x => x.ProductName == name).Take(10).ToListAsync();
            return result;
        }
        /// <summary>
        /// Get Order Information of ordered product
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductOrder>> OrderByuserId(int UserId)
        {
            var result = await _groceryContext.productOrders.
                Where(x => x.UserId == UserId).Take(10).ToListAsync();
            return result;
        }
    }
}
