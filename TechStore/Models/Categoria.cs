using System.ComponentModel.DataAnnotations;

namespace TechStore.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
