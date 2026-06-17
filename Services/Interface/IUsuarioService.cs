using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Services.Interface
{
    public interface IUsuarioService
    {
        public Task<Usuario> GetById(int id);
        public Task<Usuario?> GetByEmail(string email);
        public Task<Usuario?> GetByNome(string email);
        public Task<List<Usuario>> GetAllAsync();
        public Task<int> CreateAsync(UsuarioDTO empresaDTO);
        public Task<int> UpdateAsync(int id, UsuarioDTO empresaDTO);
        public Task<bool> DeleteAsync(int id);
    }
}
