using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApp.Models
{
    [Table(name: "Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(200, ErrorMessage = "El campo {1} solo acepta entre 1 a 100 caracteres", MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(45, ErrorMessage = "El campo {1} solo acepta entre 1 a 45 caracteres", MinimumLength = 1)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(255, ErrorMessage = "El campo {0} solo acepta entre 1 a 100 caracteres", MinimumLength = 1)]
        [EmailAddress(ErrorMessage = "El campo {0} no tiene un formato válido")]
        public string Email { get; set; }

        [Display(Name = "Fecha de Creación")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
    }
}
