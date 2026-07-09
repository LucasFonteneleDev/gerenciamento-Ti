using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using gerenciamento_Ti.Util;

namespace gerenciamento_Ti.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService EmpresaService;
        public EmpresaController(IEmpresaService _EmpresaService)
        {
            EmpresaService = _EmpresaService;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> GetList()
        {
            var Empresas = await EmpresaService.GetAllAsync();

            List<EmpresaDTOGet> empresasDTOget = new List<EmpresaDTOGet>();
            foreach (var Empresa in Empresas)
            {
                empresasDTOget.Add(
                        UDTOEmpresaGet.AplicarValores(Empresa)
                    );
            }

            return Ok(empresasDTOget);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Empresa = await EmpresaService.GetById(id);

                if (Empresa == null)
                    return NotFound();

                EmpresaDTOGet empresaDTO = UDTOEmpresaGet.AplicarValores(Empresa);

                return Ok(empresaDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpresaDTO EmpresaDTO)
        {
            if (EmpresaDTO == null)
                return BadRequest();
            else if (string.IsNullOrWhiteSpace(EmpresaDTO.Nome_Loja))
                return BadRequest();
            else if (string.IsNullOrEmpty(EmpresaDTO.CNPJ))
                return BadRequest();

            var id = await EmpresaService.CreateAsync(EmpresaDTO);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] EmpresaDTO EmpresaDTO, int id)
        {
            if (EmpresaDTO == null)
                return BadRequest();
            else if (string.IsNullOrWhiteSpace(EmpresaDTO.Nome_Loja))
                return BadRequest();
            else if (string.IsNullOrEmpty(EmpresaDTO.CNPJ))
                return BadRequest();

            var _id = await EmpresaService.UpdateAsync(id, EmpresaDTO);

            return Ok(_id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletou = false;

            try
            {
                deletou = await EmpresaService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(deletou);
        }
    }
}
