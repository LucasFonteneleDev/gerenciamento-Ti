using gerenciamento_Ti.Database;
using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_Ti.Services.Implementation
{
    public class UsuarioChamadoService : IUsuarioChamadoService
    {
        public GerenciamentoDbContext context;
        public UsuarioChamadoService(GerenciamentoDbContext DBcontext)
        {
            this.context = DBcontext;
        }

        public async Task<UsuarioChamado> GetById(int id)
        {
            var UsuarioChamado = await context.UsuarioChamado
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (UsuarioChamado == null)
            {
                throw new Exception("Nenhum Usuario de Chamado com esta ID");
            }

            return UsuarioChamado;
        }

        public async Task<List<UsuarioChamado>> GetAllAsync()
        {
            return await context.UsuarioChamado
                .ToListAsync();
        }

        public async Task<int> CreateAsync(UsuarioChamadoDTO UsuarioChamadoDTO)
        {
            var UsuarioChamado = new UsuarioChamado
            {
                ChamadoId = UsuarioChamadoDTO.ChamadoId,
                UsuarioId = UsuarioChamadoDTO.UsuarioId,
                Tipo = UsuarioChamadoDTO.Tipo
            };

            context.UsuarioChamado.Add(UsuarioChamado);
            await context.SaveChangesAsync();

            return UsuarioChamado.Id;
        }

        public async Task<int> UpdateAsync(int id, UsuarioChamadoDTO UsuarioChamadoDTO)
        {
            var UsuarioChamado = await GetById(id);

            if (UsuarioChamado == null)
                throw new Exception("Este Usuario do Chamado não foi encontrado.");

            UsuarioChamado.ChamadoId = UsuarioChamadoDTO.ChamadoId;
            UsuarioChamado.UsuarioId = UsuarioChamadoDTO.UsuarioId;
            UsuarioChamado.Tipo = UsuarioChamadoDTO.Tipo;

            await context.SaveChangesAsync();
            return UsuarioChamado.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var UsuarioChamado = await GetById(id);

            if (UsuarioChamado == null)
                throw new Exception("Este Usuario de Chamado não foi encontrado.");

            context.UsuarioChamado.Remove(UsuarioChamado);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
