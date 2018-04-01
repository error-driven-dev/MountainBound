using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MountainBound.Areas.TradingPost.Models;

namespace MountainBound.Areas.TradingPost.Components
{
    public class NavViewComponent: ViewComponent
    {
        private IProductRepository _repository;

        public NavViewComponent(IProductRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_repository.Products.Select(p => p.Category).Distinct().OrderBy(s =>s));
        }

    }
}
