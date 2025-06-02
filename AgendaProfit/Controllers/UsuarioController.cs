using AgendaProfit.Application.AppllicationService.Interfaces;
using AgendaProfit.Application.ViewModel.Contato.Request;
using AgendaProfit.Application.ViewModel.Contato.Responses;
using AgendaProfit.Application.ViewModel.Usuario.Request;
using AgendaProfit.Application.ViewModel.Usuario.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AgendaProfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioApplicationService usuarioApplicationService) : ControllerBase
    {
        private readonly IUsuarioApplicationService _usuarioApplication = usuarioApplicationService;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioResponse>), 200)]
        public async Task<IActionResult> ObterTodosOsUsuarios([FromQuery] UsuarioFilter filtros)
        {
            IEnumerable<UsuarioResponse> usuarios = await _usuarioApplication.ObterTodosOsUusarios(filtros.numeroDaPagina, filtros.tamanhoDaPagina);
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ObterUsuarioPorId(int id)
        {
            UsuarioResponse usuario = await _usuarioApplication.ObterUsuarioPorId(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CriarUsuario([FromBody] CreateUsuarioRequest createRequest)
        {
            var (resultado, mensagem) = await _usuarioApplication.AddUsuario(createRequest);
            if (!resultado)
                return BadRequest(mensagem);

            return NoContent();
        }

        [HttpPut()]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AlterarUsuario([FromBody] UpdateUsuarioRequest updateRequest)
        {
            var (resultado, mensagem) = await _usuarioApplication.AlterarUsuario(updateRequest);

            if (!resultado)
                return BadRequest(mensagem);

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            var (resultado, mensagem) = await _usuarioApplication.RemoverUsuario(id);

            if (!resultado)
                return BadRequest(mensagem);

            return NoContent();
        }

    }
}
