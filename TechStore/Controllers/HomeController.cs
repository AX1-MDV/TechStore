using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Models;
using TechStore.Services.Interfaces;

namespace TechStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductoService _productoService;

        public HomeController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public async Task<IActionResult> Index()
        {

            var productos = await _productoService.ObtenerTodosAsync();

            var products = productos
                .GroupBy(p => p.CategoriaId)
                .Select(g => g.OrderBy(p => p.Stock).ThenBy(p => p.ID).First())
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
                .ToList();

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
