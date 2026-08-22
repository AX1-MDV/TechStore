using Microsoft.AspNetCore.Mvc;

namespace TechStore.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
