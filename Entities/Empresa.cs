using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gerenciamento_Ti.Entities
{
    public class Empresa
    {
        [Required]
        public int Id { get; set; }
        public string Nome_Loja { get; set; }
        public string CNPJ { get; set; }
        public int FuncionarioId { get; set; }

        public Funcionario Funcionario { get; set; }

        [JsonIgnore]
        public List<Equipamento> Equipamentos { get; set; }
    }
}
