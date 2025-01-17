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
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContaCorrenteRepository(IDbConnection dbConnection)
        {

            _dbConnection = dbConnection;
        }
        public async Task<ContaCorrente> BuscarContas(string idContaCorrente)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<ContaCorrente>("SELECT * FROM contacorrente WHERE idContaCorrente = @IdContaCorrente", new { IdContaCorrente = idContaCorrente });
        }

        public async Task<string> InserirMovimento (Movimento movimento)
        {
            var idMovimento = Guid.NewGuid().ToString();
            await _dbConnection.ExecuteAsync("INSERT INTO movimento (idmovimento,idcontacorrente,datamovimento,tipomovimento,valor) VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)",
            new { IdMovimento = idMovimento, movimento.IdContaCorrente, movimento.DataMovimento, movimento.TipoMovimento, movimento.Valor });
            return idMovimento;
        }
    }
}