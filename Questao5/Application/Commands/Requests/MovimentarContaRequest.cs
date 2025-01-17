using MediatR;
using Application.Commands.Responses;
namespace Application.Commands.Request

{
    public class MovimentarContaRequest : IRequest<MovimentarContaResponse>
    {
        public string IdContaCorrente { get; set; }
        public DateTime DataMovimento { get; set; }
        public char TipoMovimento { get; set; }
        public decimal Valor { get; set; }

        public MovimentarContaRequest() { }

        public MovimentarContaRequest(string idContaCorrente, DateTime dataMovimento, char tipoMovimento, decimal valor)
        {
            IdContaCorrente = idContaCorrente;
            DataMovimento = dataMovimento;
            TipoMovimento = tipoMovimento;
            Valor = valor;

        }
    }
}