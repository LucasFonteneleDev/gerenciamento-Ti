using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Services.Interface
{
    public interface IFuncionarioService
    {
        public Task<Funcionario> GetById(int id);
        public Task<List<Funcionario>> GetAllAsync();
        public Task<int> CreateAsync(FuncionarioDTO funcionarioDTO);
        public Task<int> UpdateAsync(int id, FuncionarioDTO funcionarioDTO);
        public Task<bool> DeleteAsync(int id);
    }
}
