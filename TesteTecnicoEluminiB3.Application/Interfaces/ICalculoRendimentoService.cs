using TesteTecnicoEluminiB3.Application.DTOs;

namespace TesteTecnicoEluminiB3.Application.Interfaces
{
    public interface ICalculoRendimentoService
    {
        ResultadoCalculoDTO ObterCalculoInvestimento(CalcularInvestimetoDTO calcularInvestimentoDTO);
    }
}
