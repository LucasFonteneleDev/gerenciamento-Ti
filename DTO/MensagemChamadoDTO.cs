using gerenciamento_Ti.Enum;

namespace gerenciamento_Ti.DTO
{
    public class MensagemChamadoDTO
    {
        public int ChamadoId { get; set; }
        public int UsuarioChamadoId { get; set; }
        public string Texto { get; set; }
        public DateTime Envio { get; set; }
        public bool Enviado { get; set; }
        public bool ConfirmaRecebido { get; set; }
    }

    public class MensagemChamadoDTOGet
    {
        public int Id { get; set; }
        public int ChamadoId { get; set; }
        public int UsuarioChamadoId { get; set; }
        public string Texto { get; set; }
        public DateTime Envio { get; set; }
        public bool Enviado { get; set; }
        public bool ConfirmaRecebido { get; set; }
    }
}
