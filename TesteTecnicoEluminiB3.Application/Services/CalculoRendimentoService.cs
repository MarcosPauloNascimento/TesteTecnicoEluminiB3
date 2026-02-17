using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Application.Interfaces;
using TesteTecnicoEluminiB3.Application.Mapper;
using TesteTecnicoEluminiB3.Domain.Interfaces;

namespace TesteTecnicoEluminiB3.Application.Services
{
    public class CalculoRendimentoService : ICalculoRendimentoService
    {
        private readonly ICalculadoraInvestimentoCdbService _calculadoraInvestimentoService;

        public CalculoRendimentoService(ICalculadoraInvestimentoCdbService calculadoraInvestimentoService)
        {
            _calculadoraInvestimentoService = calculadoraInvestimentoService;
        }

        public ResultadoCalculoDto ObterCalculoInvestimento(CalcularInvestimetoDto calcularInvestimento)
        {
            var result = _calculadoraInvestimentoService.CalcularInvestimento(calcularInvestimento.ValorInicial, calcularInvestimento.Prazo);

            return ResultadoCalculoMapper.Map(result);
        }
    }
}
