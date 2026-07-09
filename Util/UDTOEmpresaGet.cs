using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Util
{
    public class UDTOEmpresaGet
    {
        public static EmpresaDTOGet AplicarValores(Empresa Empresa)
        {
            var empresasGET = new EmpresaDTOGet();

            empresasGET.Id = Empresa.Id;
            empresasGET.CNPJ = Empresa.CNPJ;
            empresasGET.Nome_Loja = Empresa.Nome_Loja;
            empresasGET.FuncionarioId = Empresa.FuncionarioId;
            empresasGET.FuncionarioIdNome = Empresa.Funcionario.Nome;

            return empresasGET;
        }
    }
}
