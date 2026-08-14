using System.ComponentModel.DataAnnotations;
using gerenciamento_Ti.Enum;

namespace gerenciamento_Ti.DTO
{
    public class UsuarioDTO
    {
        [Required]
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        //todo: Temporário. Ainda não faz sentido criar um controle completo de níveis de atendimento;
        public EnumNivelAtendente NivelAtendente { get; set; }
    }

    public class UsuarioDTOGet
    {
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public EnumNivelAtendente NivelAtendente { get; set; }
    }
}
