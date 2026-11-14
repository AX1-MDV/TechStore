namespace TechStore.Models
{
    // Fila del listado de administración de usuarios.
    public class UsuarioViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public bool Bloqueado { get; set; }
        public bool EsUsuarioActual { get; set; }
    }
}
