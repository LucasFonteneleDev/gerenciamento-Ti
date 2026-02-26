using gerenciamento_Ti.Database;
using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_Ti.Services.Implementation
{
    public class FuncionarioService : IFuncionarioService
    {
        public GerenciamentoDbContext context;
        public FuncionarioService(GerenciamentoDbContext DBcontext)
        {
            this.context = DBcontext;
        }

        public async Task<Funcionario> GetById(int id)
        {
            var funcionario = await context.Funcionario.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (funcionario == null)
            {
                throw new Exception("Nenhum funcionário com esta ID");
            }

            return funcionario;
        }

        public async Task<List<Funcionario>> GetAllAsync()
        {
            return await context.Funcionario.ToListAsync();
        }

        public async Task<int> CreateAsync(FuncionarioDTO funcionarioDTO)
        {
            var funcionario = new Funcionario
            {
                Email = funcionarioDTO.Email,
                Nome = funcionarioDTO.Nome,
                Contato = funcionarioDTO.Contato,
                Senha = funcionarioDTO.Senha,
                Usuario_Ativo = funcionarioDTO.Usuario_Ativo,
                Esta_Ativo_Plataforma = funcionarioDTO.Esta_Ativo_Plataforma
            };

            context.Funcionario.Add(funcionario);
            await context.SaveChangesAsync();

            return funcionario.Id;
        }

        public async Task<int> UpdateAsync(int id, FuncionarioDTO funcionarioDTO)
        {
            var funcionario = await GetById(id);

            if (funcionario == null)
                throw new Exception("Este funcionário não foi encontrado.");

            funcionario.Email = funcionarioDTO.Email;
            funcionario.Nome = funcionarioDTO.Nome;
            funcionario.Contato = funcionarioDTO.Contato;
            funcionario.Senha = funcionarioDTO.Senha;
            funcionario.Usuario_Ativo = funcionarioDTO.Usuario_Ativo;
            funcionario.Esta_Ativo_Plataforma = funcionarioDTO.Esta_Ativo_Plataforma;

            await context.SaveChangesAsync();
            return funcionario.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var funcionario = await GetById(id);

            if (funcionario == null)
                throw new Exception("Este funcionário não foi encontrado.");

            context.Funcionario.Remove(funcionario);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
