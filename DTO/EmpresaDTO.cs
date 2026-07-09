namespace gerenciamento_Ti.DTO
{
    public class EmpresaDTO
    {
        public string Nome_Loja { get; set; }
        public string CNPJ { get; set; }
        public int FuncionarioId { get; set; }
    }

    public class EmpresaDTOGet
    {
        public int Id { get; set; }
        public string Nome_Loja { get; set; }
        public string CNPJ { get; set; }
        public int FuncionarioId { get; set; }
        public string FuncionarioIdNome { get; set; }
    }
}
