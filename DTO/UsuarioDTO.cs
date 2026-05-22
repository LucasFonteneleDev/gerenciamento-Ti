using System.ComponentModel.DataAnnotations;

namespace gerenciamento_Ti.DTO
{
    public class UsuarioDTO
    {
        [Required]
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
