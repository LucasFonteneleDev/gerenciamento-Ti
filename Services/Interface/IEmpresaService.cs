using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Services.Interface
{
    public interface IEmpresaService
    {
        public Task<Empresa> GetById(int id);
        public Task<List<Empresa>> GetAllAsync();
        public Task<int> CreateAsync(EmpresaDTO empresaDTO);
        public Task<int> UpdateAsync(int id, EmpresaDTO empresaDTO);
        public Task<bool> DeleteAsync(int id);
    }
}
