using MediatR;
using Application.Commands.Responses;
namespace Application.Commands.Request

{
    public class ConsultarSaldoResponse
    {
        public int NumeroConta { get; set; }

        public string Nome { get; set; }
        public DateTime DataHora { get; set; }
        
        public decimal SaldoAtual { get; set; }

        public ConsultarSaldoResponse() { }

        public ConsultarSaldoResponse(int numeroConta, string nome,DateTime dataHora, decimal saldoAtual)
        {
            NumeroConta = numeroConta;
            Nome = nome;
            DataHora = dataHora;
            SaldoAtual = saldoAtual;

        }
    }
}