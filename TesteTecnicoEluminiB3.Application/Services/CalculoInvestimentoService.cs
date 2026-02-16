using System;
using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Application.Interfaces;
using TesteTecnicoEluminiB3.Application.Mapper;

namespace TesteTecnicoEluminiB3.Application.Services
{
    public class CalculoInvestimentoService : ICalculoInvestimentoService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly InvestimentoFactory _factory;

        public CalculoInvestimentoService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ResultadoCalculoDTO ObterCalculoInvestimento(CalcularInvestimetoDTO calcularInvestimetoDTO)
        {
            var factory = new InvestimentoFactory(_serviceProvider);

            var investmentService = factory.Criar(calcularInvestimetoDTO.InvestmentType);

            var result = investmentService.CalcularInvestimento(calcularInvestimetoDTO.ValorInicial, calcularInvestimetoDTO.Prazo);

            return ResultadoCalculoMapper.Map(result);
        }
    }
}
