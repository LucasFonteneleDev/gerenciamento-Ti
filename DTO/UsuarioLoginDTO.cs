using System.ComponentModel.DataAnnotations;

namespace gerenciamento_Ti.DTO
{
    public class UsuarioLoginDTO
    {
        [Required]
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
