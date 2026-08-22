using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechStore.Models;

namespace TechStore.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            var model = new AboutViewModel
            {
                Timeline = new List<TimelineEventViewModel>
                {
                    new TimelineEventViewModel
                    {
                        Year = "2021",
                        Title = "Fundación de TechStore",
                        Description = "Abrimos nuestra primera sucursal con la meta de acercar tecnología de calidad a nuestra comunidad."
                    },
                    new TimelineEventViewModel
                    {
                        Year = "2023",
                        Title = "Lanzamiento de la tienda en línea",
                        Description = "Digitalizamos nuestro catálogo para que cualquier cliente pudiera comprar desde cualquier lugar."
                    },
                    new TimelineEventViewModel
                    {
                        Year = "2026",
                        Title = "Expansión de catálogo y alianzas",
                        Description = "Sumamos nuevas marcas aliadas y ampliamos nuestra oferta de laptops, componentes y accesorios gamer."
                    }
                },
                Team = new List<TeamMemberViewModel>
                {
                    new TeamMemberViewModel
                    {
                        Name = "Fabio Guardado",
                        Role = "Frontend Developer",
                        PhotoUrl = "/images/team/fabio-guardado.jpg"
                    },
                    new TeamMemberViewModel
                    {
                        Name = "Aldo Landaverde",
                        Role = "Full Stack Developer",
                        PhotoUrl = "/images/team/aldo-landaverde.jpg"
                    },
                    new TeamMemberViewModel
                    {
                        Name = "Dereck Méndez",
                        Role = "Data Scientist",
                        PhotoUrl = "/images/team/dereck-mendez.png"
                    }
                }
            };

            return View(model);
        }
    }
}
