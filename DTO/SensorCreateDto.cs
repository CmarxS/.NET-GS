using System.ComponentModel.DataAnnotations;

namespace FloodianGlobal.DTOs
{
    public class SensorCreateDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "O número de série do sensor deve ter no máximo 100 caracteres.")]
        public string NumeroSerie { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "O limite de alerta deve ser maior que zero.")]
        public decimal LimiteAlerta { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Informe o intervalo de horas para medições.")]
        public int IntervaloHoras { get; set; }

        [Required]
        public int LocalizacaoId { get; set; }  // Relacionamento com Localizacao
    }
}
