using AgendaProfit.Application.AppllicationService.Interfaces;
using AgendaProfit.Application.ViewModel.Agenda.Request;
using AgendaProfit.Application.ViewModel.Agenda.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AgendaProfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController(IAgendaApplicationService _agendaApplication) : ControllerBase
    {
        private readonly IAgendaApplicationService _agendaApplication = _agendaApplication;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AgendaResponse>), 200)]
        public async Task<IActionResult> ObterTodasAsAgendas([FromQuery] AgendaFilter filtros)
        {
            IEnumerable<AgendaResponse> agendas = await _agendaApplication.ObterTodasAgendas(filtros.numeroDaPagina, filtros.tamanhoDaPagina);
            return Ok(agendas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AgendaResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ObterAgendaPorId(int id)
        {
           AgendaResponse agenda = await _agendaApplication.ObterAgendaPorId(id);

           if (agenda == null)
                return NotFound();
            
            return Ok(agenda);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CriarAgenda([FromBody] CreateAgendaRequest createRequest)
        {
            var (resultado, mensagem) = await _agendaApplication.AddAgenda(createRequest);
            if(!resultado)
                return BadRequest(mensagem);

            return NoContent();
        }

        [HttpPut()]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AlterarAgenda([FromBody] UpdateAgendaRequest updateRequest)
        {
            var (resultado, mensagem) = await _agendaApplication.AlterarAgenda(updateRequest);

            if (!resultado)
                return BadRequest(mensagem);

            return NoContent();
        }

        [HttpDelete()]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeletarAgenda(int id)
        {
            var (resultado, mensagem) = await _agendaApplication.RemoverAgenda(id);

            if (!resultado)
                return BadRequest(mensagem);

            return NoContent();
        }
    }
}
