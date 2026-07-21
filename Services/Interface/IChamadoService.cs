using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Services.Interface
{
    public interface IChamadoService
    {
        public Task<Chamado> GetById(int id);
        public Task<List<Chamado>> GetAllAsync();
        public Task<int> CreateAsync(ChamadoDTO chamadoDTO);
        public Task<int> UpdateAsync(int id, ChamadoDTO chamadoDTO);
        public Task<bool> DeleteAsync(int id);
    }
}