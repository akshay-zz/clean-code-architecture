using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Weather
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeatherId { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int TemperatureC { get; set; }

        [StringLength(50)]
        public string Summary { get; set; }
    }
}
