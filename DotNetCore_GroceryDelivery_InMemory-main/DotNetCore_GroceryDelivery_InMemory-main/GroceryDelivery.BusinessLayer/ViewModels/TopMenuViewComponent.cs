using GroceryDelivery.BusinessLayer.Interfaces;
using GroceryDelivery.DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.BusinessLayer.ViewModels
{
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly IGroceryServices _groceryServices;

        public TopMenuViewComponent(IGroceryServices groceryServices)
        {
            _groceryServices = groceryServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _groceryServices.MenuList();
            return await Task.FromResult((IViewComponentResult)View("Default", model));
        }
    }
}
