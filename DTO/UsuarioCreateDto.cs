using System.ComponentModel.DataAnnotations;

namespace FloodianGlobal.DTOs
{
    public class UsuarioCreateDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "O nome do usuário deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [StringLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Informe um número de telefone válido.")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "O tipo de usuário deve ter no máximo 30 caracteres.")]
        public string TipoUsuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A senha deve ter no máximo 100 caracteres.")]
        public string Senha { get; set; }
    }
}
