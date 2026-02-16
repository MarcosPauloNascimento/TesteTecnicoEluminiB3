using TesteTecnicoEluminiB3.Application.DTOs;

namespace TesteTecnicoEluminiB3.Application.Interfaces
{
    public interface ICalculoInvestimentoService
    {
        ResultadoCalculoDTO ObterCalculoInvestimento(CalcularInvestimetoDTO calcularInvestimentoDTO);
    }
}
