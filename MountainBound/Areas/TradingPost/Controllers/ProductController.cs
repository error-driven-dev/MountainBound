using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MountainBound.Areas.TradingPost.Models;
using MountainBound.Areas.TradingPost.Models.ViewModels;

namespace MountainBound.Areas.TradingPost.Controllers
{
    [Area("TradingPost")]
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult ProductDirectory(string category, int pageNum = 1)
        {
            var dataset = _repository.Products.Where(p=> category == null || p.Category == category);
            var numpages = Math.Ceiling((decimal)dataset.Count() / PageSize);
             var products = dataset.OrderBy(p => p.ProductId).Skip((pageNum - 1) * PageSize).Take(PageSize);
            
            return View(new ProductViewModel
            {
                Products = products,
                NumPages = (int)numpages
            });

        }

        //admin only
        public IActionResult SeedProducts()
        {
            _repository.SeedDB();
            return RedirectToAction("ProductDirectory");
        }
        
    }


}
