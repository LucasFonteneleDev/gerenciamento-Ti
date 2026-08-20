using gerenciamento_Ti.DTO;

using gerenciamento_Ti.Entities;

namespace gerenciamento_Ti.Util
{
    public class UDTOMensagemChamadoGet
    {
        public static MensagemChamadoDTOGet AplicarValores(MensagemChamado MensagemChamado)
        {
            var mensagemChamadosGET = new MensagemChamadoDTOGet();

            //NOME DO USUÁRIO NA MENSAGEM
            if (MensagemChamado.UsuarioChamado != null
                && MensagemChamado.UsuarioChamado.Usuario != null)
            {
                mensagemChamadosGET.UsuarioChamadoNome = MensagemChamado.UsuarioChamado.Usuario.Nome;
            }

            mensagemChamadosGET.Id = MensagemChamado.Id;
            mensagemChamadosGET.ChamadoId = MensagemChamado.ChamadoId;
            mensagemChamadosGET.UsuarioChamadoId = MensagemChamado.UsuarioChamadoId;
            mensagemChamadosGET.Texto = MensagemChamado.Texto;
            mensagemChamadosGET.Envio = MensagemChamado.Envio;
            mensagemChamadosGET.Enviado = MensagemChamado.Enviado;
            mensagemChamadosGET.ConfirmaRecebido = MensagemChamado.ConfirmaRecebido;

            return mensagemChamadosGET;
        }
    }
}
