using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Entities;
using gerenciamento_Ti.Services.Interface;
using gerenciamento_Ti.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamento_Ti.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService chamadoService;
        public ChamadoController(IChamadoService _chamadoService)
        {
            chamadoService = _chamadoService;
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
            if (chamadoDTO == null)
                return BadRequest();
            else if (chamadoDTO.Inicio == null)
                return BadRequest();

            var id = await chamadoService.CreateAsync(chamadoDTO);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ChamadoDTO chamadoDTO, int id)
        {
            if (chamadoDTO == null)
                return BadRequest();
            else if (chamadoDTO.Inicio == null)
                return BadRequest();

            var _id = await chamadoService.UpdateAsync(id, chamadoDTO);

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
