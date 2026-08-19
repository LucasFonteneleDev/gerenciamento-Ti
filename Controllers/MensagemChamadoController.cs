using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Implementation;
using gerenciamento_Ti.Services.Interface;
using gerenciamento_Ti.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace gerenciamento_Ti.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MensagemChamadoController : ControllerBase
    {
        private readonly IMensagemChamadoService mensagemChamadoService;
        private readonly IUsuarioChamadoService usuarioChamadoService;
        private readonly IChamadoService chamadoService;
        private readonly IUsuarioService usuarioService;
        public MensagemChamadoController(IMensagemChamadoService _mensagemChamadoService,
                                         IUsuarioChamadoService _usuarioChamadoService,
                                         IChamadoService _chamadoService,
                                         IUsuarioService _usuario)
        {
            mensagemChamadoService = _mensagemChamadoService;
            usuarioChamadoService = _usuarioChamadoService;
            chamadoService = _chamadoService;
            usuarioService = _usuario;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> GetList()
        {
            var MensagemChamados = await mensagemChamadoService.GetAllAsync();

            List<MensagemChamadoDTOGet> mensagemChamadosDTOget = new List<MensagemChamadoDTOGet>();
            foreach (var MensagemChamado in MensagemChamados)
            {
                mensagemChamadosDTOget.Add(
                        UDTOMensagemChamadoGet.AplicarValores(MensagemChamado)
                    );
            }

            return Ok(mensagemChamadosDTOget);
        }

        [HttpGet("listagem/{id_Chamado}")]
        public async Task<IActionResult> GetListByChamado(int id_Chamado)
        {
            var MensagemChamados = await mensagemChamadoService.GetAllFromChamadoAsync(id_Chamado);

            List<MensagemChamadoDTOGet> mensagemChamadosDTOget = new List<MensagemChamadoDTOGet>();
            foreach (var MensagemChamado in MensagemChamados)
            {
                mensagemChamadosDTOget.Add(
                        UDTOMensagemChamadoGet.AplicarValores(MensagemChamado)
                    );
            }

            return Ok(mensagemChamadosDTOget);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var mensagemChamado = await mensagemChamadoService.GetById(id);

                if (mensagemChamado == null)
                    return NotFound();

                MensagemChamadoDTOGet mensagemChamadoDTOGet = UDTOMensagemChamadoGet.AplicarValores(mensagemChamado);

                return Ok(mensagemChamadoDTOGet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MensagemChamadoDTO mensagemChamadoDTO)
        {
            if (mensagemChamadoDTO.ChamadoId == null)
                return BadRequest();
            //else if (mensagemChamadoDTO.UsuarioChamadoId == null)
            //    return BadRequest();
            else if (mensagemChamadoDTO.Texto == null)
                return BadRequest();

            //recuperando id do usuario chamado a partir do usuário da token
            //todo:tratamento de id usuario nula
            var usuarioId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var chamado = await chamadoService.GetById(mensagemChamadoDTO.ChamadoId);

            if(chamado == null)
                return NotFound("Chamado desta mensagem não encontrado.");

            var usuarioChamado = chamado.UsuarioChamado
                .FirstOrDefault(x => x.UsuarioId == usuarioId!);

            if (usuarioChamado == null)
            {
                //return NotFound("Usuário não está associado a este chamado.");

                var usuario = await usuarioService.GetById(usuarioId);
                //todo: tratamento de usuário Null

                if(usuario.NivelAtendente != Enum.EnumNivelAtendente.NaoAtende){
                    var usuarioChamadoNovo = new UsuarioChamadoDTO
                    {
                        Tipo = Enum.EnumTipoUsuarioChamado.Atendente,
                        ChamadoId = chamado.Id,
                        UsuarioId = usuarioId
                    };

                    var idUsuarioChamado = await usuarioChamadoService.CreateAsync(usuarioChamadoNovo);

                    usuarioChamado = await usuarioChamadoService.GetById(idUsuarioChamado);
                }

            }

            var usuarioChamadoId = usuarioChamado.Id;

            //construindo MensagemChamado
            var mensagemChamado = new MensagemChamado();
            mensagemChamado.ChamadoId = mensagemChamadoDTO.ChamadoId;
            mensagemChamado.UsuarioChamadoId = usuarioChamadoId;
            mensagemChamado.Texto = mensagemChamadoDTO.Texto;

            var id = await mensagemChamadoService.CreateAsync(mensagemChamado);

            return Ok(id);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update([FromBody] MensagemChamadoDTO mensagemChamadoDTO, int id)
        //{
        //    if (mensagemChamadoDTO.ChamadoId == null)
        //        return BadRequest();
        //    else if (mensagemChamadoDTO.UsuarioChamadoId == null)
        //        return BadRequest();
        //    else if (mensagemChamadoDTO.ChamadoId == null)
        //        return BadRequest();

        //    var _id = await mensagemChamadoService.UpdateAsync(id, mensagemChamadoDTO);

        //    return Ok(_id);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletou = false;

            try
            {
                deletou = await mensagemChamadoService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(deletou);
        }
    }
}
