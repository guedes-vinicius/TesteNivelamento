using System;
using System.Collections;
using Application.Commands.Request;
using Application.Commands.Responses;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Infrastructure.Sqlite;
using Application.Queries;
using Domain.Interfaces;



namespace Application.Handlers
{

    public class MovimentarContaHandler : IRequestHandler<MovimentarContaRequest, MovimentarContaResponse>
    {
        private readonly IContaCorrenteRepository _repository;

        public MovimentarContaHandler(IContaCorrenteRepository repository)
        {
            _repository = repository;
        }
        public async Task<MovimentarContaResponse> Handle(MovimentarContaRequest request, CancellationToken cancellationToken)
        {
            
            var conta = await _repository.BuscarContas(request.IdContaCorrente);

            if (conta == null )
            {
                throw new Exception("INVALID_ACCOUNT");
            }

            if (conta.Ativo != 1)
            {
                throw new Exception ("INACTIVE_ACCOUNT");

            }
            if (request.Valor <= 0)
            {
                throw new Exception ("INVALID_VALUE");
            }

            if (request.TipoMovimento != 'C' && request.TipoMovimento != 'D')
            {
                throw new Exception ("INVALID_TYPE");
            }
            var movimento =  new Movimento();
            movimento.IdContaCorrente = request.IdContaCorrente;
            movimento.DataMovimento = DateTime.Now.ToString("dd/MM/yyyy");
            movimento.TipoMovimento = request.TipoMovimento;
            movimento.Valor = request.Valor;
            var idMovimento = await _repository.InserirMovimento(movimento);
            Guid guidString = new Guid(idMovimento);


            return new MovimentarContaResponse(guidString);
        }
    }


}