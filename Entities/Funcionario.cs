using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gerenciamento_Ti.Entities
{
    public class Funcionario
    {
        [Required]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Senha { get; set; }
        public bool Usuario_Ativo { get; set; }
        public bool Esta_Ativo_Plataforma { get; set; }

        [JsonIgnore]
        public virtual List<Empresa> Empresas { get; set; } = new List<Empresa>();
        [JsonIgnore]
        public virtual List<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();
    }
}
