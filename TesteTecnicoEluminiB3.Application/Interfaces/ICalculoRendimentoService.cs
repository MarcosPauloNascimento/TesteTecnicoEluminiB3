using TesteTecnicoEluminiB3.Application.DTOs;

namespace TesteTecnicoEluminiB3.Application.Interfaces
{
    public interface ICalculoRendimentoService
    {
        ResultadoCalculoDto ObterCalculoInvestimento(CalcularInvestimetoDto calcularInvestimento);
    }
}
