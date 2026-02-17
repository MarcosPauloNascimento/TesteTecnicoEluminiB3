using TesteTecnicoEluminiB3.Domain.ValueObjects;

namespace TesteTecnicoEluminiB3.Domain.Interfaces
{
    public interface ICalculadoraInvestimentoCdbService
    {
        ResultadoCalculadora CalcularInvestimento(decimal valorInicial, int prazo);
    }
}
