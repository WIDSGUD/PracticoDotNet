using System.ComponentModel.DataAnnotations;

namespace PracticoDotNet.Models
{
    public class Confederacion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        [MaxLength(25)]
        public string Nombre { get; set; }
        public DateOnly Fundacion { get; set; }
    }
}