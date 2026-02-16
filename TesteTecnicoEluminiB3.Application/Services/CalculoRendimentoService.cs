using System;
using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Application.Interfaces;
using TesteTecnicoEluminiB3.Application.Mapper;

namespace TesteTecnicoEluminiB3.Application.Services
{
    public class CalculoRendimentoService : ICalculoRendimentoService
    {
        private readonly InvestimentoFactory _factory;

        public CalculoRendimentoService(InvestimentoFactory factory)
        {
            _factory = factory;
        }

        public ResultadoCalculoDTO ObterCalculoInvestimento(CalcularInvestimetoDTO calcularInvestimetoDTO)
        {
            var investmentService = _factory.Criar(calcularInvestimetoDTO.InvestmentType);

            var result = investmentService.CalcularInvestimento(calcularInvestimetoDTO.ValorInicial, calcularInvestimetoDTO.Prazo);

            return ResultadoCalculoMapper.Map(result);
        }
    }
}
