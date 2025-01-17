using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> BuscarContas(string idContaCorrente);
        Task<string> InserirMovimento (Movimento movimento);

    }
}