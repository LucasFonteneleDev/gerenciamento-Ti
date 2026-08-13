using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using gerenciamento_Ti.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace gerenciamento_Ti.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService chamadoService;
        private readonly IUsuarioChamadoService usuarioChamadoService;
        public ChamadoController(IChamadoService _chamadoService,
                                 IUsuarioChamadoService _usuarioChamadoService)
        {
            chamadoService = _chamadoService;
            usuarioChamadoService = _usuarioChamadoService;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> GetList()
        {
            var Chamados = await chamadoService.GetAllAsync();

            List<ChamadoDTOGet> chamadosDTOget = new List<ChamadoDTOGet>();
            foreach (var Chamado in Chamados)
            {
                chamadosDTOget.Add(
                        UDTOChamadoGet.AplicarValores(Chamado)
                    );
            }

            return Ok(chamadosDTOget);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var chamado = await chamadoService.GetById(id);

                if (chamado == null)
                    return NotFound();

                ChamadoDTOGet chamadoDTO = UDTOChamadoGet.AplicarValores(chamado);

                return Ok(chamadoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChamadoDTO chamadoDTO)
        {
            //validação do chamado
            if (chamadoDTO == null)
                return BadRequest();
            else if (chamadoDTO.Inicio == null)
                return BadRequest();

            //construindo objeto de CHAMADO
            var chamado = new Chamado();
            chamado.Assunto = chamadoDTO.Assunto;
            chamado.Inicio = chamadoDTO.Inicio;
            chamado.Fim = chamadoDTO.Fim;
            chamado.Solucao = chamadoDTO.Solucao;

            //recuperando id do usuário do token
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            chamado.UsuarioId = int.Parse(usuarioId!);

            var idchamado = await chamadoService.CreateAsync(chamado);

            //criando usuário do chamado
            var usuarioChamado = new UsuarioChamadoDTO();
            usuarioChamado.ChamadoId = idchamado;
            usuarioChamado.UsuarioId = chamado.UsuarioId;
            usuarioChamado.Tipo = Enum.TipoUsuarioChamado.Requisitante;

            //não é necessário repassar a id de usuario_chamado pois será deduzido do token
            await usuarioChamadoService.CreateAsync(usuarioChamado);

            return Ok(idchamado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ChamadoDTO chamadoDTO, int id)
        {
            if (chamadoDTO == null)
                return BadRequest();
            else if (chamadoDTO.Inicio == null)
                return BadRequest();

            var chamado = new Chamado();
            chamado.Assunto = chamadoDTO.Assunto;
            chamado.Inicio = chamadoDTO.Inicio;
            chamado.Fim = chamadoDTO.Fim;
            chamado.Solucao = chamadoDTO.Solucao;

            var _id = await chamadoService.UpdateAsync(id, chamado);

            return Ok(_id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletou = false;

            try
            {
                deletou = await chamadoService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(deletou);
        }
    }
}
