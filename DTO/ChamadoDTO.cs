namespace gerenciamento_Ti.DTO
{
    public class ChamadoDTO
    {
        public string? Solucao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public int RequisitanteIncialId { get; set; }
    }

    public class ChamadoDTOGet
    {
        public int Id { get; set; }
        public string? Solucao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public int RequisitanteInicialId { get; set; }
        public string RequisitanteIncialNome { get; set; }
    }
}
