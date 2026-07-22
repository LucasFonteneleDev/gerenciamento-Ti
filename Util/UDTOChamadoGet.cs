using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Util
{
    public class UDTOChamadoGet
    {
        public static ChamadoDTOGet AplicarValores(Chamado Chamado)
        {
            var empresasGET = new ChamadoDTOGet();

            empresasGET.Id = Chamado.Id;
            empresasGET.Solucao = Chamado.Solucao;
            empresasGET.Inicio = Chamado.Inicio;
            empresasGET.Fim = Chamado.Fim;
            empresasGET.RequisitanteInicialId = Chamado.UsuarioId;
            empresasGET.RequisitanteIncialNome = Chamado.Usuario.Nome;

            return empresasGET;
        }
    }
}
