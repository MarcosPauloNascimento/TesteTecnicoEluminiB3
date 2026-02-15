using System;
using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Application.Interfaces;
using TesteTecnicoEluminiB3.Application.Mapper;

namespace TesteTecnicoEluminiB3.Application.Services
{
    public class CalculoInvestimentoService : ICalculoInvestimentoService
    {
        private readonly IServiceProvider _serviceProvider;

        public CalculoInvestimentoService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ResultadoCalculoDTO GetInvestimentCalculation(CalcularInvestimetoDTO investimetCalculatorDTO)
        {
            var factory = new InvestimentoFactory(_serviceProvider);

            var investmentService = factory.Criar(investimetCalculatorDTO.InvestmentType);

            var result = investmentService.CalcularInvestimento(investimetCalculatorDTO.ValorInicial, investimetCalculatorDTO.Prazo);

            return ResultadoCalculoMapper.Map(result);
        }
    }
}
