using gerenciamento_Ti.Database;
using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_Ti.Services.Implementation
{
    public class TipoEquipamentoService : ITipoEquipamentoService
    {
        public GerenciamentoDbContext context;
        public TipoEquipamentoService(GerenciamentoDbContext DBcontext)
        {
            this.context = DBcontext;
        }

        public async Task<TipoEquipamento> GetById(int id)
        {
            var TipoEquipamento = await context.TipoEquipamento.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (TipoEquipamento == null)
            {
                throw new Exception("Nenhum tipo de equipamento com esta ID");
            }

            return TipoEquipamento;
        }

        public async Task<List<TipoEquipamento>> GetAllAsync()
        {
            return await context.TipoEquipamento.ToListAsync();
        }

        public async Task<int> CreateAsync(TipoEquipamentoDTO TipoEquipamentoDTO)
        {
            var TipoEquipamento = new TipoEquipamento
            {
                Descricao = TipoEquipamentoDTO.Descricao,
                Observacao = TipoEquipamentoDTO.Observacao
            };

            context.TipoEquipamento.Add(TipoEquipamento);
            await context.SaveChangesAsync();

            return TipoEquipamento.Id;
        }

        public async Task<int> UpdateAsync(int id, TipoEquipamentoDTO TipoEquipamentoDTO)
        {
            var TipoEquipamento = await GetById(id);

            if (TipoEquipamento == null)
                throw new Exception("Este tipo de equipamento não foi encontrado.");

            TipoEquipamento.Descricao = TipoEquipamentoDTO.Descricao;
            TipoEquipamento.Observacao = TipoEquipamentoDTO.Observacao;

            await context.SaveChangesAsync();
            return TipoEquipamento.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var TipoEquipamento = await GetById(id);

            if (TipoEquipamento == null)
                throw new Exception("Este tipo de equipamento não foi encontrado.");

            context.TipoEquipamento.Remove(TipoEquipamento);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
