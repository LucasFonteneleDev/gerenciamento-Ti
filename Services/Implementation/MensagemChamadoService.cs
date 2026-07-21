using gerenciamento_Ti.Database;
using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_Ti.Services.Implementation
{
    public class MensagemChamadoService : IMensagemChamadoService
    {
        public GerenciamentoDbContext context;
        public MensagemChamadoService(GerenciamentoDbContext DBcontext)
        {
            this.context = DBcontext;
        }

        public async Task<MensagemChamado> GetById(int id)
        {
            var MensagemChamado = await context.MensagemChamado
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (MensagemChamado == null)
            {
                throw new Exception("Nenhum Mensagem de Chamado com esta ID");
            }

            return MensagemChamado;
        }

        public async Task<List<MensagemChamado>> GetAllAsync()
        {
            return await context.MensagemChamado
                .ToListAsync();
        }

        public async Task<int> CreateAsync(MensagemChamadoDTO MensagemChamadoDTO)
        {
            var MensagemChamado = new MensagemChamado
            {
                ChamadoId = MensagemChamadoDTO.ChamadoId,
                UsuarioChamadoId = MensagemChamadoDTO.UsuarioChamadoId,
                Texto = MensagemChamadoDTO.Texto,
                Envio = MensagemChamadoDTO.Envio,
                Enviado = MensagemChamadoDTO.Enviado,
                ConfirmaRecebido = MensagemChamadoDTO.ConfirmaRecebido
            };

            context.MensagemChamado.Add(MensagemChamado);
            await context.SaveChangesAsync();

            return MensagemChamado.Id;
        }

        public async Task<int> UpdateAsync(int id, MensagemChamadoDTO MensagemChamadoDTO)
        {
            var mensagemChamado = await GetById(id);

            if (mensagemChamado == null)
                throw new Exception("Esta Mensagem do Chamado não foi encontrada.");

            mensagemChamado.ChamadoId = MensagemChamadoDTO.ChamadoId;
            mensagemChamado.UsuarioChamadoId = MensagemChamadoDTO.UsuarioChamadoId;
            mensagemChamado.Texto = MensagemChamadoDTO.Texto;
            mensagemChamado.Envio = MensagemChamadoDTO.Envio;
            mensagemChamado.Enviado = MensagemChamadoDTO.Enviado;
            mensagemChamado.ConfirmaRecebido = MensagemChamadoDTO.ConfirmaRecebido;

            await context.SaveChangesAsync();
            return mensagemChamado.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var MensagemChamado = await GetById(id);

            if (MensagemChamado == null)
                throw new Exception("Esta Mensagem de Chamado não foi encontrada.");

            context.MensagemChamado.Remove(MensagemChamado);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
