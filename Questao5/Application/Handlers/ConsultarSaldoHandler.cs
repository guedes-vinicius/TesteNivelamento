using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Application.Commands.Request;
using Application.Commands.Responses;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using Domain.Interfaces;
using System.Linq.Expressions;


namespace Application.Handlers
{

    public class ConsultarSaldoHandler : IRequestHandler<ConsultarSaldoRequest, ConsultarSaldoResponse>

    {
        private readonly IConsultaSaldoRepository _repository;

        public ConsultarSaldoHandler(IConsultaSaldoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ConsultarSaldoResponse> Handle(ConsultarSaldoRequest request, CancellationToken cancellationToken)
        {
            var conta = await _repository.BuscarContas(request.IdContaCorrente);
            var saldo = await _repository.ConsultarSaldo(request.IdContaCorrente);


            if (conta == null)
            {
                throw new Exception("INVALID_ACCOUNT");
            }
            if (conta.Ativo != 1)
            {
                throw new Exception("INACTIVE_ACCOUNT");
            }



            return new ConsultarSaldoResponse(numeroConta: conta.Numero, nome: conta.Nome, dataHora: DateTime.Now, saldoAtual: saldo);
        }



    }


}