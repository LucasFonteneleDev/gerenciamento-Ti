namespace gerenciamento_Ti.DTO
{
    public class ChamadoDTO
    {
        public string Assunto { get; set; }
    }

    public class ChamadoDTOPut
    {
        public string? Solucao { get; set; }
        public DateTime? Fim { get; set; }
    }

    public class ChamadoDTOGet
    {
        public int Id { get; set; }
        public string? Solucao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public int RequisitanteInicialId { get; set; }
        public string RequisitanteInicialNome { get; set; }
        public string Assunto { get; set; }
    }
}
