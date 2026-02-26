using gerenciamento_Ti.Database;
using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_Ti.Services.Implementation
{
    public class EmpresaService : IEmpresaService
    {
        public GerenciamentoDbContext context;
        public EmpresaService(GerenciamentoDbContext DBcontext)
        {
            this.context = DBcontext;
        }

        public async Task<Empresa> GetById(int id)
        {
            var Empresa = await context.Empresa.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (Empresa == null)
            {
                throw new Exception("Nenhuma empresa com esta ID");
            }

            return Empresa;
        }

        public async Task<List<Empresa>> GetAllAsync()
        {
            return await context.Empresa.ToListAsync();
        }

        public async Task<int> CreateAsync(EmpresaDTO EmpresaDTO)
        {
            var Empresa = new Empresa
            {
                Nome_Loja = EmpresaDTO.Nome_Loja ,
                CNPJ = EmpresaDTO.CNPJ ,
                FuncionarioId = EmpresaDTO.FuncionarioId
            };

            context.Empresa.Add(Empresa);
            await context.SaveChangesAsync();

            return Empresa.Id;
        }

        public async Task<int> UpdateAsync(int id, EmpresaDTO EmpresaDTO)
        {
            var Empresa = await GetById(id);

            if (Empresa == null)
                throw new Exception("Esta empresa não foi encontrada.");

            Empresa.Nome_Loja = EmpresaDTO.Nome_Loja ;
            Empresa.CNPJ = EmpresaDTO.CNPJ ;
            Empresa.FuncionarioId = EmpresaDTO.FuncionarioId;

            await context.SaveChangesAsync();
            return Empresa.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Empresa = await GetById(id);

            if (Empresa == null)
                throw new Exception("Esta empresa não foi encontrada.");

            context.Empresa.Remove(Empresa);

            await context.SaveChangesAsync();
            return true;
        }
    }
}
