using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IConsultaSaldoRepository
    {
        Task<ContaCorrente> BuscarContas(string idContaCorrente);
        Task <decimal> ConsultarSaldo (string idContaCorrente);

    }
}