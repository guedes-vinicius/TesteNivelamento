using System.Data;
using Application.Commands.Request;
using MediatR;
using NSubstitute;
using Xunit;

public class ContaCorrenteTests
{
    private readonly IDbConnection _dbConnection;
    private readonly IMediator _mediator;

    public ContaCorrenteTests()
    {
        _dbConnection = Substitute.For<IDbConnection>();
        _mediator = Substitute.For<IMediator>();
    }

    [Fact]
    public async Task MovimentarContaTest()
    {
        var movimento = new MovimentarContaRequest
        {
            
            IdContaCorrente = "B6BAFC09-6967-ED11-A567-055DFA4A16C9",
            Valor = 100,
            TipoMovimento = 'C',
            DataMovimento = DateTime.Now
        };

        var result = await _mediator.Send(movimento);

        Assert.NotNull(result);
    }

}