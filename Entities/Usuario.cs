using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloodianGlobal.Entities
{
    [Table("NETFLD_Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Informe um número de telefone válido.")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(30)]
        public string TipoUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Senha { get; set; }
    }
}
