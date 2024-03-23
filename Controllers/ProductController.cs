
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechStore.Models;

namespace TechStore.Controllers
{
    public class ProductController : Controller
    {       
        private readonly ILogger<ProductController>_logger;
        public ProductController(ILogger<ProductController>logger)
        {
            _logger=logger;
        }        
        public IActionResult AddProduct()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                product.IGV = product.Price * 0.18m;
                // Add your logic to save the product here
                return RedirectToAction("Index", "Home");
            }

            return View(product);
        }
    }
}