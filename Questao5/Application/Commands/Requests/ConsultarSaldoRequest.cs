using MediatR;
using Application.Commands.Responses;
namespace Application.Commands.Request

{
    public class ConsultarSaldoRequest : IRequest<ConsultarSaldoResponse>
    {
        public string IdContaCorrente { get; set; }

        public ConsultarSaldoRequest() { }

        public ConsultarSaldoRequest(string idContaCorrente)
        {
            IdContaCorrente = idContaCorrente;

        }
    }
}