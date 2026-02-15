using TesteTecnicoEluminiB3.Application.DTOs;

namespace TesteTecnicoEluminiB3.Application.Interfaces
{
    public interface ICalculoInvestimentoService
    {
        ResultadoCalculoDTO GetInvestimentCalculation(CalcularInvestimetoDTO investimetCalculatorDTO);
    }
}
