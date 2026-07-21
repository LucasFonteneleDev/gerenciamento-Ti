using gerenciamento_Ti.Enum;
using System.ComponentModel.DataAnnotations;

namespace gerenciamento_Ti.Entities
{
    public class UsuarioChamado
    {
        [Required]
        public int Id { get; set; }
        public int ChamadoId { get; set; }
        public int UsuarioId { get; set; }
        public TipoUsuarioChamado Tipo { get; set; }

        public Usuario Usuario { get; set; }
        public Chamado Chamado { get; set; }
    }
}
