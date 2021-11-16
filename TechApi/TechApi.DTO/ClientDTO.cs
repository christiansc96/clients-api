using System.ComponentModel.DataAnnotations;

namespace TechApi.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(120, ErrorMessage = "Solo se aceptan 120 caracteres")]
        public string Name { get; set; }
    }
}