using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Services.Interface
{
    public interface ITipoEquipamentoService
    {
        public Task<TipoEquipamento> GetById(int id);
        public Task<List<TipoEquipamento>> GetAllAsync();
        public Task<int> CreateAsync(TipoEquipamentoDTO tipoEquipamentoDTO);
        public Task<int> UpdateAsync(int id, TipoEquipamentoDTO tipoEquipamentoDTO);
        public Task<bool> DeleteAsync(int id);
    }
}
