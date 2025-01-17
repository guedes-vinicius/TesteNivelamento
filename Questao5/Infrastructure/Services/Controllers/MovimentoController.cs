using Microsoft.AspNetCore.Mvc;
using Application.Commands.Responses;
using Application.Commands.Request;
using System.Threading.Tasks;
using MediatR;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentoController : ControllerBase
    {
        

        private readonly ILogger<MovimentoController> _logger;
        private readonly IMediator _mediator;
        public MovimentoController(ILogger<MovimentoController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "MovimentarConta")]
        public async Task<MovimentarContaResponse> MovimentarConta(MovimentarContaRequest request)

        {
            var response = await _mediator.Send(request);
            
            return new MovimentarContaResponse(response.IdMovimento);

        }
    }
}