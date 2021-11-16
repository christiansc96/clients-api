using System.ComponentModel.DataAnnotations;

namespace TechApi.Database.DBModels
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }
    }
}