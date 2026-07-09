namespace gerenciamento_Ti.DTO
{
    public class EquipamentoDTO
    {
        public int TipoEquipamentoId { get; set; }
        public string Numero_Serie { get; set; }
        public int EmpresaId { get; set; }
        public int? FuncionarioId { get; set; }
    }

    public class EquipamentoDTOGet 
    {
        public int Id { get; set; }
        public int TipoEquipamentoId { get; set; }
        public string TipoEquipamentoIdDescricao { get; set; }
        public string Numero_Serie { get; set; }
        public int EmpresaId { get; set; }
        public string EmpresaIdNome_Loja { get; set; }
        public int? FuncionarioId { get; set; }
        public string? FuncionarioIdNome { get; set; }
    }
}
