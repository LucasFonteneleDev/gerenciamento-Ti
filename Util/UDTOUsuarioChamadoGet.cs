using gerenciamento_Ti.DTO;

using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Util
{
    public class UDTOUsuarioChamadoGet
    {
        public static UsuarioChamadoDTOGet AplicarValores(UsuarioChamado UsuarioChamado)
        {
            var usuarioChamadosGET = new UsuarioChamadoDTOGet();

            usuarioChamadosGET.Id = UsuarioChamado.Id;
            usuarioChamadosGET.ChamadoId = UsuarioChamado.ChamadoId;
            usuarioChamadosGET.UsuarioId = UsuarioChamado.UsuarioId;
            usuarioChamadosGET.Tipo = UsuarioChamado.Tipo;

            return usuarioChamadosGET;
        }
    }
}
