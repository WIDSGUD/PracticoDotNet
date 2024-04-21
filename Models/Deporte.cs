using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PracticoDotNet.Models
{
    public class Deporte
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatiorio")]
        [MaxLength(25)]
        public string Nombre { get; set; }
    }
}
