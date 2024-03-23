
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
        public IActionResult Product()
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
                ViewBag.ProductName = product.Name;
                ViewBag.ProductDescription = product.Description;
                ViewBag.ProductPrice = product.Price;
                ViewBag.ProductIGV = product.IGV;
                ViewData["Message"]="Su Precio a pagar es";
                return RedirectToAction("Index", "Home");
            }
            
            return View(product);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}