using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gerenciamento_Ti.Entities
{
    public class TipoEquipamento
    {
        [Required]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }

        [JsonIgnore]
        public virtual List<Equipamento> Equipamento { get; set; }
    }
}
