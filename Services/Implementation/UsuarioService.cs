using gerenciamento_Ti.Database;
using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_Ti.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        public GerenciamentoDbContext context;
        public UsuarioService(GerenciamentoDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<Usuario> GetById(int id)
        {
            var Usuario = await context.Usuario.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (Usuario == null)
            {
                throw new Exception("Nenhum usuário com esta ID");
            }

            return Usuario;
        }

        public async Task<Usuario?> GetByEmail(string email)
        {
            var Usuario = await context.Usuario.Where(x => x.Email == email).FirstOrDefaultAsync();

            //if (Usuario == null)
            //{
            //    throw new Exception("Nenhum usuario cadastrado");
            //}

            return Usuario;
        }

        public async Task<Usuario?> GetByNome(string nome)
        {
            var Usuario = await context.Usuario.Where(x => x.Nome == nome).FirstOrDefaultAsync();

            return Usuario;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await context.Usuario.ToListAsync();
        }

        public async Task<int> CreateAsync(UsuarioDTO UsuarioDTO)
        {
            var Usuario = new Usuario
            {
                Nome = UsuarioDTO.Nome,
                Email = UsuarioDTO.Email,
                SenhaHash = UsuarioDTO.Senha
            };

            context.Usuario.Add(Usuario);
            await context.SaveChangesAsync();

            return Usuario.Id;
        }

        public async Task<int> UpdateAsync(int id, UsuarioDTO UsuarioDTO)
        {
            var Usuario = await GetById(id);

            if (Usuario == null)
                throw new Exception("Este usuario não foi encontrado.");

            Usuario.Nome = UsuarioDTO.Nome;
            Usuario.Email = UsuarioDTO.Email;
            Usuario.SenhaHash = UsuarioDTO.Senha;

            await context.SaveChangesAsync();
            return Usuario.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Usuario = await GetById(id);

            if (Usuario == null)
                throw new Exception("Este usuario não foi encontrado.");

            context.Usuario.Remove(Usuario);

            await context.SaveChangesAsync();
            return true;
        }
    }
}
