using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;

namespace TechStore.Controllers
{
    public class ProductsController : Controller
    {
        public static List<CardViewModel> _products =
        [
            new CardViewModel { Id=1, Title="IPhone 16", Description="Diseño revolucionario en aluminio de grado aeroespacial, impulsado por el nuevo chip A18 para un rendimiento ultrarrápido y máxima eficiencia.", ImageUrl="/images/iphone_16.jpg", Category="Celulares", Price=1250, State="Disponible", Stock=10 },
            new CardViewModel { Id=2, Title="Asus Prime RTX 5080", Description="Lleva tu experiencia visual al extremo. Diseñada bajo la avanzada arquitectura NVIDIA Blackwell y respaldada por 16 GB de memoria ultra rápida GDDR7.", ImageUrl="/images/asus_prime_rtx_5080.jpg", Category="Tarjetas de video", Price=1500, State="Disponible", Stock=16 },
            new CardViewModel { Id=3, Title="Steam Deck OLED", Description="Consola portátil de videojuegos con pantalla OLED de colores vibrantes, negros puros y una batería de mayor duración.", ImageUrl="/images/steam_deck.jpg", Category="Consolas", Price=980.65F, State="Disponible", Stock=4 },
            new CardViewModel { Id=4, Title="Sony WH-1000XM6", Description="Auriculares inalámbricos de gama alta con la cancelación de ruido activa líder de la industria y un perfil de sonido de alta definición.", ImageUrl="/images/sony_wh1000xm6.jpg", Category="Audio", Price=340, State="Disponible", Stock=8 },
            new CardViewModel {Id=5, Title="MacBook Pro 16\"", Description="La laptop más potente de Apple, con el chip M3 Pro y una pantalla Retina de 16 pulgadas.", ImageUrl="/images/macbookpro.jpg", Category="Notebooks", Price=2499, State="Disponible", Stock=6  },
            new CardViewModel {Id=6, Title="iPad Air", Description="La tablet más rápida de Apple, con el chip M1 y una pantalla Liquid Retina de 10.9 pulgadas.", ImageUrl="/images/airpadair.jpg", Category="Tablets", Price=599, State="Disponible", Stock=12 }
        ];

        public IActionResult Index()
        {
            return View(_products);
        }

        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}