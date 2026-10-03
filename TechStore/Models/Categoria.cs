using System.ComponentModel.DataAnnotations;

namespace TechStore.Models
{
    public class Categoria
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        // Una categoría puede tener varios productos
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
