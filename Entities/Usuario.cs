using System.Text.Json.Serialization;
using gerenciamento_Ti.Enum;

namespace gerenciamento_Ti.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public EnumNivelAtendente NivelAtendente { get; set; }

        [JsonIgnore]
        public List<UsuarioChamado> UsuarioChamado { get; set; }
        [JsonIgnore]
        public List<MensagemChamado> MensagemChamado { get; set; }
        [JsonIgnore]
        public List<Chamado> Chamado { get; set; }
    }
}
