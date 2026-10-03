using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechStore.Data;
using TechStore.Models;

namespace TechStore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly TechStoreContext _context;

        public CategoriesController(TechStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var groups = _context.Productos
                .Select(p => new CardViewModel
                {
                    Id = p.ID,
                    Title = p.Nombre,
                    Description = p.Descripcion,
                    ImageUrl = p.ImagenUrl ?? string.Empty,
                    Price = (float)p.Precio,
                    Category = p.Categoria != null ? p.Categoria.Nombre : string.Empty,
                    State = p.Estado,
                    Stock = p.Stock
                })
                .OrderBy(c => c.Category)
                .GroupBy(c => c.Category)
                .ToList();

            return View(groups);
        }
    }
}