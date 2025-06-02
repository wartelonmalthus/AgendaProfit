using AgendaProfit.Application.AppllicationService.Interfaces;
using AgendaProfit.Application.ViewModel.Contato.Request;
using AgendaProfit.Application.ViewModel.Contato.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AgendaProfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController(IContatoApplicationService contatoApplicationService) : ControllerBase
    {
        private readonly IContatoApplicationService _contatoApplication = contatoApplicationService;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContatoResponse>), 200)]
        public async Task<IActionResult> ObterTodosOsContatos([FromQuery] ContatoFilter filtros)
        {
            IEnumerable<ContatoResponse> contatos = await _contatoApplication.ObterTodosOsContatos(filtros.numeroDaPagina, filtros.tamanhoDaPagina);
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContatoResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ObterContatoPorId(int id)
        {
            ContatoResponse contato = await _contatoApplication.ObterContatoPorId(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CriarContato([FromBody] CreateContatoRequest createRequest)
        {
            var (resultado, mensagem) = await _contatoApplication.AddContato(createRequest);
            if (!resultado)
                return BadRequest(mensagem);

            return NoContent();
        }

        [HttpPut()]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AlterarContato([FromBody] UpdateContatoRequest updateRequest)
        {
            var (resultado, mensagem) = await _contatoApplication.AlterarContato(updateRequest);

            if (!resultado)
                return BadRequest(mensagem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeletarContato(int id)
        {
            var (resultado, mensagem) = await _contatoApplication.RemoverContato(id);

            if (!resultado)
                return BadRequest(mensagem);

            return NoContent();
        }

    }
}
