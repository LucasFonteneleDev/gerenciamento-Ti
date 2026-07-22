using gerenciamento_Ti.Database;
using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_Ti.Services.Implementation
{
    public class ChamadoService : IChamadoService
    {
        public GerenciamentoDbContext context;
        public ChamadoService(GerenciamentoDbContext DBcontext)
        {
            this.context = DBcontext;
        }

        public async Task<Chamado> GetById(int id)
        {
            var Chamado = await context.Chamado.Where(x => x.Id == id)
                .Include(x=> x.Usuario)
                .FirstOrDefaultAsync();

            if (Chamado == null)
            {
                throw new Exception("Nenhum chamado com esta ID");
            }

            return Chamado;
        }

        public async Task<List<Chamado>> GetAllAsync()
        {
            return await context.Chamado
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<int> CreateAsync(ChamadoDTO ChamadoDTO)
        {
            var Chamado = new Chamado
            {
                Solucao = ChamadoDTO.Solucao,
                Inicio = ChamadoDTO.Inicio,
                Fim = ChamadoDTO.Fim,
                UsuarioId = ChamadoDTO.RequisitanteIncialId
            };

            context.Chamado.Add(Chamado);
            await context.SaveChangesAsync();

            return Chamado.Id;
        }

        public async Task<int> UpdateAsync(int id, ChamadoDTO ChamadoDTO)
        {
            var Chamado = await GetById(id);

            if (Chamado == null)
                throw new Exception("Este chamado não foi encontrado.");

            Chamado.Solucao = ChamadoDTO.Solucao;
            Chamado.Inicio = ChamadoDTO.Inicio;
            Chamado.Fim = ChamadoDTO.Fim;
            Chamado.UsuarioId = ChamadoDTO.RequisitanteIncialId;

            await context.SaveChangesAsync();
            return Chamado.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Chamado = await GetById(id);

            if (Chamado == null)
                throw new Exception("Este chamado não foi encontrado.");

            context.Chamado.Remove(Chamado);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
