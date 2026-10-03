using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using TechStore.Models;
using TechStore.Services.Interfaces;

namespace TechStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IWebHostEnvironment _env;

        public ProductsController(IProductoService productoService, ICategoriaService categoriaService, IWebHostEnvironment env)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productoService.ObtenerTodosAsync();
            return View(products);
        }

        // cards
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var producto = await _productoService.ObtenerPorIdAsync(id.Value);

            if (producto == null) return NotFound();

            var model = new CardViewModel
            {
                Id = producto.ID,
                Title = producto.Nombre,
                Description = producto.Descripcion,
                ImageUrl = producto.ImagenUrl ?? string.Empty,
                Price = (float)producto.Precio,
                Category = producto.Categoria?.Nombre ?? string.Empty,
                State = producto.Estado,
                Stock = producto.Stock
            };

            return View(model);
        }

        public async Task<IActionResult> Agregar()
        {
            ViewBag.Categorias = (await _categoriaService.ObtenerTodasAsync()).OrderBy(c => c.Nombre).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(Producto producto, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = (await _categoriaService.ObtenerTodasAsync()).OrderBy(c => c.Nombre).ToList();
                return View(producto);
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "images");
                Directory.CreateDirectory(uploads);
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploads, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                producto.ImagenUrl = fileName;
            }

            await _productoService.AgregarAsync(producto);
            TempData["SuccessMessage"] = "Producto agregado exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var producto = await _productoService.ObtenerPorIdAsync(id);
            if (producto == null) return NotFound();
            ViewBag.Categorias = (await _categoriaService.ObtenerTodasAsync()).OrderBy(c => c.Nombre).ToList();
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Producto producto, IFormFile? imageFile)
        {
            if (id != producto.ID) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = (await _categoriaService.ObtenerTodasAsync()).OrderBy(c => c.Nombre).ToList();
                return View(producto);
            }

            var existingProduct = await _productoService.ObtenerPorIdAsync(id);
            if (existingProduct == null) return NotFound();

            var oldImage = existingProduct.ImagenUrl;

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "images");
                Directory.CreateDirectory(uploads);
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploads, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                existingProduct.ImagenUrl = fileName;

                if (!string.IsNullOrEmpty(oldImage))
                {
                    var oldimagePath = Path.Combine(_env.WebRootPath, "images", oldImage);
                    if (System.IO.File.Exists(oldimagePath)) System.IO.File.Delete(oldimagePath);
                }
            }

            // Asignar los valores al objeto que se persistirá
            producto.ImagenUrl = existingProduct.ImagenUrl; // si no se subió nueva imagen conserva

            var success = await _productoService.EditarAsync(producto);
            if (!success) return NotFound();
            TempData["SuccessMessage"] = "Producto editado exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            var producto = await _productoService.ObtenerPorIdAsync(id);
            if (producto == null) return NotFound();

            if (!string.IsNullOrEmpty(producto.ImagenUrl))
            {
                var imagePath = Path.Combine(_env.WebRootPath, "images", producto.ImagenUrl);
                if (System.IO.File.Exists(imagePath)) System.IO.File.Delete(imagePath);
            }

            var success = await _productoService.EliminarAsync(id);
            if (!success) return NotFound();
            TempData["SuccessMessage"] = "Producto eliminado exitosamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}