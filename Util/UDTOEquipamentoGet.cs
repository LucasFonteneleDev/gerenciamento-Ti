using gerenciamento_Ti.DTO;

using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Util
{
    public class UDTOEquipamentoGet
    {
        public static EquipamentoDTOGet AplicarValores(Equipamento Equipamento)
        {
            var equipamentosGET = new EquipamentoDTOGet();

            equipamentosGET.Id = Equipamento.Id;
            equipamentosGET.TipoEquipamentoId = Equipamento.TipoEquipamentoId;
            equipamentosGET.TipoEquipamentoIdDescricao = Equipamento.TipoEquipamento.Descricao;
            equipamentosGET.Numero_Serie = Equipamento.Numero_Serie;
            equipamentosGET.EmpresaId = Equipamento.EmpresaId;
            equipamentosGET.EmpresaIdNome_Loja = Equipamento.Empresa.Nome_Loja;
            equipamentosGET.FuncionarioId = Equipamento.FuncionarioId;
            //todo: funcionário ID. Verificar estrutura de tabelas e corrigir referencia

            return equipamentosGET;
        }
    }
}
