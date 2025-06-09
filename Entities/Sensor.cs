using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloodianGlobal.Entities
{
    [Table("NETFLD_Sensor")]
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NumeroSerie { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "O limite de alerta deve ser maior que zero.")]
        public decimal LimiteAlerta { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Informe o intervalo de horas para medições.")]
        public int IntervaloHoras { get; set; }

    }
}
