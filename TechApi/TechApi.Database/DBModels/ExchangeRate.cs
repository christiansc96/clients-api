using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechApi.Database.DBModels
{
    public class ExchangeRate
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Rate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime InitialDate { get; set; }

        public DateTime? FinalDate { get; set; }
    }
}