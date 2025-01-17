using System;
using System.Data;
using Dapper;
using Domain.Entities;
using Microsoft.Data.Sqlite;
using Dapper;
using Questao5.Infrastructure.Sqlite;
using Domain.Interfaces;



namespace Application.Queries
{
    public class ConsultaSaldoRepository : IConsultaSaldoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ConsultaSaldoRepository(IDbConnection dbConnection)
        {

            _dbConnection = dbConnection;
        }
        public async Task<ContaCorrente> BuscarContas(string idContaCorrente)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<ContaCorrente>("SELECT * FROM contacorrente WHERE idContaCorrente = @IdContaCorrente", new { IdContaCorrente = idContaCorrente });
        }

        public async Task<decimal> ConsultarSaldo(string idContaCorrente){
            var credito =  await _dbConnection.QuerySingleAsync<decimal>("SELECT COALESCE(SUM(valor),0) FROM movimento WHERE idcontacorrente = @IdContaCorrente and tipomovimento = 'C'", new {IdContaCorrente = idContaCorrente});
            var debito =  await _dbConnection.QuerySingleAsync<decimal>("SELECT COALESCE(SUM(valor),0) FROM movimento WHERE idcontacorrente = @IdContaCorrente and tipomovimento = 'D'", new {IdContaCorrente = idContaCorrente});
            return credito - debito;
        }

    }
}