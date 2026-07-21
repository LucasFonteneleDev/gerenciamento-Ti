using gerenciamento_Ti.Enum;

namespace gerenciamento_Ti.DTO
{
    public class UsuarioChamadoDTO
    {
        public int ChamadoId { get; set; }
        public int UsuarioId { get; set; }
        public TipoUsuarioChamado Tipo { get; set; }
    }

    public class UsuarioChamadoDTOGet
    {
        public int Id { get; set; }
        public int ChamadoId { get; set; }
        public int UsuarioId { get; set; }
        public TipoUsuarioChamado Tipo { get; set; }
    }
}
