using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamento_Ti.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService UsuarioService;
        public UsuarioController(IUsuarioService _UsuarioService)
        {
            UsuarioService = _UsuarioService;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> GetList()
        {
            var Usuario = await UsuarioService.GetAllAsync();

            if (Usuario == null || Usuario.Count == 0)
                return NotFound();

            return Ok(Usuario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Usuario = await UsuarioService.GetById(id);

                if (Usuario == null)
                    return NotFound();

                return Ok(Usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool ChecarBadRequest(UsuarioDTO UsuarioDTO)
        {
            if (UsuarioDTO == null)
                return true;
            else if (string.IsNullOrWhiteSpace(UsuarioDTO.Nome))
                return true;
            else if (string.IsNullOrEmpty(UsuarioDTO.Email))
                return true;
            else if (string.IsNullOrEmpty(UsuarioDTO.Senha))
                return true;

            return false;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioDTO UsuarioDTO)
        {
            if (ChecarBadRequest(UsuarioDTO))
                return BadRequest();

            UsuarioDTO.Senha = BCrypt.Net.BCrypt.HashPassword(UsuarioDTO.Senha);

            var id = await UsuarioService.CreateAsync(UsuarioDTO);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UsuarioDTO UsuarioDTO, int id)
        {
            if(ChecarBadRequest(UsuarioDTO))
                return BadRequest();

            UsuarioDTO.Senha = BCrypt.Net.BCrypt.HashPassword(UsuarioDTO.Senha);

            var _id = await UsuarioService.UpdateAsync(id, UsuarioDTO);

            return Ok(_id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletou = false;

            try
            {
                deletou = await UsuarioService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(deletou);
        }
    }
}
