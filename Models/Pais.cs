using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticoDotNet.Models
{
    public class Pais {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Este campo es obligatiorio")]
        [DisplayName("Nombre")]
        [MaxLength(25)]
        public string nombre { get; set; }
    
    }
}
