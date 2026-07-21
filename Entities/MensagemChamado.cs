using System.ComponentModel.DataAnnotations;

namespace gerenciamento_Ti.Entities
{
    public class MensagemChamado
    {
        [Required]
        public int Id { get; set; }
        public int ChamadoId { get; set; }
        public int UsuarioChamadoId { get; set; }
        public string Texto { get; set; }
        public DateTime Envio { get; set; }
        public bool Enviado { get; set; }
        public bool ConfirmaRecebido { get; set; }

        public UsuarioChamado UsuarioChamado { get; set; }
        public Chamado Chamado { get; set; }
    }
}
