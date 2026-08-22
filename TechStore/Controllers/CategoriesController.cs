using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;

namespace TechStore.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var groups = ProductsController._products
                .OrderBy(p => p.Category)
                .GroupBy(p => p.Category)
                .ToList();

            return View(groups);
        }
    }
}