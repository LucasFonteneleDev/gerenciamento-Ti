using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Services.Interface
{
    public interface IUsuarioChamadoService
    {
        public Task<UsuarioChamado> GetById(int id);
        public Task<List<UsuarioChamado>> GetAllAsync();
        public Task<int> CreateAsync(UsuarioChamadoDTO usuarioChamadoDTO);
        public Task<int> UpdateAsync(int id, UsuarioChamadoDTO usuarioChamadoDTO);
        public Task<bool> DeleteAsync(int id);
    }
}
