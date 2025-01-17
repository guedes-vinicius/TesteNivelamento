using Microsoft.AspNetCore.Mvc;
using Application.Commands.Responses;
using Application.Commands.Request;
using System.Threading.Tasks;
using MediatR;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaSaldoController : ControllerBase
    {
        

        private readonly ILogger<MovimentoController> _logger;
        private readonly IMediator _mediator;
        public ConsultaSaldoController(ILogger<MovimentoController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet()]
        
        public async Task<ConsultarSaldoResponse> ConsultarSaldo([FromQuery]string idContaCorrente)

        {
            var IdContaCorrente = new ConsultarSaldoRequest(idContaCorrente); 
            var response = await _mediator.Send(IdContaCorrente);
            
            return new ConsultarSaldoResponse(response.NumeroConta,response.Nome,response.DataHora,response.SaldoAtual);

        }
    }
}