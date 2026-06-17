using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamento_Ti.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TipoEquipamentoController : ControllerBase
    {
        private readonly ITipoEquipamentoService tipoequipamentoService;
        public TipoEquipamentoController(ITipoEquipamentoService _tipoequipamentoService)
        {
            tipoequipamentoService = _tipoequipamentoService;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> GetList()
        {
            var tipoequipamento = await tipoequipamentoService.GetAllAsync();

            return Ok(tipoequipamento);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var tipoequipamento = await tipoequipamentoService.GetById(id);

                if (tipoequipamento == null)
                    return NotFound();

                return Ok(tipoequipamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoEquipamentoDTO tipoequipamentoDTO)
        {
            if (tipoequipamentoDTO == null)
                return BadRequest();
            else if (string.IsNullOrWhiteSpace(tipoequipamentoDTO.Descricao))
                return BadRequest();
            else if (string.IsNullOrEmpty(tipoequipamentoDTO.Observacao))
                return BadRequest();

            var id = await tipoequipamentoService.CreateAsync(tipoequipamentoDTO);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] TipoEquipamentoDTO tipoequipamentoDTO, int id)
        {
            if (tipoequipamentoDTO == null)
                return BadRequest();
            else if (string.IsNullOrWhiteSpace(tipoequipamentoDTO.Descricao))
                return BadRequest();
            else if (string.IsNullOrEmpty(tipoequipamentoDTO.Observacao))
                return BadRequest();

            var _id = await tipoequipamentoService.UpdateAsync(id, tipoequipamentoDTO);

            return Ok(_id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletou = false;

            try
            {
                deletou = await tipoequipamentoService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(deletou);
        }
    }
}
