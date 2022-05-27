using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroceryDelivery.BusinessLayer.Interfaces;
using GroceryDelivery.Entites;
using GroceryDelivery.BusinessLayer.ViewModels;

namespace Grocerydelivery.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Creating Referance variable of IGroceryServices
        /// </summary>
        private readonly IGroceryServices _groceryServices;
        /// <summary>
        /// Injecting the IGroceryServices in controller constructor
        /// </summary>
        /// <param name="groceryServices"></param>
        public HomeController(IGroceryServices groceryServices)
        {
            _groceryServices = groceryServices;
        }
        /// <summary>
        /// Index Method is used for show all product and search product by name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task< IActionResult> Index(int? id, string search, int page = 1 )
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Show the product Details by product id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(int ProductId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Place order for new product get method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Placeorder()
        {
            return View();
        }
        /// <summary>
        /// Place order by product id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Placeorder(int ProductId, ApplicationUser user)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Used for show order info
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> OrderInfo(int userId)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
