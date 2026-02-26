using gerenciamento_Ti.Database;
using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_Ti.Services.Implementation
{
    public class EquipamentoService : IEquipamentoService
    {
        public GerenciamentoDbContext context;
        public EquipamentoService(GerenciamentoDbContext DBcontext)
        {
            this.context = DBcontext;
        }

        public async Task<Equipamento> GetById(int id)
        {
            var Equipamento = await context.Equipamento.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (Equipamento == null)
            {
                throw new Exception("Nenhum equipamento com esta ID");
            }

            return Equipamento;
        }

        public async Task<List<Equipamento>> GetAllAsync()
        {
            return await context.Equipamento.ToListAsync();
        }

        public async Task<int> CreateAsync(EquipamentoDTO EquipamentoDTO)
        {
            var Equipamento = new Equipamento
            {
                TipoEquipamentoId = EquipamentoDTO.TipoEquipamentoId ,
                Numero_Serie = EquipamentoDTO.Numero_Serie ,
                EmpresaId = EquipamentoDTO.EmpresaId ,
                FuncionarioId = EquipamentoDTO.FuncionarioId
            };

            context.Equipamento.Add(Equipamento);
            await context.SaveChangesAsync();

            return Equipamento.Id;
        }

        public async Task<int> UpdateAsync(int id, EquipamentoDTO EquipamentoDTO)
        {
            var Equipamento = await GetById(id);

            if (Equipamento == null)
                throw new Exception("Este equipamento não foi encontrado.");

            Equipamento.TipoEquipamentoId = EquipamentoDTO.TipoEquipamentoId ;
            Equipamento.Numero_Serie = EquipamentoDTO.Numero_Serie ;
            Equipamento.EmpresaId = EquipamentoDTO.EmpresaId ;
            Equipamento.FuncionarioId = EquipamentoDTO.FuncionarioId;

            await context.SaveChangesAsync();
            return Equipamento.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Equipamento = await GetById(id);

            if (Equipamento == null)
                throw new Exception("Este equipamento não foi encontrado.");

            context.Equipamento.Remove(Equipamento);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
