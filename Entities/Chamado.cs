using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gerenciamento_Ti.Entities
{
    public class Chamado
    {
        [Required]
        public int Id { get; set; }
        public string? Solucao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public int UsuarioId { get; set; }

        [JsonIgnore]
        public List<UsuarioChamado> UsuarioChamado { get; set; }

        [JsonIgnore]
        public List<MensagemChamado> MensagemChamado { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}
