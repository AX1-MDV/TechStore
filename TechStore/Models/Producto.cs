using System.ComponentModel.DataAnnotations;

namespace TechStore.Models
{
    public class Producto
    {
        public int ID { get; set; }

        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion {  get; set; }
        [Required]
        public string ImagenUrl { get; set; }
        [Required]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
        [Required]
        public float Precio { get; set; }

        public string Estado { get; set; } = "Disponible";
        [Required]
        public int Stock { get; set; }
    }
}
