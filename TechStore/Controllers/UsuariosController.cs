using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Controllers
{
    // Administración de usuarios: solo el Admin puede ver el listado, cambiar roles
    // y bloquear o desbloquear cuentas. Los roles son fijos (Administrador, Vendedor, Cliente).
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        public static readonly string[] RolesDisponibles = { "Administrador", "Vendedor", "Cliente" };

        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(UserManager<IdentityUser> userManager, ILogger<UsuariosController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string? buscar, string? rol)
        {
            var idActual = _userManager.GetUserId(User);
            var usuarios = await _userManager.Users.OrderBy(u => u.UserName).ToListAsync();

            var lista = new List<UsuarioViewModel>();
            foreach (var usuario in usuarios)
            {
                var roles = await _userManager.GetRolesAsync(usuario);
                lista.Add(new UsuarioViewModel
                {
                    Id = usuario.Id,
                    NombreUsuario = usuario.UserName ?? string.Empty,
                    Email = usuario.Email ?? string.Empty,
                    Rol = roles.FirstOrDefault() ?? "Sin rol",
                    Bloqueado = usuario.LockoutEnd.HasValue && usuario.LockoutEnd > DateTimeOffset.UtcNow,
                    EsUsuarioActual = usuario.Id == idActual
                });
            }

            // Filtros por texto (usuario o correo) y por rol.
            if (!string.IsNullOrWhiteSpace(buscar))
            {
                lista = lista.Where(u => u.NombreUsuario.Contains(buscar, StringComparison.OrdinalIgnoreCase)
                                      || u.Email.Contains(buscar, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(rol))
            {
                lista = lista.Where(u => u.Rol == rol).ToList();
            }

            ViewBag.Buscar = buscar;
            ViewBag.Rol = rol;
            return View(lista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarRol(string id, string rol)
        {
            if (!RolesDisponibles.Contains(rol))
            {
                return BadRequest();
            }

            // El Administrador no puede cambiar su propio rol para no quedarse sin acceso.
            if (id == _userManager.GetUserId(User))
            {
                TempData["ErrorMessage"] = "No puede cambiar su propio rol.";
                return RedirectToAction(nameof(Index));
            }

            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null) return NotFound();

            var rolesActuales = await _userManager.GetRolesAsync(usuario);
            await _userManager.RemoveFromRolesAsync(usuario, rolesActuales);
            await _userManager.AddToRoleAsync(usuario, rol);

            // Invalida la sesión actual del usuario para que su nuevo rol se aplique.
            await _userManager.UpdateSecurityStampAsync(usuario);

            _logger.LogInformation("Rol de {Usuario} cambiado a {Rol}.", usuario.UserName, rol);
            TempData["SuccessMessage"] = $"El usuario {usuario.UserName} ahora tiene el rol {rol}.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Bloquear(string id)
        {
            if (id == _userManager.GetUserId(User))
            {
                TempData["ErrorMessage"] = "No puede bloquear su propia cuenta.";
                return RedirectToAction(nameof(Index));
            }

            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null) return NotFound();

            // Bloqueo indefinido hasta que un Administrador lo desbloquee.
            await _userManager.SetLockoutEnabledAsync(usuario, true);
            await _userManager.SetLockoutEndDateAsync(usuario, DateTimeOffset.MaxValue);
            await _userManager.UpdateSecurityStampAsync(usuario);

            _logger.LogInformation("Usuario {Usuario} bloqueado.", usuario.UserName);
            TempData["SuccessMessage"] = $"El usuario {usuario.UserName} fue bloqueado.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desbloquear(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null) return NotFound();

            await _userManager.SetLockoutEndDateAsync(usuario, null);
            await _userManager.ResetAccessFailedCountAsync(usuario);

            _logger.LogInformation("Usuario {Usuario} desbloqueado.", usuario.UserName);
            TempData["SuccessMessage"] = $"El usuario {usuario.UserName} fue desbloqueado.";
            return RedirectToAction(nameof(Index));
        }
    }
}
