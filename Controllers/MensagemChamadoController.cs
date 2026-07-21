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
    public class MensagemChamadoController : ControllerBase
    {
        private readonly IMensagemChamadoService mensagemChamadoService;
        public MensagemChamadoController(IMensagemChamadoService _mensagemChamadoService)
        {
            mensagemChamadoService = _mensagemChamadoService;
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
            else if (mensagemChamadoDTO.UsuarioChamadoId == null)
                return BadRequest();
            else if (mensagemChamadoDTO.ChamadoId == null)
                return BadRequest();

            var id = await mensagemChamadoService.CreateAsync(mensagemChamadoDTO);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] MensagemChamadoDTO mensagemChamadoDTO, int id)
        {
            if (mensagemChamadoDTO.ChamadoId == null)
                return BadRequest();
            else if (mensagemChamadoDTO.UsuarioChamadoId == null)
                return BadRequest();
            else if (mensagemChamadoDTO.ChamadoId == null)
                return BadRequest();

            var _id = await mensagemChamadoService.UpdateAsync(id, mensagemChamadoDTO);

            return Ok(_id);
        }

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
