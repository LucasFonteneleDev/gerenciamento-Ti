using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Services.Interface
{
    public interface IChamadoService
    {
        public Task<Chamado> GetById(int id);
        public Task<List<Chamado>> GetAllAsync();
        public Task<int> CreateAsync(Chamado chamado);
        public Task<int> UpdateAsync(int id, Chamado chamado);
        public Task<bool> DeleteAsync(int id);
    }
}