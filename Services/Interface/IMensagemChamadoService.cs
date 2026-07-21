using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Services.Interface
{
    public interface IMensagemChamadoService
    {
        public Task<MensagemChamado> GetById(int id);
        public Task<List<MensagemChamado>> GetAllAsync();
        public Task<int> CreateAsync(MensagemChamadoDTO usuarioChamadoDTO);
        public Task<int> UpdateAsync(int id, MensagemChamadoDTO usuarioChamadoDTO);
        public Task<bool> DeleteAsync(int id);
    }
}
