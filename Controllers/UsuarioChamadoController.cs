using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using gerenciamento_Ti.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamento_Ti.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsuarioChamadoController : ControllerBase
    {
        private readonly IUsuarioChamadoService usuarioChamadoService;
        public UsuarioChamadoController(IUsuarioChamadoService _usuarioChamadoService)
        {
            usuarioChamadoService = _usuarioChamadoService;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> GetList()
        {
            var UsuarioChamados = await usuarioChamadoService.GetAllAsync();

            List<UsuarioChamadoDTOGet> usuarioChamadosDTOget = new List<UsuarioChamadoDTOGet>();
            foreach (var UsuarioChamado in UsuarioChamados)
            {
                usuarioChamadosDTOget.Add(
                        UDTOUsuarioChamadoGet.AplicarValores(UsuarioChamado)
                    );
            }

            return Ok(usuarioChamadosDTOget);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuarioChamado = await usuarioChamadoService.GetById(id);

                if (usuarioChamado == null)
                    return NotFound();

                UsuarioChamadoDTOGet usuarioChamadoDTOGet = UDTOUsuarioChamadoGet.AplicarValores(usuarioChamado);

                return Ok(usuarioChamadoDTOGet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioChamadoDTO usuarioChamadoDTO)
        {
            if (usuarioChamadoDTO.ChamadoId == null)
                return BadRequest();
            else if (usuarioChamadoDTO.UsuarioId == null)
                return BadRequest();

            var id = await usuarioChamadoService.CreateAsync(usuarioChamadoDTO);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UsuarioChamadoDTO usuarioChamadoDTO, int id)
        {
            if (usuarioChamadoDTO.ChamadoId == null)
                return BadRequest();
            else if (usuarioChamadoDTO.UsuarioId == null)
                return BadRequest();

            var _id = await usuarioChamadoService.UpdateAsync(id, usuarioChamadoDTO);

            return Ok(_id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletou = false;

            try
            {
                deletou = await usuarioChamadoService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(deletou);
        }
    }
}
