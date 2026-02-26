using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gerenciamento_Ti.Entities
{
    public class Equipamento
    {
        [Required]
        public int Id { get; set; }
        public int TipoEquipamentoId { get; set; }
        public string Numero_Serie { get; set; }
        public int EmpresaId { get; set; }
        public int? FuncionarioId { get; set; }

        [JsonIgnore]
        public virtual Empresa Empresa { get; set; }

        [JsonIgnore]
        public virtual TipoEquipamento TipoEquipamento { get; set; }
    }
}
