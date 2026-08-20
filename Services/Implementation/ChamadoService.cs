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
                .Include(x=> x.UsuarioChamado)
                .FirstOrDefaultAsync();

            if (Chamado == null)
            {
                throw new Exception("Nenhum chamado com esta ID");
            }

            return Chamado;
        }

        public async Task<List<Chamado>> GetListByUserId(int id)
        {
            var Chamados = await context.Chamado.Where(x => x.UsuarioId == id)
                .Include(x => x.Usuario)
                //.Include(x => x.UsuarioChamado)
                .ToListAsync();

            return Chamados;
        }

        public async Task<List<Chamado>> GetAllAsync()
        {
            return await context.Chamado
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<int> CreateAsync(Chamado chamado)
        {
            context.Chamado.Add(chamado);
            await context.SaveChangesAsync();

            return chamado.Id;
        }

        public async Task<int> UpdateAsync(int id, Chamado chamado)
        {
            var _Chamado = await GetById(id);

            if (_Chamado == null)
                throw new Exception("Este chamado não foi encontrado.");

            _Chamado.Solucao = chamado.Solucao;
            //_Chamado.Inicio = chamado.Inicio;
            _Chamado.Fim = chamado.Fim;
            //_Chamado.UsuarioId = chamado.UsuarioId;
            _Chamado.Assunto = chamado.Assunto;

            await context.SaveChangesAsync();
            return _Chamado.Id;
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
