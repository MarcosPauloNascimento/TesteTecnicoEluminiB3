using TesteTecnicoEluminiB3.Domain.ValueObjects;

namespace TesteTecnicoEluminiB3.Domain.Interfaces
{
    public interface CalculadoraInvestimentoService
    {
        ResultadoCalculadora CalcularInvestimento(decimal valorInicial, int prazo);
    }
}
