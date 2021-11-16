using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechApi.Database.DBModels
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }

        public int ClientId { get; set; }
        [ForeignKey("Id")]
        public virtual Client Client { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SumAssured { get; set; }
    }
}