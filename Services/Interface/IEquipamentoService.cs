using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Services.Interface
{
    public interface IEquipamentoService
    {
        public Task<Equipamento> GetById(int id);
        public Task<List<Equipamento>> GetAllAsync();
        public Task<int> CreateAsync(EquipamentoDTO equipamentoDTO);
        public Task<int> UpdateAsync(int id, EquipamentoDTO equipamentoDTO);
        public Task<bool> DeleteAsync(int id);
    }
}
