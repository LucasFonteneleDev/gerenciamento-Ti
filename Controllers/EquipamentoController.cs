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
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamentoService equipamentoService;
        public EquipamentoController(IEquipamentoService _equipamentoService)
        {
            equipamentoService = _equipamentoService;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> GetList()
        {
            var Equipamentos = await equipamentoService.GetAllAsync();

            List<EquipamentoDTOGet> equipamentosDTOget = new List<EquipamentoDTOGet>();
            foreach (var Equipamento in Equipamentos)
            {
                equipamentosDTOget.Add(
                        UDTOEquipamentoGet.AplicarValores(Equipamento)
                    );
            }

            return Ok(equipamentosDTOget);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var equipamento = await equipamentoService.GetById(id);

                if (equipamento == null)
                    return NotFound();

                EquipamentoDTOGet equipamentoDTOGet = UDTOEquipamentoGet.AplicarValores(equipamento);

                return Ok(equipamentoDTOGet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EquipamentoDTO equipamentoDTO)
        {
            if (string.IsNullOrEmpty(equipamentoDTO.Numero_Serie))
                return BadRequest();

            var id = await equipamentoService.CreateAsync(equipamentoDTO);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] EquipamentoDTO equipamentoDTO, int id)
        {
            if (string.IsNullOrEmpty(equipamentoDTO.Numero_Serie))
                return BadRequest();

            var _id = await equipamentoService.UpdateAsync(id, equipamentoDTO);

            return Ok(_id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletou = false;

            try
            {
                deletou = await equipamentoService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(deletou);
        }
    }
}
