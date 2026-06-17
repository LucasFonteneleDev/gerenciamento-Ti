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
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService funcionarioService;
        public FuncionarioController(IFuncionarioService _funcionarioService)
        {
            funcionarioService = _funcionarioService;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> GetList()
        {
            var funcionario = await funcionarioService.GetAllAsync();

            return Ok(funcionario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var funcionario = await funcionarioService.GetById(id);

                if (funcionario == null)
                    return NotFound();

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FuncionarioDTO funcionarioDTO)
        {
            if (funcionarioDTO == null)
                return BadRequest();
            else if (string.IsNullOrWhiteSpace(funcionarioDTO.Email))
                return BadRequest();
            else if (string.IsNullOrEmpty(funcionarioDTO.Nome))
                return BadRequest();
            else if (string.IsNullOrEmpty(funcionarioDTO.Contato))
                return BadRequest();
            else if (string.IsNullOrEmpty(funcionarioDTO.Senha))
                return BadRequest();
            //else if (string.IsNullOrEmpty(funcionarioDTO.Usuario_Ativo))
            //    return BadRequest();
            //else if (string.IsNullOrEmpty(funcionarioDTO.Esta_Ativo_Plataforma))
            //    return BadRequest();

            var id = await funcionarioService.CreateAsync(funcionarioDTO);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] FuncionarioDTO funcionarioDTO, int id)
        {
            if (funcionarioDTO == null)
                return BadRequest();
            else if (string.IsNullOrWhiteSpace(funcionarioDTO.Email))
                return BadRequest();
            else if (string.IsNullOrEmpty(funcionarioDTO.Nome))
                return BadRequest();
            else if (string.IsNullOrEmpty(funcionarioDTO.Contato))
                return BadRequest();
            else if (string.IsNullOrEmpty(funcionarioDTO.Senha))
                return BadRequest();

            var _id = await funcionarioService.UpdateAsync(id, funcionarioDTO);

            return Ok(_id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletou = false;

            try
            {
                deletou = await funcionarioService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(deletou);
        }
    }
}
