using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Util
{
    public class UDTOUsuarioGet
    {
        public static UsuarioDTOGet AplicarValores(Usuario usuario)
        {
            var usuarioGET = new UsuarioDTOGet();

            usuarioGET.Id = usuario.Id;
            usuarioGET.Nome = usuario.Nome;
            usuarioGET.Email = usuario.Email;

            return usuarioGET;
        }
    }
}